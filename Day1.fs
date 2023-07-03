let rec sum_lines sum = 
    match System.Int32.TryParse(System.Console.ReadLine()) with
    | true, parsed -> sum_lines(sum + parsed)
    | _ -> sum

let find_max3 x (a, b, c) = 
    if x > a then 
        (x, a, b)
    else if x > b then 
        (a, x, b)
    else if x > c then 
        (a, b, x)
    else 
        (a, b, c)

let rec find_max (a, b, c) = 
    match sum_lines 0 with 
    | 0 -> (a, b, c)
    | input -> find_max3 input (a, b, c) |> find_max

[<EntryPoint>]
let main arg =
    let (a, b, c) = find_max (0, 0, 0)
    printfn "Highest: %d" a
    printfn "Sum: %d" (a + b + c)
    0
