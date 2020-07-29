open System
open System.IO
open System.Text.RegularExpressions

let mutable i = 0

for line in File.ReadAllLines("input.txt") do
    let a = Regex.Matches(line, "[aeiou]").Count >= 3
    let b = Regex.Match(line, "(\\w)\\1").Success
    let c = not <| Regex.Match(line, "ab|cd|pq|xy").Success
    if a && b && c then
        i <- i + 1

Console.Write(i)

(*
    It contains at least three vowels (aeiou only), like aei, xazegov, or aeiouaeiouaeiou.
    It contains at least one letter that appears twice in a row, like xx, abcdde (dd), or aabbccdd (aa, bb, cc, or dd).
    It does not contain the strings ab, cd, pq, or xy, even if they are part of one of the other requirements.
*)
