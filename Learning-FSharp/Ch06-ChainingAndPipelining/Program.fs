// A function to multiply input by 2
let multBy2 x = x * 2

// A function to add 2 to input
let add2 x = x + 2

// Forward chain, call multBy2 and then add2
let forwardChain = multBy2 >> add2

// Backward chain, call add2 and then multBy2
let backwardChain = multBy2 << add2

[<EntryPoint>]
let main args =

    // Invoking forwardChain
    // add2 (multBy2 3))
    // prints 8
    forwardChain 3 |> printfn "%d"

    // Invoking backwardChain
    // multBy2 (add2 3))
    // prints 10
    backwardChain 3 |> printfn "%d"

    // prints 8
    3 |> multBy2 |> add2 |> printfn "%d"

    // prints 8
    printfn "%d" <| (add2 <| (multBy2 <| 3))

    0
