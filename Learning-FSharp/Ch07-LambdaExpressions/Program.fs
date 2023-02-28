// A function to multiply input by 2
let multBy2 x = x * 2

// Alternate to multBy2, returns a lambda
let multBy2Lambda = fun x -> x * 2

// Applies function f over parameter x
let apply1 f x = f x

// A function to multiply 2 numbers
let mult2Nums x y = x * y

// Alternate to mult2NumsLambda, returns a lambda
let mult2NumsLambda = fun x y -> x * y

// Applies function f over parameter x and y
let apply2 f x y = f x y

[<EntryPoint>]
let main args =

    // next 5 statements produce the same result

    // regular call to a function
    multBy2 10 |> printf "%d"

    // calling the lambda returned by multBy2Lambda
    multBy2Lambda 10 |> printf "%d"

    // in-place function definition, then call
    (fun x -> x * 2) 10 |> printf "%d"

    // calling apply1 for multBy2
    apply1 multBy2 10 |> printf "%d"

    // calling apply1 for multBy2Lambda
    apply1 multBy2Lambda 10 |> printf "%d"

    // calling apply1 for in-place function definition
    apply1 (fun x -> x * 2) 10 |> printf "%d"


    // next 5 statements produce the same result

    // regular call to a function
    mult2Nums 10 20 |> printf "%d"

    // calling the lambda returned by mult2NumsLambda
    mult2NumsLambda 10 20 |> printf "%d"

    // in-place function definition, then call
    (fun x y -> x * y) 10 20 |> printf "%d"

    // calling apply2 for mult2Nums
    apply2 mult2Nums 10 20 |> printf "%d"

    // calling apply2 for mult2NumsLambda
    apply2 mult2NumsLambda 10 20 |> printf "%d"

    // calling apply2 for in-place function definition
    apply2 (fun x y -> x * y) 10 20 |> printf "%d"

    // examples of closure

    let val1 = 10
    let val2 = 20

    // val1, which is used in the lambda expression isn't local to the lambda expression
    // val1 is declared in main, however, when apply1 invokes the lambda expression, val1 is available
    // this is because val1 is supplied to the lambda expression via a closure
    apply1 (fun x -> x * val1) 10 |> printf "%d"

    // similarly, val1 and val2 are supplied to the lambda expression via a closure
    apply2 (fun x y -> x * y * val1 * val2) 10 20 |> printf "%d"

    0
