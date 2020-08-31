open System.IO

type Ins
    = Half of char
    | Triple of char
    | Inc of char
    | Jump of int
    | Jie of char * int
    | Jio of char * int

let ins = [
    for line in File.ReadAllLines("input.txt") do
        let words = line.Split(' ') |> List.ofArray

        match words.[0] with
        | "hlf" -> Half(words.[1].[0])
        | "tpl" -> Triple(words.[1].[0])
        | "inc" -> Inc(words.[1].[0])
        | "jmp" -> Jump(int(words.[1]))
        | "jie" -> Jie(words.[1].[0], int(words.[2]))
        | "jio" -> Jio(words.[1].[0], int(words.[2]))
]

let mutable state = Map.ofList [('a', 0); ('b', 0)]

let mutable ip = 0;

while ip < ins.Length do
    match ins.[ip] with
    |   Half(r) ->
            state <- state.Add(r, state.[r] / 2)
            ip <- ip + 1
    |   Triple(r) ->
            state <- state.Add(r, state.[r] * 3)
            ip <- ip + 1
    |   Inc(r) ->
            state <- state.Add(r, state.[r] + 1)
            ip <- ip + 1
    |   Jump(o) -> ip <- ip + o
    |   Jie(r, o) -> if state.[r] % 2 = 0 then ip <- ip + o else ip <- ip + 1
    |   Jio(r, o) -> if state.[r] = 1 then ip <- ip + o else ip <- ip + 1

printf "%A" state
