open System
open System.IO
open System.Text.RegularExpressions

let lines = [ for line in File.ReadAllLines("input.txt") do line ]

let mutable pairs = List.sortBy (String.length << snd) [
    for line in List.take 43 lines do
        match line.Split([|" => "|], StringSplitOptions.RemoveEmptyEntries) with
        | [|k; v|] -> (k, v)
        | _ -> ("", "")
]

let mutable mol = List.head <| List.skip 44 lines

type Path = Path of string * int * int

let value (Path(s, _, _)) = s

let depth (Path(_, d, _)) = d

let power (Path(_, _, p)) = p

let outs (str: string) (k: string) (v: string) =
    let regexObj = Regex(k)
    let mutable m = regexObj.Match(str)

    [
        while m.Success do
            let result = str.Substring(0, m.Index) + v + str.Substring(m.Index + m.Length)
            m <- regexObj.Match(str, m.Index + 1)
            result
    ]

let out (Path(s, i, _)) =
    let ops = List.filter (fun (_, v: string) -> s.Contains(v)) pairs
    List.concat [ for (k, v) in ops do List.map (fun s2 -> Path(s2, i + 1, 100 - ops.Length)) (outs s v k) ]

let mutable current: Path = Path(mol, 0, 100)
let mutable all: Path list = []
let mutable set: Set<string> = Set.empty

while value current <> "e" do
    printfn "%A" current

    let result = List.filter (not << set.Contains << value) <| out current

    set <- set.Add <| value current

    let ws = List.sortBy power <| List.concat [all; result]

    match ws with
    | x :: xs ->
        current <- x
        all <- xs

printfn "%A" current
