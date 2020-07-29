open System
open System.IO
open System.Text.RegularExpressions

let mutable i = 0

for line in File.ReadAllLines("input.txt") do
    let a = Regex.Match(line, "(\\w)(\\w)\\w*\\1\\2").Success
    let b = Regex.Match(line, "(\\w)\\w\\1").Success
    if a && b then
        i <- i + 1

Console.Write(i)

(*
    It contains a pair of any two letters that appears at least twice in the string without overlapping, like xyxy (xy) or aabcdefgaa (aa), but not like aaa (aa, but it overlaps).
    It contains at least one letter which repeats with exactly one letter between them, like xyx, abcdefeghi (efe), or even aaa.
*)
