// Helper function for 1 param function
// Helper function for trying f when f is 'a -> 'b
// f: ('a -> 'b) -> p: 'a -> Result<'b, exn>
let tryFunc1 f p =
    try
        Ok(f p)
    with ex ->
        Error ex

// Helper function for 2 param function
// Helper function for trying f when f is 'a -> 'b -> 'c
// f: ('a -> 'b -> 'c) -> p1: 'a -> p2: 'b -> Result<'c, exn>
let tryFunc2 f p1 p2 =
    try
        Ok(f p1 p2)
    with ex ->
        Error ex

// Helper function for 3 param function
// Helper function for trying f when f is 'a -> 'b -> 'c -> 'd
// f: ('a -> 'b -> 'c -> 'd) -> p1: 'a -> p2: 'b -> p3: 'c -> Result<'d, exn>
let tryFunc3 f p1 p2 p3 =
    try
        Ok(f p1 p2 p3)
    with ex ->
        Error ex

// Wrapper for System.IO.File.ReadAllText
// May raise exceptions
// string -> string
// file -> content
let readAllTextImpl file = System.IO.File.ReadAllText(file)

// Wrapper for System.IO.File.WriteAllText
// May raise exceptions
// string -> string -> unit
// file -> content -> unit
let writeAllTextImpl file content =
    System.IO.File.WriteAllText(file, content)

// Reads the content of given text file
// string -> Result<string, exn>
let readAllText = tryFunc1 readAllTextImpl

// Writes the content for the specified text file
// string -> string -> Result<unit, exn>
// file -> content -> result
let writeAllText = tryFunc2 writeAllTextImpl

[<EntryPoint>]
let main args =

    // Read method 1

    let readResult = readAllText "somefile.txt"

    match readResult with
    | Ok(content) -> $"File content: {content}"
    | Error(ex) -> $"Read failed: {ex}"
    |> printfn "%s"

    // Read method 2, pipeline + lambda expression

    readAllText "somefile.txt"
    |> (function
    | Ok(content) -> $"File content: {content}"
    | Error(ex) -> $"Read failed: {ex}")
    |> printfn "%s"

    // Write method 1

    let writeResult = writeAllText "somefile.txt" "Here is some content"

    match writeResult with
    | Ok(_) -> $"File written successfully"
    | Error(ex) -> $"Write failed: {ex}"
    |> printfn "%s"

    // Write method 2, pipeline + lambda expression

    writeAllText "somefile.txt" "Here is some content"
    |> (function
    | Ok(_) -> $"File written successfully"
    | Error(ex) -> $"Write failed: {ex}")
    |> printfn "%s"

    0
