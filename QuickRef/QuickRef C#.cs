// ==========
// Operators
// ==========

// unary postfix
! 
!<term>  unary prefix 

// Types



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
someVar= someFlag ? 'someVal1' : 'someVal2';






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


// ==========
// Directives   
// ==========

// ==========
// Contexts   
// ==========

// nullable https://learn.microsoft.com/en-us/dotnet/csharp/nullable-references#nullable-contexts
// #nullable [disable|enable|restore] [annotations|warnings]
#nullable enable
#nullable enable warnings
