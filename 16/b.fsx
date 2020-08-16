open System
open System.IO
open System.Text.RegularExpressions

let dic = Map.ofList [
    "children", 3;
    "cats", 7;
    "samoyeds", 2;
    "pomeranians", 3;
    "akitas", 0;
    "vizslas", 0;
    "goldfish", 5;
    "trees", 3;
    "cars", 2;
    "perfumes", 1;
]

let lines = File.ReadAllLines("input.txt")

let aunts = [
    for line in lines do [
            for m in Regex.Matches(line, "([a-z]+): (\\d+)") do
                m.Groups.Item(1).Value, int(m.Groups.Item(2).Value)
        ]
]

let all f xs = List.tryFind (not << f) xs = None

let test (k, v) =
    k = "cats" && dic.[k] < v ||
    k = "trees" && dic.[k] < v ||
    k = "pomeranians" && dic.[k] > v ||
    k = "goldfish" && dic.[k] > v ||
    dic.[k] = v

for (things, i) in List.zip aunts [1..500] do
    if all test things then
        Console.WriteLine(i)
