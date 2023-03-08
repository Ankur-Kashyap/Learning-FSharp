open System

type Student =
    { Name: string
      Age: int
      RollNo: string }

[<EntryPoint>]
let main args =

    // Validation Functions

    // Student -> Result<Student, string>
    let validateName (student: Student) =
        if String.IsNullOrWhiteSpace(student.Name) then
            Error "Name can't be empty!"
        else
            Ok student

    // Student -> Result<Student, string>
    let validateAge (student: Student) =
        if student.Age < 10 || student.Age > 20 then
            Error "Age must be between 10-20!"
        else
            Ok student

    // Student -> Result<Student, string>
    let validateRollNo (student: Student) =
        if String.IsNullOrWhiteSpace(student.RollNo) then
            Error "Roll number can't be empty!"
        else
            Ok student

    // Student -> Result<Student, string>
    let validateStudent (student: Student) =
        Ok student
        |> Result.bind validateName
        |> Result.bind validateAge
        |> Result.bind validateRollNo

    // Transformation Functions

    let nameToUpper (student: Student) =
        { student with
            Name = student.Name.ToUpper() }

    // Student -> Student
    let agePlus5 (student: Student) = { student with Age = student.Age + 5 }

    // Student -> Student
    let rollnoToUpper (student: Student) =
        { student with
            RollNo = student.RollNo.ToUpper() }

    // Student -> Student
    let transformStudent (student: Student) =
        Ok student
        |> Result.map nameToUpper
        |> Result.map agePlus5
        |> Result.map rollnoToUpper

    // Validation Example 1

    let student =
        { Name = "First Last"
          Age = 10
          RollNo = "Whatever" }

    match validateStudent student with
    | Ok(_) -> "Valid student record."
    | Error(err) -> $"Invalid student record. {err}"
    |> printfn "%s" // Valid student record.

    // Validation Example 2

    let student =
        { Name = ""
          Age = 10
          RollNo = "Whatever" }

    match validateStudent student with
    | Ok(_) -> "Valid student record."
    | Error(err) -> $"Invalid student record. {err}"
    |> printfn "%s" // Invalid student record. Name can't be empty!

    // Validation Example 3

    let student =
        { Name = "First Last"
          Age = 5
          RollNo = "Whatever" }

    match validateStudent student with
    | Ok(_) -> "Valid student record."
    | Error(err) -> $"Invalid student record. {err}"
    |> printfn "%s" // Invalid student record. Age must be between 10-20!

    // Validation Example 4

    let student =
        { Name = "First Last"
          Age = 10
          RollNo = "" }

    match validateStudent student with
    | Ok(_) -> "Valid student record."
    | Error(err) -> $"Invalid student record. {err}"
    |> printfn "%s" // Invalid student record. Roll number can't be empty!

    // Transformation Example

    let student =
        { Name = "First Last"
          Age = 10
          RollNo = "Whatever" }

    match transformStudent student with
    | Ok(student) -> $"{student.Name}, {student.Age}, {student.RollNo}."
    | Error(err) -> $"Invalid student record. {err}"
    |> printfn "%s" // FIRST LAST, 15, WHATEVER.

    0
