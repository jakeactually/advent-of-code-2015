open System
open System.IO
open System.Text.RegularExpressions

let text = File.ReadAllText("input.txt").Replace("\n", "")

let chars = Regex.Replace(text, "\\\\x[0-9a-f]{2}", "a")
let chars2 = Regex.Replace(chars, "\\\\\\\\|\\\\\\\"", "a")
let chars3 = Regex.Replace(chars2, "\\\"", "")

Console.Write(text.Length - chars3.Length)
