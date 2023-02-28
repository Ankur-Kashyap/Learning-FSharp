// A function to multiply input by 2
let multBy2 x = x * 2

// A function to add 2 to input
let add2 x = x + 2

// Forward chain, call multBy2 and then add2
let forwardChain = multBy2 >> add2

// Backward chain, call add2 and then multBy2
let backwardChain = multBy2 << add2

// A 2 parameter function
let add2Nums x y = x + y

// A 3 parameter function
let add3Nums x y z = x + y + z

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

    // Pipeline

    // prints 8
    3 |> multBy2 |> add2 |> printfn "%d"

    // prints 8
    printfn "%d" <| (add2 <| (multBy2 <| 3))

    // Passing a 2 value tuple to a 2 parameter function

    // prints 5
    (2, 3) ||> add2Nums |> printfn "%d"

    // prints 5
    printfn "%d" <| (add2Nums <|| (2, 3))

    // Passing a 3 value tuple to a 3 parameter function

    // prints 9
    (2, 3, 4) |||> add3Nums |> printfn "%d"

    // prints 9
    printfn "%d" <| (add3Nums <||| (2, 3, 4))

    0
