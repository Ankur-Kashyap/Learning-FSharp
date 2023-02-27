// A regular function with 2 parameters
let add2Nums x y = x + y

// Alternative to add2Nums
// Forced currying version 1 (using inner function)
let add2NumsCurriedV1 x =
    let inner y = x + y
    inner

// Alternative to add2Nums
// Forced currying version 2 (using lambda)
let add2NumsCurriedV2 x = fun y -> x + y

// A 3 parameter function
let add3Nums x y z = x + y + z

[<EntryPoint>]
let main args =

    // add2Nums called in the regular way
    // result is 3
    let result: int = add2Nums 1 2

    // Partial application of add2Nums, only first parameter supplied
    // add1 is function of type int -> int
    let add1: int -> int = add2Nums 1

    // Calling add1 with 2
    // result is 3
    let result: int = add1 2


    let result = add3Nums 1 2 3 // Application
    let result = add3Nums 1 // Partial application, just one parameter
    let result = add3Nums 1 2 // Partial application, two parameters

    0
