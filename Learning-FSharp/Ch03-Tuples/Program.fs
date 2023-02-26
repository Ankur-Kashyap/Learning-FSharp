(*
  Tuples allow grouping of values. The values may be of the same or different types.
  A tuple in F# has the signature:
  Type1 * Type2 * ... * TypeN
*)

[<EntryPoint>]
let main args =

    // Here is a tuple of int, followed by string, and then a doubel/float.
    let tupV1 = (1, "One", 1.0)
    let tupV2: int * string * float = (2, "Two", 2.0)

    // Here is the let binding to deconstruct a tuple via pattern matching. More on pattern matching in the later chapters.
    // x gets the first element of the tuple.
    // y gets the second element of the tuple.
    // z gets the third element of the tuple.
    // Data type of x, y, z depends on the data type of tuple,
    // which is int * string * float in this case.
    let (x, y, z) = (1, "One", 1.0)
    let (x: int, y: string, z: float) = (2, "Two", 2.0)

    // Here is a function which accepts 3 parameters,
    // and returns a tuple, which is 3 parameters grouped.
    // The signature of this function is:
    // 'a -> 'b -> 'c -> 'a * 'b * 'c
    // All the parameters are of generic type.
    let returnTuple x y z = (x, y, z)

    // Here is a function which accepts 1 parameter, a tuple.
    // The signature of this function is:
    // int * int * int -> int
    let returnTupleTotal (x, y, z) = x + y + z

    // This is a major source of confusion for C++/C#/Java programmers.
    // returnTupleTotal appears to be a function which accepts 3 parameters.
    // Remember, parameters in F# are space separated, not comma.
    // When you see () in F#, you are dealing with unit or tuples, not function calls or parameters.

    // Here is a function which accepts 2 parameters, a tuple and an int.
    // The signature of this function is:
    // int * int * int -> int -> int
    let anotherTupleTotal (x, y, z) a = x + y + z + a

    // Here is another example to further illustrate the () issue.
    // The signature of aSillyFunction is:
    // unit -> unit
    // aSillyFunction () is calling aSillyFunction with param value as ().
    // aSillyFunction () is not a call to a void function in C++/C#/Java.
    // Since aSillyFunction returns unit, the type of sillyFunctionResult is unit.
    let aSillyFunction () = ()
    let sillyFunctionResult = aSillyFunction ()

    // Both F# and C# support reference and value tuples.
    // Reference tuples follow reference semantics, value tuples follow value semantics.
    // In F#: (x, y, z) creates a reference tuple.
    // In C#: (x, y, z) creates a value tuple.

    // Constructing and deconstructing a struct tuple.
    let structTupV1 = struct (1, "One", 1.0)
    let struct (x, y, z) = struct (1, "One", 1.0)

    0
