module Comprehensive

open System
open System.IO

// Student type
type Student =
    { Name: string
      Age: int
      RollNo: string }

/////////////////////
// Try...with Helpers
/////////////////////

// Helper function for 1 param function
// Helper function for trying f when f is 'a -> 'b
// f: ('a -> 'b) -> p: 'a -> Result<'b, exn>
let tryFunc1 f p =
    try
        Ok(f p)
    with ex ->
        Error ex

// Helper function for 2 param function
// Helper function for trying f when f is 'a -> 'b -> 'c
// f: ('a -> 'b -> 'c) -> p1: 'a -> p2: 'b -> Result<'c, exn>
let tryFunc2 f p1 p2 =
    try
        Ok(f p1 p2)
    with ex ->
        Error ex

//////////////////
// IO Functions //
//////////////////

// Wrapper for System.IO.File.ReadAllLines
// May raise exceptions
// string -> string array
// file -> lines
let readAllLinesImpl file = File.ReadAllLines(file)

// Wrapper for System.IO.File.WriteAllLines
// May raise exceptions
// string -> string array -> unit
// file -> lines -> unit
let writeAllLinesImpl file lines = File.WriteAllLines(file, lines)

// Reads the content of given text file as lines
// string -> Result<string array, exn>
let readAllLines = tryFunc1 readAllLinesImpl

// Writes the content (lines) for the specified text file
// string -> string array -> Result<unit, exn>
// file -> lines -> result
let writeAllLines = tryFunc2 writeAllLinesImpl

//////////////////////////
// Validation Functions //
//////////////////////////

// Student -> Result<Student, exn>
let validateName (student: Student) =
    if String.IsNullOrWhiteSpace(student.Name) then
        Error(Exception("Name can't be empty!"))
    else
        Ok student

// Student -> Result<Student, exn>
let validateAge (student: Student) =
    if student.Age < 10 || student.Age > 20 then
        Error(Exception("Age must be between 10-20!"))
    else
        Ok student

// Student -> Result<Student, exn>
let validateRollNo (student: Student) =
    if String.IsNullOrWhiteSpace(student.RollNo) then
        Error(Exception("Roll number can't be empty!"))
    else
        Ok student

//////////////////////////////
// Transformation Functions //
//////////////////////////////

// Student -> Student
let nameToUpper (student: Student) =
    { student with
        Name = student.Name.ToUpper() }

// Student -> Student
let agePlus5 (student: Student) = { student with Age = student.Age + 5 }

// Student -> Student
let rollnoToUpper (student: Student) =
    { student with
        RollNo = student.RollNo.ToUpper() }

/////////////////////////////////////////////////
// string array <-> Student parsing/conversion //
/////////////////////////////////////////////////

// Converts given lines of text to Student
// string array -> Result<Student, exn>
let linesToStudent (lines: string array) =
    let mutable age = 0

    if lines.Length = 3 && Int32.TryParse(lines[1], &age) then
        Ok
            { Name = lines[0]
              Age = age
              RollNo = lines[2] }
    else
        Error(Exception("Failed to parse file content."))

// Converts given student to lines of text
// Student -> string array
let studentToLines (student: Student) =
    [| student.Name; student.Age.ToString(); student.RollNo |]

// Pipeline implementation
// string -> string -> string
let comprehensivePipeline inputFile outputFile =
    readAllLines inputFile
    |> Result.bind linesToStudent
    |> Result.bind validateName
    |> Result.bind validateAge
    |> Result.bind validateRollNo
    |> Result.map nameToUpper
    |> Result.map agePlus5
    |> Result.map rollnoToUpper
    |> Result.map studentToLines
    |> Result.bind (writeAllLines outputFile)
    |> function
        | Ok(_) -> "All Done!"
        | Error(ex) -> $"Failed. {ex.Message}"
