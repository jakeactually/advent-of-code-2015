open System
open System.IO
open System.Linq
open System.Collections.Generic

let lines = File.ReadAllLines("input.txt")

let chars = lines.Select(fun l -> l.Replace("\\", "aa").Replace("\"", "aa"))

let count (strs: IEnumerable<string>) = strs.Select(String.length).Aggregate(fun a b -> a + b)

Console.Write(count(chars) + chars.Count() * 2 - count(lines))
