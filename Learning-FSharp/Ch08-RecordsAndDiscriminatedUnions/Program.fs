// Type alias for string
type MyString = string

// Type alias for function
type MapFunc<'a, 'b> = 'a -> 'b

// Record definition
// Separate members of the record by ; when defining everything in a single line
type FullName = { First: string; Last: string }

// Record definition
// When spread over multiplt lines, no ; needed between members
type Student =
    { Name: FullName
      Age: int
      RollNo: string }

// Record definition
// With members functions
type Employee =
    { Name: FullName
      Age: int
      EmployeeId: string }

    // static member
    static member Create(first, last, age, employeeId) =
        { Name = { First = first; Last = last }
          Age = age
          EmployeeId = employeeId }

    // overridden Object.ToString
    override this.ToString() =
        $"Name: {this.Name}, Age: {this.Age}, RollNo: {this.EmployeeId}"

    // Instance member
    member this.WithNameInUpperCase() =
        { this with
            Name =
                { First = this.Name.First.ToUpper()
                  Last = this.Name.Last.ToUpper() } }

// Discriminated union of int and string
type IntOrString =
    | I of int
    | S of string

// Discriminated union of int and Employee type created earlier
type IntOrEmployee =
    | I of int
    | E of Employee

// Discriminated union of int and tuple (int * int)
type IntOrTuple =
    | I of int
    | T of int * int

// Discriminated union for days
type Day =
    | Monday
    | Tuesday
    | Wednesday
    | Thursday
    | Friday
    | Saturday
    | Sunday

// Discriminated union for payment info
// Each case has different fields associated with it
type PaymentInfo =
    | Cash
    | Card of cardNumber: string
    | BankCheque of bankName: string * chequeNumber: string * chequeDate: System.DateTime

// Single-case discriminated union
// Typically used for having specific data types in domain modeling
type EmployeeId = EmployeeId of string

[<EntryPoint>]
let main args =

    // Using type alias MyString
    let str: string = ""
    let myStr: MyString = str
    let myStr: MyString = "whatever"

    // Not a very helpful example, but demonstrates the idea
    // Using generic MapFunc<'a, 'b>
    let intToString (mapper: MapFunc<int, string>) i = mapper i

    // Record construction / FullName
    let fullName = { First = "John"; Last = "Doe" }

    // Record updation
    let newName = { fullName with First = "Jane" }

    // Reocrd construction / Student
    let student =
        { Name = { First = "John"; Last = "Doe" }
          Age = 10
          RollNo = "123456" }

    // Record updation
    let newStudent =
        { student with
            Name = { First = "Jane"; Last = "Doe" } }

    // Reocrd construction / Employee
    let employee =
        { Name = { First = "John"; Last = "Doe" }
          Age = 10
          EmployeeId = "123456" }

    // Discriminated union construction IntOrTuple
    let iOrT1 = I(1)
    let iOrT2 = T(1, 2)

    // If you are wondering what is I(1) referring to... IntOrString or IntOrEmployee or IntOrTuple?
    // The answer is IntOrTuple, becomes it is declared later.
    // Avoid name clashes or use full names

    let iOrT3 = IntOrString.I 1

    let paymentInfo1 = Cash
    let paymentInfo2 = Card("1234-1234-1234-1234")
    let paymentInfo1 = BankCheque("Broke Bank", "123456", System.DateTime.Now)

    0
      