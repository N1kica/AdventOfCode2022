// ownerproof-3733989-1701864088-a1b2ff479a81
// dotnet run Program.fs < input.txt
// cat input.txt | dotnet run Program.fs

let rec find_number (line: string) index direction =
    let rec loop i =
        if i < 0 || i >= line.Length then 
            None
        else
            match line.Substring(i) with
            | s when s.StartsWith "one" -> Some('1')
            | s when s.StartsWith "two" -> Some('2')
            | s when s.StartsWith "three" -> Some('3')
            | s when s.StartsWith "four" -> Some('4')
            | s when s.StartsWith "five" -> Some('5')
            | s when s.StartsWith "six" -> Some('6')
            | s when s.StartsWith "seven" -> Some('7')
            | s when s.StartsWith "eight" -> Some('8')
            | s when s.StartsWith "nine" -> Some('9')
            | c when System.Char.IsDigit(c.[0]) -> Some(c.[0])
            | _ -> loop (i + direction)
    loop index

let rec sum_lines sum = 
    match System.Console.ReadLine() with
    | null | "" -> sum
    | line ->
        let first_digit =
            match find_number line 0 1 with
            | Some(digit) -> int digit - int '0'
            | None -> 0
        
        let last_digit =
            match find_number line (line.Length - 1) (-1) with
            | Some(digit) -> int digit - int '0'
            | None -> 0

        sum_lines sum + first_digit * 10 + last_digit

[<EntryPoint>]
let main arg =
    let total_sum = sum_lines 0
    printfn "Total sum: %d" total_sum
    0