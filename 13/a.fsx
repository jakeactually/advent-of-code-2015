open System
open System.IO
open System.Linq

let lines = File.ReadAllLines("input.txt")
let mutable dic = Map.empty<string, (string * int) list>

for key in ["Alice"; "Bob"; "Carol"; "David"; "Eric"; "Frank"; "George"; "Mallory"] do
    dic <- dic.Add(key, [])

for line in lines do
    let words = line.Split(' ')
    let name2 = words.[10].Substring(0, words.[10].Length - 1)
    dic <- dic.Add(words.[0], (name2, if words.[2] = "gain" then int(words.[3]) else -int(words.[3])) :: dic.[words.[0]])
    
type Path = Path of string * string list * int

let out (p: Path) =
    match p with
    | Path(current, visited, distance) ->
        dic.[current]
            .Where(fun (s, _) -> not(visited.Contains(s)) || visited.Length >= 8 && s = visited.Last())
            .Select(fun (s, d) -> Path(s, s :: visited, distance + d + snd(dic.[s].First(fun v -> fst(v) = current))))

// The result changes depending of the starting point I don't know why

let mutable max = Path("George", ["George"], 0)
let mutable walkers = ["Alice"; "Bob"; "Carol"; "David"; "Eric"; "Frank"; "Mallory"].Select(fun s -> Path(s, [s], 0))
let theEnd (Path(_, set, _)) = set.Length >= 9

while not <| theEnd(max) do
    let result = out(max).Union(walkers)
    let sorted = List.rev <| (List.sortBy (fun (Path(_, _, d)) -> d) <| Seq.toList(result))
    match sorted with
    | nmax :: nwalkers ->
        max <- nmax
        walkers <- nwalkers

Console.WriteLine(max)
