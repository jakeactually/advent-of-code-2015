open System
open System.IO
open System.Text.RegularExpressions

let lines = File.ReadAllLines("input.txt")

let distances = seq {
    for line in lines do
        let nums = [for m in Regex.Matches(line, "\\d+") do int(m.Value)]
        let vel = nums.[0]
        let time = nums.[1]
        let rest = nums.[2]
        
        let lap = time + rest
        let laps = 2503 / lap
        let rem = 2503 % lap
        let trueRem = Math.Min(time, rem)

        yield laps * time * vel + trueRem * vel
}

Console.WriteLine(Seq.max(distances))
