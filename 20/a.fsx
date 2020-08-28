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

let mutable i = 2
let mutable sum = 0

combs [1;2;3] |> printfn "%A"
