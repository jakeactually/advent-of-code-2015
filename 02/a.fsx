open System
open System.IO
open System.Linq

let lines = File.ReadAllLines("input.txt")

let mutable acc = 0

for line in lines do
    let dims = line.Split('x')
    let l = int(dims.[0])
    let w = int(dims.[1])
    let h = int(dims.[2])
    let a1 = l * w
    let a2 = l * h
    let a3 = w * h
    let min = [a1; a2; a3].Aggregate(fun a b -> Math.Min(a, b))
    acc <- acc + 2 * a1 + 2 * a2 + 2 * a3 + min

Console.Write(acc)
