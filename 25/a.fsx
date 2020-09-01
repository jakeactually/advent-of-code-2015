let rec sigma n = List.sum [0..n]

let x = 3083
let y = 2978
let i = sigma (x + y - 2) + x

let mutable n = 20151125L

for _ in 1..i - 1 do
    n <- n * 252533L % 33554393L

printfn "%A" n
