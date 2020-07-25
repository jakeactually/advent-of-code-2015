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
    let a1 = (l + w) * 2
    let a2 = (l + h) * 2
    let a3 = (w + h) * 2
    let min = [a1; a2; a3].Aggregate(fun a b -> Math.Min(a, b))
    acc <- acc + min + l * w * h

Console.Write(acc)
