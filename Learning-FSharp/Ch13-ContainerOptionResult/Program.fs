// Person record type
// Age is of type int option
// Indicating that age may or may not be available
type Person = { Name: string; Age: int option }

[<EntryPoint>]
let main args =
    let inputList = [ 1; 2; 3; 4; 5; 6; 7; 8; 9; 10 ]

    let status =
        {| SourceList = inputList
           SourceCount = 0
           SourceWeight = 0
           TargetList = list<int>.Empty
           TargetCount = 0
           TargetWeight = 0 |}

    let afterWork =
        status
        |> (fun st ->
            {| st with
                SourceCount = st.SourceList.Length |})
        |> (fun st ->
            {| st with
                SourceWeight = List.sum st.SourceList |})
        |> (fun st ->
            {| st with
                TargetList = List.filter (fun x -> x % 2 = 0) st.SourceList |})
        |> (fun st ->
            {| st with
                TargetCount = st.TargetList.Length |})
        |> (fun st ->
            {| st with
                TargetWeight = List.sum st.TargetList |})

    printfn
        "Job Complete. Source Count: %d, Source Total: %d, Target Count: %d, Target Total: %d"
        afterWork.SourceCount
        afterWork.SourceWeight
        afterWork.TargetCount
        afterWork.TargetWeight

    // Yes, there is data, 1
    // int option
    let a = Some 1

    // Yes, there is data, "1"
    // string option
    let b = Some "1"

    // Nope, no data
    let c = None

    // When age is known
    let p1 = { Name = "Whatever"; Age = Some 1 }

    // When age is not known
    let p2 = { Name = "Whatever"; Age = None }

    // Option matching
    match a with
    | Some(x) -> $"Found {x}."
    | None -> "Found Nothing."
    |> printfn "%s"

    // Indicates success, result = 1
    let x = Ok 1

    // Indicates success, result = "1"
    let y = Ok "1"

    // Indicates failure
    let z = Error(System.ArgumentException("Don't like your argument!"))

    // Result matching
    match x with
    | Ok(x) -> $"Success with {x}."
    | Error(x) -> $"Failure with {x}"
    |> printfn "%s"

    0
