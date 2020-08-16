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

for (things, i) in List.zip aunts [1..500] do
    if List.tryFind (fun (k, v) -> dic.[k] <> v) things = None then
        Console.WriteLine(i)
