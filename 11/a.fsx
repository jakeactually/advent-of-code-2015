open System
open System.Linq

let increase (cs: char[]) =
    let mutable offset = 7
    let mutable flag = true
    while flag do
        cs.[offset] <- (char)((int)cs.[offset] + 1)
        if cs.[offset] > 'z' then
            cs.[offset] <- 'a'
            offset <- offset - 1
        else
            flag <- false

let triple (cs: char[]) =
    let mutable flag = false
    for i in 0..5 do
        flag <- flag || (int)cs.[i] = (int)cs.[i + 1] - 1 && (int)cs.[i + 1] = (int)cs.[i + 2] - 1
    flag

let pairs (cs: char[]) =
    let mutable count = 0
    let mutable i = 0
    while i < 7 do
        if (int)cs.[i] = (int)cs.[i + 1] then
            count <- count + 1
            i <- i + 1
        i <- i + 1
    count > 1

let forbidden (cs: char[]) = cs.Any(fun c -> c = 'i' || c = 'o' || c = 'l')

let mutable input = "hxbxwxba".ToCharArray()
let mutable flag = true

while flag do
    increase(input)
    if triple(input) && pairs(input) && not <| forbidden(input) then
        flag <- false

Console.WriteLine(input)
