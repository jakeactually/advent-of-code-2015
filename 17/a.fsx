open System
open System.IO

let lines = File.ReadAllLines("input.txt")

let nums = [ for line in lines do int(line) ]

let mutable count = 0

let rec out (n: int) (ns: int list) =
    if n = 150 then
        count <- count + 1

    for (n2, i) in List.zip ns [1..ns.Length] do
        out (n + n2) (List.skip i ns)

out 0 nums

Console.WriteLine(count)
