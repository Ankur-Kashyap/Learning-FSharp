// Discriminated union for indicating name validation result
type NameValidationResult =
    | NameValidationOk
    | NameValidationNotOk

// Name validation function
let validateName (name: string) =
    if name.Length = 0 then
        NameValidationNotOk
    else
        NameValidationOk

// Name validation active pattern
let (|InvalidName|ValidName|) (name: string) =
    if name.Length = 0 then InvalidName else ValidName

// Representation of months
type Month =
    | Jan
    | Feb
    | Mar
    | Apr
    | May
    | Jun
    | Jul
    | Aug
    | Sep
    | Oct
    | Nov
    | Dec

// Given number to month
let (|ValidMonth|InvalidMonth|) num =
    let m = [ Jan; Feb; Mar; Apr; May; Jun; Jul; Aug; Sep; Oct; Nov; Dec ]

    if num >= 1 && num <= m.Length then
        ValidMonth m[num - 1]
    else
        InvalidMonth

// Checks if the number is > than 100
let (|GreaterThan100|_|) num = if num > 100 then Some num else None

// Checks if the number is < than 100
let (|LessThan100|_|) num = if num < 100 then Some num else None

// Compares the given number with 100
let compareNumWith100 num =
    match num with
    | GreaterThan100 x -> $"{x} is greater than 100."
    | LessThan100 x -> $"{x} is less than 100."
    | _ -> "Seems number is 100."

// Checks if the number is > than compareWith
// General purpose
let (|GreaterThan|_|) compareWith num =
    if num > compareWith then Some num else None

// Checks if the number is < than compareWith
// General purpose
let (|LessThan|_|) compareWith num =
    if num < compareWith then Some num else None

// Partial application of (|GreaterThan|_|)
// Checks if the number is > than 5000
// Specialized
let (|GreaterThan5000|_|) = (|GreaterThan|_|) 5000

// Partial application of (|LessThan5000|_|)
// Checks if the number is < than 5000
// Specialized
let (|LessThan5000|_|) = (|LessThan|_|) 5000

// Compares the given number with 5000
let compareNumWith5000 num =
    match num with
    | GreaterThan5000 x -> $"{x} is greater than 5000."
    | LessThan5000 x -> $"{x} is less than 5000."
    | _ -> "Seems number is 5000."

[<EntryPoint>]
let main args =
    let name = "Whatever"

    match name with
    | value when value.Length = 0 -> false
    | _ -> true
    |> printfn "%A"

    match validateName name with
    | NameValidationNotOk -> false
    | NameValidationOk -> true
    |> printfn "%A"

    match name with
    | InvalidName -> false
    | ValidName -> true
    |> printfn "%A"

    match 1 with
    | ValidMonth m -> $"Month: {m}"
    | InvalidMonth -> "Sorry. Should be between 1 and 12."
    |> printfn "%A" // "Month: Jan"

    match 13 with
    | ValidMonth m -> $"Month: {m}"
    | InvalidMonth -> "Sorry. Should be between 1 and 12."
    |> printfn "%A" // "Sorry. Should be between 1 and 12."

    compareNumWith100 1 |> printfn "%A" // "1 is less than 100."
    compareNumWith100 101 |> printfn "%A" // "101 is greater than 100."
    compareNumWith100 100 |> printfn "%A" // "Seems number is 100."

    compareNumWith5000 1 |> printfn "%A" // "1 is less than 5000."
    compareNumWith5000 5001 |> printfn "%A" // "5001 is greater than 5000."
    compareNumWith5000 5000 |> printfn "%A" // "Seems number is 5000."

    0
