open System.IO

let nums = File.ReadAllLines("input.txt") |> Array.map int |> Array.toList

let mutable groups: int list list = []

let rec out (n: int list) (ns: int list) =
    if List.sum n = 387 then
        groups <- n :: groups

    for (n2, i) in List.zip ns [1..ns.Length] do
        out (n2 :: n) (List.skip i ns)

out [] nums

groups
    |> List.filter (fun l -> l.Length = 5)
    |> List.map (List.fold (*) 1L << List.map int64)
    |> List.min
    |> printf "%A"
