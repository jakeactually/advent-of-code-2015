let target = 29000000
let size = target / 10

let arr = Array.create size 0

for i in 1..size do
    for j in i..i..size - 1 do
        arr.[j] <- arr.[j] + i * 10

Array.findIndex (fun x -> x >= target) arr |> printfn "%A"
