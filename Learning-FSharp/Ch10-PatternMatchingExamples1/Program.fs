// Number matching with constant values
// If you need to use symbols/names instead of constants like 1, 2
// use Literal attribute
// [<Literal>]
// let One = 1
let constantNumMatching num =
    match num with
    | 1 -> "One"
    | 2 -> "Two"
    | _ -> "No Idea"

// String matching with constant values
let constantStringMatching str =
    match str with
    | "1" -> "One"
    | "2" -> "Two"
    | _ -> "No Idea"

// Discriminated union for int or string or nothing/empty
type IntOrString =
    | IntVal of int
    | StrVal of string
    | NoValue

// Discriminated union matching for cases, IntOrString
let intOrStringMatching1 iOrS =
    match iOrS with
    | IntVal(i) -> $"Found integer value {i}"
    | StrVal(s) -> $"Found string value {s}"
    | NoValue -> "Found nothing!"

// Discriminated union matching for cases, IntOrString
// with condition
let intOrStringMatching2 iOrS =
    match iOrS with
    | IntVal(i) when i = 10 -> $"Found integer value 10."
    | IntVal(i) -> $"Found integer value {i}."
    | StrVal(s) -> $"Found string value {s}"
    | NoValue -> "Found nothing!"

// Discriminated union type Visitor
type Visitor =
    | Employee of name: string * employeeId: string
    | NonEmployee of name: string

// Discriminated union matching for cases, Visitor
let visitorMatching vis =
    match vis with
    | Employee(name, employeeId) -> $"An employee visited. Name: {name}, Id: {employeeId}."
    | NonEmployee(name) -> $"A non-employee visited. Name: {name}."

// Tuple matching / desonctruction
let tupleMatching1 tup =
    match tup with
    | (x, y) -> $"Tuple of two values: {x} and {y}."

// Tuple matching with constant value
let tupleMatching2 tup =
    match tup with
    | (0, y) -> $"First value: 0, second: {y}."
    | (x, 0) -> $"First value {x}, second: 0."
    | _ -> $"Seems both values are non-zero."

// Tuple matching with conditions
let tupleMatching3 tup =
    match tup with
    | (x, y) when x > y -> $"First value ({x}) is > the second ({y})."
    | (x, y) when y > x -> $"Second value ({y}) is > the first ({x})."
    | _ -> $"Seems both values are the same."

// Record type FullName
type FullName = { First: string; Second: string }

// Record matching, FullName
let recordMatching1 fullName =
    match fullName with
    | { First = first; Second = second } -> $"Full name is {first} {second}."

// Record matching with condition
let recordMatching2 fullName searchFirstName =
    match fullName with
    | { First = first; Second = second } when first = searchFirstName ->
        $"{searchFirstName} is a match Full name is {first} {second}."
    | _ -> "First name isn't {searchFirstName}."

[<EntryPoint>]
let main args =

    0
