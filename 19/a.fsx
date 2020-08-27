open System
open System.IO

let lines = [ for line in File.ReadAllLines("input.txt") do line ]

let pairs = [
    for line in List.take 43 lines do
        match line.Split([|" => "|], StringSplitOptions.RemoveEmptyEntries) with
        | [|k; v|] -> (k, v)
        | _ -> ("", "")
]

let mol = List.head <| List.skip 44 lines

let rec intersperse xs a b n =
    match xs with
    | [y] -> [y]
    | y :: ys ->
        if n = 0 then
            y :: b :: intersperse ys a b (n - 1)
        else
            y :: a :: intersperse ys a b (n - 1)
    | [] -> []

let mutable set = Set.empty

for (k, v) in pairs do
    let parts = [ for x in mol.Split([|k|], StringSplitOptions.None) do x ]

    for i in 0..parts.Length - 2 do
        set <- set.Add (String.Concat<string> <| intersperse parts k v i)

printf "%d" set.Count
