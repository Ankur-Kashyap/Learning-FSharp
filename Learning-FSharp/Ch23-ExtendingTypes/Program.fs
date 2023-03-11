open System.Runtime.CompilerServices

// Discriminated union of Int, String
type IntOrString =
    | I of int
    | S of string

    // Static member
    static member CreateI i = I i

    // Static member
    static member CreateS s = S s

    // Instance member
    member this.ToStringValue() =
        match this with
        | I i -> $"Current value is Int {i}"
        | S s -> $"Current value is String {s}"

    // + operator for IntOrString
    static member (+)(x, y) =
        match x, y with
        | I i1, I i2 -> (i1 + i2).ToString()
        | S s1, S s2 -> s1 + s2
        | I i, S s -> $"{i}{s}"
        | S s, I i -> $"{s}{i}"

// Adding member to Result module
module Result =
    // toStringValue becomes a member of Result module
    // Like Result.map and Result.bind, you can call Result.toStringValue
    let toStringValue res =
        match res with
        | Ok ok -> $"Current value is Ok {ok}"
        | Error err -> $"Current value is Error {err}"

// Optional type extensions for Result<'T, 'TError>
type Result<'T, 'TError> with

    // ToStringValue becomes an optional type extension
    // for Result<'T, 'TError>
    // <instance>.ToStringValue()
    member this.ToStringValue() = Result.toStringValue this

// C#-style Extension methos
// Notice the type level attribute
[<Extension>]
type MyExtensions =
    // Notice the member level attribute
    // ToStringValueExtension1 becomes a C#-style extension method
    [<Extension>]
    static member ToStringValueExtension1 this = Result.toStringValue this

    // Same as previous member, ToStringValueExtension1
    // Single paramemer function can be created with or without () for params
    [<Extension>]
    static member ToStringValueExtension2(this) = Result.toStringValue this

    // Multi-parameter function must use () for parameters
    [<Extension>]
    static member ToStringValueExtension3(this, append) = (Result.toStringValue this) + append

    // This member won't appear as an extension...
    // Multi-parameter function must use () for parameters.
    [<Extension>]
    static member ToStringValueExtension4 this append = (Result.toStringValue this) + append

[<EntryPoint>]
let main args =

    // Both are same
    let i = I 1
    let i = IntOrString.CreateI 1

    // Both are same
    let s = S "One"
    let s = IntOrString.CreateS "One"

    // Calls member this.ToStringValue, Line 15
    i.ToStringValue() |> printfn "%s" // Current value is Int 1
    s.ToStringValue() |> printfn "%s" // Current value is String 1

    // Calls static member (+)(x, y), Line 21
    i + s |> printfn "%s" // 1One

    // Calls let toStringValue res =, Line 32
    Result.toStringValue (Ok 1) |> printfn "%s" // Current value is Ok 1

    // Calls member this.ToStringValue(), Line 43
    (Ok 1).ToStringValue() |> printfn "%s" // Current value is Ok 1

    // Call to static member ToStringValueExtension1 this, Line 52
    (Ok 1).ToStringValueExtension1() |> printfn "%s" // Current value is Ok 1

    // Call to static member ToStringValueExtension2(this), Line 57
    (Ok 1).ToStringValueExtension2() |> printfn "%s" // Current value is Ok 1

    // Call to static member ToStringValueExtension3(this, append), Line 61
    (Ok 1).ToStringValueExtension3("XYZ") |> printfn "%s" // Current value is Ok 1XYZ

    0
