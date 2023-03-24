// The basic template for a class.
// Notice the () after Student1, the type name.
// Student1() is the default constructor for type (class) Student1.
type Student1() =
    class

    end

// Class/type Student2.
// The default constructor takes two arguments name and age.
type Student2(name: string, age: int) =
    class
        // This area is actually default constructor's body
        do printfn "Creating Student2 with name: %s" name
        do printfn "Creating Student2 with age: %d" age

        // After the body of the default constructor comes
        // the area for members

        // Additional constructors
        // Must invoke the default constructor
        new() =
            printfn "%s" "new() Invoked."
            Student2("Unknown", 0)

        new(name: string) =
            printfn "%s" "new(name) Invoked."
            Student2(name, 0)

        new(age: int) =
            printfn "%s" "new(age) Invoked."
            Student2("Unknown", age)

        // An instance method.
        // Notice name and age are available.
        // this is the name used to refer to the current instance.
        // You can name it this or anything else.
        member this.NamePlusAge() = $"{name} {age}"

        // Notice this is replaced with current.
        member current.AnotherNamePlusAge() = $"{name} {age}"

        // A static method
        static member Create name age = Student2(name, age)
    end

// The basic template for an Interface.
type INamePlusAge =
    interface
        // A method for derived types to implement.
        abstract member NamePlusAge: unit -> string
    end

// Example of a class implementing an interface.
type Student3(name: string, age: int) =
    class
        // Default constructor body.
        do printfn "%s %d" name age

        // Area for members.

        // Implementation of interface method.

        interface INamePlusAge with
            member this.NamePlusAge() = $"{name} {age}"
    end

// Example of a record implementing an interface
type StudentRecord =
    { Name: string
      Age: int }

    interface INamePlusAge with
        member this.NamePlusAge() = $"{this.Name} {this.Age}"

// Here's an interface with generic type T.
type IGenericIntarfec<'T> =
    interface
        // Methods for derived types to implement.

        abstract member Get: unit -> 'T
        abstract member GetToString: unit -> string
    end

// A class implementing IGenericIntarfec<'T>.
type MyClass<'T>(t: 'T) =
    class
        interface IGenericIntarfec<'T> with
            member this.Get() = t
            member this.GetToString() = t.ToString().ToUpper()
    end

// Example of let bindings within a class.
// Use let bindings for creating provate fields and functions.
type ClassWithLetBindings(name: string, age: int) =
    class
        // 2 private fields and a private function.
        let _name = name
        let _age = age
        let agePlus num = _age + num

        // A private static field.
        static let _a = "A"

        // A private static function.
        static let _add2Nums x y = x + y

        member this.NamePlusAge() = $"{name} {age}"
        member this.YetAnotherNamePlusAge() = $"{_name} {_age}"
        member this.AgePlusNum num = agePlus num
    end

// Example of properties with backing stores.
type ClassWithProperties(name: string, age: int, rollNo: string) =
    class
        let _name = name
        let mutable _age = age
        let mutable _rollNo = rollNo

        // A read-only property.
        member this.Name = _name

        // A write-only property.
        member this.RollNo
            with set (value) = _rollNo <- value

        // A read-write property.
        member this.Age
            with get () = _age
            and set (value) = _age <- value
    end

// Example of properties with no backing stores.
type ClassWithPropertiesWithNoBackingStore(name: string, age: int, rollNo: string) =
    class
        // A read-only property.
        member val Name = name

        // 2 read-write properties.
        member val Age = age with get, set
        member val RollNo = rollNo with get, set
    end

[<EntryPoint>]
let main args =

    0
