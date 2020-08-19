open System
open System.IO

let lines = File.ReadAllLines("input2.txt")

let mutable data = [|
    for line in lines do [|
        for chr in line do (chr = '#')
    |]
|]

let mutable mat = Array2D.init 100 100 (fun y x -> data.[y].[x])
let mutable mat2 = Array2D.init 100 100 (fun y x -> data.[y].[x])

let dirs = [(-1, -1); (0, -1); (1, -1); (1, 0); (1, 1); (0, 1); (-1, 1); (-1, 0)]

for _ in 0..99 do
    for y in 0..99 do
        for x in 0..99 do
            let mutable neighbors = 0

            for (ox, oy) in dirs do
                let (nx, ny) = (x + ox, y + oy)

                if nx >= 0 && ny >= 0 && nx <= 99 && ny <= 99 then
                    if mat.[ny, nx] then
                        neighbors <- neighbors + 1
            
            if mat.[y, x] && neighbors <> 2 && neighbors <> 3 then
                if (x, y) <> (0, 0) && (x, y) <> (0, 99) && (x, y) <> (99, 0) && (x, y) <> (99, 99) then
                    mat2.[y, x] <- false

            if not mat.[y, x] && neighbors = 3 then
                mat2.[y, x] <- true

    mat <- Array2D.init 100 100 (fun y x -> mat2.[y, x])

let mutable count = 0

for y in 0..99 do
    for x in 0..99 do
        if mat.[y, x] then
            count <- count + 1

Console.WriteLine(count)
