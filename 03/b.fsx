open System
open System.IO
open System.Linq

let text = File.ReadAllText("input.txt")

let mutable x = 0
let mutable y = 0
let mutable rx = 0
let mutable ry = 0
let mutable i = 0
let mutable coords = Set.empty

coords.Add(0, 0)

for chr in text.ToCharArray() do
    if i % 2 = 0 then
        match chr with
        | '^' -> y <- y - 1
        | 'v' -> y <- y + 1
        | '<' -> x <- x - 1
        | '>' -> x <- x + 1
        | _ -> ()
        coords <- coords.Add(x, y)
    else
        match chr with
        | '^' -> ry <- ry - 1
        | 'v' -> ry <- ry + 1
        | '<' -> rx <- rx - 1
        | '>' -> rx <- rx + 1
        | _ -> ()
        coords <- coords.Add(rx, ry)

    i <- i + 1

Console.Write(coords.Count)
