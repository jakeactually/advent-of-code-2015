open System
open System.IO
open System.Linq

let text = File.ReadAllText("input.txt")

let value c =
    match c with
    | '(' -> 1
    | ')' -> -1

let mutable acc = 0
let mutable i = 0

for c in text.ToCharArray() do
    acc <- acc + value c
    i <- i + 1
    if acc = -1 then
        Console.WriteLine(i)
