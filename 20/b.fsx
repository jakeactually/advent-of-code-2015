open System

let target = 29000000
let size = target / 10

let arr = Array.create size 0

for i in 1..size do
    for j in i..i..Math.Min(i + i * 50, size - 1) do
        arr.[j] <- arr.[j] + i * 11

Array.findIndex (fun x -> x >= target) arr |> printfn "%A"
