open System
open System.Text
open System.Security.Cryptography

let md5 = MD5.Create()
let mutable i = 0
let mutable flag = true

while flag do
    i <- i + 1
    let hash = md5.ComputeHash(Encoding.ASCII.GetBytes("iwrupvqb" + i.ToString()))
    if hash.[0] = byte(0) && hash.[1] = byte(0) && hash.[2] = byte(0) then
        flag <- false

Console.Write(i)
