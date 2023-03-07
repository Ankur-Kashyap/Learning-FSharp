[<EntryPoint>]
let main args =
    // int -> int option
    let validation1 num = if num < 1 then None else Some num

    // int -> int option
    let action1 num = num + 1

    // int -> int option
    let validation2 num = if num % 2 <> 0 then None else Some num

    let numberFunction num =
        Some num
        |> Option.bind validation1
        |> Option.map action1
        |> Option.bind validation2
        |> function
            | Some(x) -> x
            | None -> 0

    let result0 = numberFunction 0
    printfn "%A" result0 // 0

    let result1 = numberFunction 1
    printfn "%A" result1 // 2

    let result2 = numberFunction 2
    printfn "%A" result2 // 0

    let transformationPipeline num =
        Some num
        |> Option.map (fun x -> x + 1) // add 1
        |> Option.map (fun x -> x * 2) // times 2
        |> Option.map (fun x -> x + 3) // add 3
        |> Option.map (fun x -> x * 4) // times 4
        |> function
            | Some(x) -> x
            | None -> 0

    // A validation pipeline
    // Given number should be divisible by 2, 3, 4 and 5
    let validationPipeline num =
        Some num
        |> Option.bind (fun x -> if x % 2 = 0 then Some x else None) // div by 2?
        |> Option.bind (fun x -> if x % 3 = 0 then Some x else None) // div by 3?
        |> Option.bind (fun x -> if x % 4 = 0 then Some x else None) // div by 4?
        |> Option.bind (fun x -> if x % 5 = 0 then Some x else None) // div by 5?
        |> function
            | Some(x) -> x
            | None -> 0

    0
