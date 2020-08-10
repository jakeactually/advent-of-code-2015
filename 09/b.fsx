open System
open System.IO
open System.Linq

let lines = File.ReadAllLines("input.txt")
let mutable dic = Map.empty<string, (string * int) list>

for key in ["AlphaCentauri"; "Snowdin"; "Tambi";  "Faerun"; "Norrath"; "Straylight"; "Tristram"; "Arbre"] do
    dic <- dic.Add(key, [])

for line in lines do
    let words = line.Split(' ')
    dic <- dic.Add(words.[0], (words.[2], int(words.[4])) :: dic.[words.[0]])
    dic <- dic.Add(words.[2], (words.[0], int(words.[4])) :: dic.[words.[2]])

type Path = Path of string * string list * int

let out (p: Path) =
    match p with
    | Path(current, visited, distance) -> dic.[current].Where(fun (s, _) -> not <| visited.Contains(s)).Select(fun (s, d) -> Path(s, s :: visited, distance + d))

let mutable max = Path("AlphaCentauri", ["AlphaCentauri"], 0)
let mutable walkers = ["Snowdin"; "Tambi";  "Faerun"; "Norrath"; "Straylight"; "Tristram"; "Arbre"].Select(fun s -> Path(s, [s], 0))
let theEnd (Path(_, set, _)) = set.Length >= 8

while not <| theEnd(max) do
    let result = out(max).Union(walkers)
    let sorted = List.rev <| (List.sortBy (fun (Path(_, _, d)) -> d) <| Seq.toList(result))
    match sorted with
    | nmax :: nwalkers ->
        max <- nmax
        walkers <- nwalkers

Console.WriteLine(max)
