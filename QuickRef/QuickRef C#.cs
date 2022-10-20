// ==========
// Operators
// ==========

// unary postfix
!
!<term>  unary prefix

// ==============
// Types
// ==============

// String repeat char
string txt = new string("string", n)



// Valid Char Assignments
//
var chars = new[]
{
    'j',        // character literal
    '\u006A',   // Unicode escape sequence        \u
    '\x006A',   // hexadecimal escape sequence    \x
    (char)106,
};

// ============
// Conditionals
// ============
if(statement)
    do this;
else
    do this;

// Ternary
someVar = someFlag ? 'someVal1' : 'someVal2';

// ===========
// Expressions & Statements
// ===========
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions

// <name> = () =>

// Lambda (Expression)
(input-parameters) => expression

// Lambda (Statement)
(input-parameters) => { <sequence-of-statements> }
var squaredNumbers = numbers.Select(x => x * x);

// ==========
// Collection
// ==========
// Words: Array Accessor


// Array
int[] numbers = new int[500];
string[] names = { "Marc", "Alex", "Hanna", "Siri" };
names[1] = "Attila";

for (int i = 0; i < names.Length; i++)
{
    Console.WriteLine(names[i]);
}

for (int i = 0; i < 6; i++)
{
    cells[Random.Shared.Next(0, 9)] = 'X';
}

Array.Fill(ArrayRef, FillWith)

// Array 2-D
char[,] cells = new char[3,3]

cells.GetLength(<dimension> 0)
cells.GetLength(<dimension> 1)


// Jagged - 2 Dimensional of different sizes
string[][] gridJagged = new String[][]

// ==========
// Structures
// ==========


// class

class ClassName
{
    public int X { get; set; } = x;     // field + initialize + getter + setter
}







// struct

// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/structs
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/parameterless-struct-constructors

struct Point
{
    public int x, y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

record struct Person(string Name)
{
    public object Id { get; init; } = GetNextId();
}

record struct Person()
{
    public string Name { get; init; }
    public object Id { get; init; } = GetNextId();
}


readonly record struct ColorPair(ConsoleColor? Foreground, ConsoleColor? Background);

// interface




// ---------
public struct TextPos
{
    public int line { get; init; }
    public int col { get; init; }

    public TextPos(int line, int col)
    {
        this.line = line;
        this.col = col;
    }
}
// ^ SAME AS ᵥ
// RECORD STRUCT
public readonly record struct TextPos(int Line, int Column);


// ==============
//  Abstraction & Composition
// ==============



// ==============
//  Exceptions
// ==============

// throw
throw new ArgumentException("You must supply an argument");
throw new ArgumentException("Parameter cannot be null", nameof(original));
// -----------  ArgumentException Constructors
// ...(string msg, [string nameOfParam])
// ...(string msg, Exception subTypeException),

// ==========
// Directives
// ==========

// https://learn.microsoft.com/en-us/dotnet/csharp/misc/<insert_ID>
// https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs

// ------- Zen Development -------
// "Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable."
#pragma warning disable CS8618
// "Never assigned a value"
#pragma warning disable CS0649
// "Private field never used"
#pragma warning disable CS0414

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable CollectionNeverUpdated.Global



// ==========
// Contexts
// ==========

// nullable https://learn.microsoft.com/en-us/dotnet/csharp/nullable-references#nullable-contexts
// #nullable [disable|enable|restore] [annotations|warnings]
#nullable enable
#nullable enable warnings


// ==========
// Generics
// =======================================================================================================================================
// Constraints on type parameters (C# Programming Guide)
// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
// =======================================================================================================================================
// where T : <symbol>? =
// Constraint
where T : <base class name>
where T : <base class name>?
where T : <interface name>
where T : <interface name>?
where T : class
where T : class?

where T : default
where T : new()
where T : notnull
where T : struct
where T : U

where T : unmanaged
