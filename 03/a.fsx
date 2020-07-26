open System
open System.IO
open System.Linq

let text = File.ReadAllText("input.txt")

let mutable x = 0
let mutable y = 0
let mutable coords = Set.empty

coords.Add(0, 0)

for chr in text.ToCharArray() do
    match chr with
    | '^' -> y <- y - 1
    | 'v' -> y <- y + 1
    | '<' -> x <- x - 1
    | '>' -> x <- x + 1
    | _ -> ()
    coords <- coords.Add(x, y)

Console.Write(coords.Count)
