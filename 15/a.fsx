open System
open System.IO
open System.Text.RegularExpressions

let lines = File.ReadAllLines("input.txt")

let is = [
    for line in lines do [
            for m in Regex.Matches(line, "-?\\d+") do
                int(m.Value)
        ]
]

let mutable max = 0

for i in 0..100 do
    for j in 0..100-i do
        for k in 0..100-i-j do
            let l = 100-i-j-k

            let a = Math.Max(is.[0].[0] * i + is.[1].[0] * j + is.[2].[0] * k + is.[3].[0] * l, 0)
            let b = Math.Max(is.[0].[1] * i + is.[1].[1] * j + is.[2].[1] * k + is.[3].[1] * l, 0)
            let c = Math.Max(is.[0].[2] * i + is.[1].[2] * j + is.[2].[2] * k + is.[3].[2] * l, 0)
            let d = Math.Max(is.[0].[3] * i + is.[1].[3] * j + is.[2].[3] * k + is.[3].[3] * l, 0)

            let t = a * b * c * d

            if t > max then
                max <- t

Console.WriteLine(max)
