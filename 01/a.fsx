open System
open System.IO
open System.Linq

let text = File.ReadAllText("input.txt")

let value c =
    match c with
    | '(' -> 1
    | ')' -> -1

let result = text.ToCharArray().Select(value).Aggregate(fun a b -> a + b)

Console.Write(result)
