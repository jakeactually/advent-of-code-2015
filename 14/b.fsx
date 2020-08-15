open System
open System.IO
open System.Text.RegularExpressions

type Reindeer = Reindeer of int * int * int * int * bool * int * int

let move (Reindeer(vel, time, rest, count, running, dist, score)) =
    if running then
        if count >= time then
            Reindeer(vel, time, rest, 1, not running, dist, score)
         else
            Reindeer(vel, time, rest, count + 1, running, dist + vel, score)
    else
        if count >= rest then
            Reindeer(vel, time, rest, 1, not running, dist + vel, score)
        else
            Reindeer(vel, time, rest, count + 1, running, dist, score)

let getDist (Reindeer(_, _, _, _, _, dist, _)) = dist

let getScore (Reindeer(_, _, _, _, _, _, score)) = score

let increaseScore(Reindeer(a, b, c, d, e, f, score)) = Reindeer(a, b, c, d, e, f, score + 1)

let lines = File.ReadAllLines("input.txt")

let mutable reindeers = [|
    for line in lines do
        let nums = [for m in Regex.Matches(line, "\\d+") do int(m.Value)]
        match nums with
        | [a; b; c] -> Reindeer(a, b, c, 0, true, 0, 0)
        | _ -> Reindeer(0, 0, 0, 0, false, 0, 0)
|]

for j in 1..2503 do
    // Console.WriteLine(j)
    for i in 0..reindeers.Length - 1 do
        reindeers.[i] <- move(reindeers.[i])
        // Console.WriteLine(reindeers.[i])
    // Console.WriteLine()

    let mr = Seq.maxBy getDist reindeers

    for (r, i) in Array.zip reindeers [|0..8|] do
        if getDist r = getDist mr then
            reindeers.[i] <- increaseScore(reindeers.[i])

// Console.WriteLine(Seq.maxBy getScore reindeers)

for r in reindeers do
    Console.WriteLine(r)
