open System
open System.IO

let lines = File.ReadAllLines("input.txt")

let nums = [ for line in lines do int(line) ]

let mutable dic = Map.empty<int, int>

let rec out (n: int) (ns: int list) (level: int) =
    if n = 150 then
        dic <- dic.Add(level, if dic.ContainsKey(level) then dic.[level] + 1 else 1)

    for (n2, i) in List.zip ns [1..ns.Length] do
        out (n + n2) (List.skip i ns) (level + 1)

out 0 nums 0

Console.WriteLine(dic)
