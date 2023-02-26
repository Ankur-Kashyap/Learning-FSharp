(*
  This is a multi-line comment.
*)

// This is a single-line comment.

// The program entry-point function.
[<EntryPoint>]
let main args =

    (*
      Function parameters are passed with space as the separator.
      The code below shows calls to printfn and System.Console.WriteLine.

      Notice the indentation. Function body must be indented, otherwise the code won't compile.
    *)

    // F#'s way of writing to standard output.
    // More details on printfn are available in later chapters.
    printfn "%s" "Hello World!"

    // C#'s way of writing to standard output, The .NET library is accessible in F#.
    // The fully-qualified name System.Console.WriteLine can be replaced with Console.WriteLine
    // by including/opening the namespace with: open System
    System.Console.WriteLine "Hello World!"

    (*
      The below given 2 lines of code are examples of partial functions and pipelining.
      Both these concepts are addressed in later chapters.

      Simply put, "Hello World!", which is on the left side of |> operator becomes last parameter
      to what's on the right side of |> operator.

      "Hello World!" |> printfn "%s" ===> printfn "%s" "Hello World!"
      "Hello World!" |> System.Console.WriteLine ===> System.Console.WriteLine "Hello World!"
    *)

    "Hello World!" |> printfn "%s"
    "Hello World!" |> System.Console.WriteLine

    // The return value of function. No special keyword required.
    // Return value should be the last expression in the function.
    0
