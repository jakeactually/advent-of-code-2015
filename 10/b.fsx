open System
open System.Linq
open System.Text.RegularExpressions

let mutable text = "1113122113"

for _ in 1..50 do
    let ms = Regex.Matches(text, "(\\d)\\1*")
    let strs = seq { for m in ms do m.Value.Length.ToString() + m.Value.First().ToString() }
    text <- String.Join("", strs)

Console.Write(text.Length)
