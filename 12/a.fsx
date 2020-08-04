open System
open System.Linq
open System.IO
open System.Text.RegularExpressions

let text = File.ReadAllText("input.txt")

let sum = (seq { for m in Regex.Matches(text, "-?\\d+") do m }).Select(fun m -> int(m.Value)).Sum()

Console.Write(sum)
