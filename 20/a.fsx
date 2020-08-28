let rec factors n i =
    if i > n then
        []
    else if n % i = 0 then
        i :: factors (n / i) 2
    else
        factors n (i + 1)

let rec sublists xs =
    match xs with
    | y :: ys -> (y :: ys) :: sublists ys
    | _ -> []

let rec combs (ns: int list): int list list =
    match ns with
    | x :: xs -> List.concat [for s in sublists xs do (x :: s) :: combs s]
    | _ -> []

let combsw xs = List.concat [combs xs; List.map List.singleton xs] |> Set.ofList |> Set.toList

let mutable i = 2
let mutable sum = 0

while sum * 10 < 29000000 do
    printfn "%A" i
    sum <- 1 + List.sum [ for c in factors i 2 |> combsw do List.fold (*) 1 c ]
    i <- i + 1
