open System
open System.IO

let lines = [ for line in File.ReadAllLines("input.txt") do line ]

let mutable pairs = List.sortBy (String.length << snd) [
    for line in List.take 43 lines do
        match line.Split([|" => "|], StringSplitOptions.RemoveEmptyEntries) with
        | [|k; v|] -> (k, v)
        | _ -> ("", "")
]

let mutable mol = List.head <| List.skip 44 lines

type Path = Path of string * int

let value (Path(s, i)) = s

let rec intersperse xs a b n =
    match xs with
    | [y] -> [y]
    | y :: ys ->
        if n = 0 then
            y :: b :: intersperse ys a b (n - 1)
        else
            y :: a :: intersperse ys a b (n - 1)
    | [] -> []

let outs (s: string) (k: string) (v: string): string list =
    let parts = [ for x in s.Split([|k|], StringSplitOptions.None) do x ]

    [ for i in 0..parts.Length - 2 do
        String.Concat<string> <| intersperse parts k v i ]

let out (Path(s, i)) =
    let ops = List.filter (fun (k: string, v: string) -> mol.Contains(v)) pairs
    List.concat [ for (k, v) in ops do List.map (fun s2 -> Path(s2, i + 1)) (outs s v k) ]

let mutable min: Path = Path(mol, 0)
let mutable all: Path list = []
let mutable set: Set<string> = Set.empty

while value min <> "e" do
    printfn "%O" min

    let ws = List.sortBy (fun (Path(s, i)) -> s.Length) <| (List.filter (fun (Path(s, i)) -> not <| set.Contains(s)) <| List.concat [all; out min])
    
    set <- Set.union set (Set.ofList <| List.map value ws)

    match ws with
    | x :: xs ->
        min <- x
        all <- xs
