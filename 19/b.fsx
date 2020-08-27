open System.IO
open System.Text.RegularExpressions

let mutable mol = File.ReadAllLines("input.txt").[44]

let tokens = [ for m in Regex.Matches(mol, "[A-Z][a-z]?") do m.Value ]
let pars = List.filter (fun t -> t = "Rn" || t = "Ar") tokens
let commas = List.filter (fun t -> t = "Y") tokens

let result = tokens.Length - pars.Length - 2 * commas.Length - 1

printfn "%A" result
