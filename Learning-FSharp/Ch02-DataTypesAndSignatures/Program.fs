(*
  The purpose of this example is to discuss the basic data types and function signatures.

  For comprehensive list of primitive data types visit:
  https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/basic-types

  Variable and Functions are defined using what's known as 'let bindings' in F#.

  let someVariable = ...
  let someFunction param1 param2 = ...

  let someVariable ===> This creates an immutable value. Meaning, it can't be changed.

  Mutable variables can be created (let mutable someVariable = ..., and someVariable <- newValue),
  however, it's a rare occurrence in well-written F# code.
  Immutability is a very odd idea for imperative programmers.
  As we discuss more and more topics in this series, we will discover how to write without immutability.
*)

[<EntryPoint>]
let main args =
    // Both x & y are of type int.
    // In case of let x = 10, F# compiler does the type detection.
    let x = 10
    let y: int = 10

    // Boolean (true/false) data type.
    let boolV1 = false
    let boolV2: bool = true

    // Unsigned 8-bit integer. 0 to 255.
    // Postfix: uy.
    let byteV1 = 1uy
    let byteV2: byte = 2uy

    // Signed 8-bit integer. -128 to 127.
    // Postfix: y.
    let sbyteV1 = 1y
    let sbyteV2: sbyte = 2y

    // Unsigned 16-bit integer. 0 to 65,535.
    // Postfix: us.
    let uint16V1 = 1us
    let uint16V2: uint16 = 2us

    // Signed 16-bit integer. 32,768 to 32,767.
    // Postfix: s.
    let int16V1 = 1s
    let int16V2: int16 = 2s

    // Unsigned 32-bit integer. 0 to 4,294,967,295.
    // Postfix: u.
    let uintV1 = 1u
    let uintV1: uint = 2u
    let uintV1: uint32 = 3u

    // Signed 32-bit integer. -2,147,483,648 to 2,147,483,647.
    let intV1 = 1
    let intV1: int = 2
    let intV1: int32 = 3

    // Unsigned 64-bit integer. 0 to 18,446,744,073,709,551,615.
    // Postfix: uL/UL.
    let uint64V1 = 1uL
    let uint64V1: uint64 = 2uL

    // Signed 64-bit integer. -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807.
    // Postfix: L.
    let int64V1 = 1L
    let int64V1: int64 = 2L

    // 32-bit floating point type.
    // Postfix: F.
    let floatingV1 = 1.0F
    let floatingV2: float32 = 2.0F
    let floatingV3: single = 3.0F

    // 64-bit floating point type.
    let floatingV1 = 1.0
    let floatingV2: float = 2.0
    let floatingV3: double = 3.0

    // A unicode character (UTF-16 code unit).
    let charV1 = 'A'
    let charV2: char = 'B'

    // A string value.
    let stringV1 = "AAA"
    let stringV2: string = "BBB"

    // Unit type. Absence of data.
    // Only one possible value: ().
    // Often () is compared with void (as in C++/C#/Java), however, that is not the best representation of the idea.
    // More on this in the later chapters.
    let unitV1 = ()
    let uintV2: unit = ()

    // A function which adds 2 integers.
    // Parameters are space separated.
    // add2NumsV1 has no type declerations. Not for x, not for y and not for the return value.
    // F# compiler does the type detection.
    // add2NumsV2 has explicit type decleration for x, y and the return value.
    // let add2NumsV2 (x: int) (y: int) : int =
    //                  ^        ^      ^
    // The signature of both these functions is:
    // int -> int -> int
    // This style of signatures is very confusing for those who are new to functional programming.
    // So, go slow. It will all make sense.
    let add2NumsV1 x y = x + y
    let add2NumsV2 (x: int) (y: int) : int = x + y

    // A function which converts any given value to string.
    // The signature of this function is:
    // 'a -> string
    // 'a indicates a generic paramater. More on generics in the later chapters.
    // Simply put, pass anything to this function.
    // You may wonder how ToString() contextual method call is available when the type of parameter anything isn't known.
    // That's because everything in .NET is driven from object. ToString is inheritied from the root class.
    let anythingToStringV1 anything = anything.ToString()
    let anythingToStringV1 (anything: 'a) : string = anything.ToString()

    // A function which converts any given string to upper-case.
    // The signature of this function is:
    // string -> string
    let toUpperV1 (anyString: string) = anyString.ToUpper()
    let toUpperV2 (anyString: string) : string = anyString.ToUpper()

    // Here's is an example which won't compile.
    // Why? Because the F# compiler has no definite way of figuring out the type of
    // anyString parameter based on the body of function.
    // let toUpper anyString = anyString.ToUpper()

    // This is an examle of a function that takes unit as input and outputs a unit/
    // The signature of this function is:
    // unit -> unit
    // This may seem like the following C++/C#/Java function:
    // void typicalVoidFromImperativeWorld(){}
    let typicalVoidFromImperativeWorld () = ()

    // Here is another function with signature unit -> unit.
    // Notice the last line in the function body.
    // Return value should be the last expression in the function.
    let printCurrentDateTime () =
        System.Console.WriteLine System.DateTime.Now
        ()

    // Here is a function with signature int -> unit.
    let printNumber n =
        printfn "%d" n
        ()

    0
