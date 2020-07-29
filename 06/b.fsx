open System
open System.IO
open System.Text.RegularExpressions

let mutable sum = 0
let mutable lights = Array2D.create 1000 1000 0

for line in File.ReadAllLines("input.txt") do
    let ns = Regex.Matches(line, "\\d+")
    let x1 = int(ns.[0].Value)
    let y1 = int(ns.[1].Value)
    let x2 = int(ns.[2].Value)
    let y2 = int(ns.[3].Value)

    for y in x1..x2 do
        for x in y1..y2 do
            if line.Contains("on") then
                lights.[x, y] <- lights.[x, y] + 1
            else if line.Contains("off") then
                lights.[x, y] <- Math.Max(0, lights.[x, y] - 1)
            else
                lights.[x, y] <- lights.[x, y] + 2

for y in 0..999 do
    for x in 0..999 do
        sum <- sum + lights.[x, y]

Console.Write(sum)
