open System
open System.IO
open System.Linq

type Val = Var of string | Num of int

let toVal (s: string) =
    try
        Num(int(s))
    with _ ->
        Var(s)

type Ins
    = Single of Val
    | And of Val * Val
    | Or of Val * Val
    | Not of Val
    | Left of Val * Val
    | Right of Val * Val

type Line = Line of string * Ins

let toLine (str: string) =
    let parts = str.Split([|" -> "|], StringSplitOptions.RemoveEmptyEntries)
    let value = parts.[0]
    let key = parts.[1]
    let words = value.Split(' ')

    let ins =
        if value.Contains("AND") then
            And(toVal(words.[0]), toVal(words.[2]))
        else if value.Contains("OR") then
            Or(toVal(words.[0]), toVal(words.[2]))
        else if value.Contains("LSHIFT") then
            Left(toVal(words.[0]), toVal(words.[2]))
        else if value.Contains("RSHIFT") then
            Right(toVal(words.[0]), toVal(words.[2]))
        else if value.Contains("NOT") then
            Not(toVal(words.[1]))
        else
            Single(toVal(words.[0]))

    Line(key, ins)

let mutable dic = Map.empty<string, Ins>
let mutable cache = Map.empty<string, int>

let lines = File.ReadAllLines("input.txt").Select(toLine)
for line in lines do
    match line with
    | Line(str, ins) -> dic <- dic.Add(str, ins)

let rec getValue (s: string): int =
    match dic.[s] with
    | And(a, b) -> subValue(a) &&& subValue(b)
    | Or(a, b) -> subValue(a) ||| subValue(b)
    | Left(a, b) -> subValue(a) <<< subValue(b)
    | Right(a, b) -> subValue(a) >>> subValue(b)
    | Not(a) -> ~~~ subValue(a)
    | Single(a) -> subValue(a)
and subValue (v: Val): int =
    match v with
    | Var s ->
        if cache.ContainsKey(s) then
            cache.[s]
        else
            let n = getValue(s)
            cache <- cache.Add(s, n)
            n
    | Num n -> n

Console.Write(getValue("a"))
