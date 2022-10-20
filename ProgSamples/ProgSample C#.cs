


// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-
// Member access operators and expressions (C# reference)



// ===================
// Null Access
// ===================
// ?. and ?[] operators:
double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
{
    return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
}

var sum1 = SumNumbers(null, 0);
Console.WriteLine(sum1);  // output: NaN

var numberSets = new List<double[]>
{
    new[] { 1.0, 2.0, 3.0 },
    null
};

var sum2 = SumNumbers(numberSets, 0);
Console.WriteLine(sum2);  // output: 6

var sum3 = SumNumbers(numberSets, 1);
Console.WriteLine(sum3);  // output: NaN
// ----------------------------------------------------------------------
int GetSumOfFirstTwoOrDefault(int[] numbers)
{
    if ((numbers?.Length ?? 0) < 2)
    {
        return 0;
    }
    return numbers[0] + numbers[1];
}

Console.WriteLine(GetSumOfFirstTwoOrDefault(null));  // output: 0
Console.WriteLine(GetSumOfFirstTwoOrDefault(new int[0]));  // output: 0
Console.WriteLine(GetSumOfFirstTwoOrDefault(new[] { 3, 4, 5 }));  // output: 7
// ----------------------------------------------------------------------
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
// ?? and ??=
// ----------
// ?? returns the value of its left-hand operand if it isn't null; 
//    otherwise, it evaluates the right-hand operand and returns its result
//
// ??= assigns the value of its right-hand operand to its left-hand operand
//      only if the left-hand operand evaluates to null
// ----------
a ?? b ?? c
d ??= e ??= f
// are evaluated as
a ?? (b ?? c)
d ??= (e ??= f)
// ----------------------------------------------------------------------
double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
{
    return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
}

var sum = SumNumbers(null, 0);
Console.WriteLine(sum);  // output: NaN
// ----------------------------------------------------------------------
int? a = null;
int b = a ?? -1;
Console.WriteLine(b);  // output: -1
// ----------------------------------------------------------------------
public string Name
{
    get => name;
    set => name = value ?? throw new ArgumentNullException(nameof(value), "Name cannot be null");
}
// ----------------------------------------------------------------------
if (variable is null)
{
    variable = expression;
} 
// ^ SAME AS v
variable ??= expression;
// ----------------------------------------------------------------------

// ----------------------------------------------------------------------

// ===========================================================================================
// Lambdas
// ===========================================================================================
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions

int[] numbers = { 2, 3, 4, 5 };
var squaredNumbers = numbers.Select(x => x * x);
Console.WriteLine(string.Join(" ", squaredNumbers));
// Output:
// 4 9 16 25
// ----------------------------------------------------------------------
Action<string> greet = name =>
{
    string greeting = $"Hello {name}!";
    Console.WriteLine(greeting);
};
greet("World");
// Output:
// Hello World!
// ----------------------------------------------------------------------
Action line = () => Console.WriteLine();
// --
Func<double, double> cube = x => x * x * x;
// --
Func<int, int, bool> testForEquality = (x, y) => x == y;
// --
Func<int, string, bool> isTooLong = (int x, string s) => s.Length > x;
// --
Func<int, int, int> constant = (_, _) => 42;

// ----------------------------------------------------------------------
// https://stackoverflow.com/questions/43082026/c-sharp-7-tuples-and-lambdas

var list = new List<(int x, int y)>();
list.Select(t => t.x * 2 + t.y / 2)
// ----------------------------------------------------------------------
// Deconstructions in C# 7.0 support three forms: 
//   deconstruction-declaration     (like (var x, var y) = e;),
//   deconstruction-assignment      (like (x, y) = e;),
//   and deconstruction-foreach     (like foreach(var(x, y) in e) ...).
// ----------------------------------------------------------------------
list.Select<(int x, int y), int>(t => t.x * 2 + t.y / 2);
// ----------------------------------------------------------------------
// https://livebook.manning.com/book/c-sharp-in-depth-fourth-edition/chapter-9/v-8/18
// ...




// Array Definition
    AsReadOnly
    BinarySearch
    Clear
    Clone
    ConstrainedCopy
    ConvertAll
    Copy
    CopyTo
    CreateInstance
    Empty
    Exists
    Fill
    Find
    FindAll
    FindIndex
    FindLast
    FindLastIndex
    ForEach
    GetEnumerator
    GetLength
    GetLongLength
    GetLowerBound
    GetUpperBound
    GetValue
    IndexOf
    Initialize
    LastIndexOf
    Resize
    Reverse
    SetValue
    Sort
    TrueForAll


// ----------------------------------------------------------------------








// How can i add property to a class dynamically
// Runtime Shenanigans

// https://stackoverflow.com/questions/2244617/how-can-i-add-property-to-a-class-dynamically
public interface IError { }

public class ErrorTypeA : IError
{ public string Name; }

public class ErrorTypeB : IError
{
    public string Name;
    public int line;
}

public void CreateErrorObject()
{
    IError error;
    if (FileNotFoundException) // put your check here
    {
        error = new ErrorTypeA
            {
                Name = ""
            };
    }
    elseif (InValidOpertionException) // put your check here
    {
        error = new ErrorTypeB
        {
            Name = "",
            line = 1
        };
    }
}

// ----------------------------------------------------------------------
// https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.expandoobject?view=net-7.0
ExpandoObject











// Range

https://stackoverflow.com/questions/3188672/how-to-elegantly-check-if-a-number-is-within-a-range
1 <= x && x <= 100

x is >= 1 and <= 100








// ----------------------------------------------------------
// https://www.tutorialsteacher.com/csharp/csharp-action-delegate
// C# - Action Delegate
// Example: C# Delegate 

// ----------------------------------------------------------
// https://www.tutorialsteacher.com/csharp/csharp-predicate
// C# - Predicate Delegate
//  Example: Predicate delegate
static bool IsUpperCase(string str)
{
    return str.Equals(str.ToUpper());
}

static void Main(string[] args)
{
    Predicate<string> isUpper = IsUpperCase;

    bool result = isUpper("hello world!!");

    Console.WriteLine(result);
}
// ----------------------------------------------------------
// Example: Predicate delegate with anonymous method
static void Main(string[] args)
{
    Predicate<string> isUpper = delegate(string s) { return s.Equals(s.ToUpper());};
    bool result = isUpper("hello world!!");
}
// ----------------------------------------------------------
// Example: Predicate delegate with lambda expression
static void Main(string[] args)
{
    Predicate<string> isUpper = s => s.Equals(s.ToUpper());
    bool result = isUpper("hello world!!");
    
    
    
    
    
    
    
    
    
    
    
    
    
// Assign while comparing
    
// https://stackoverflow.com/questions/7113347/assignment-in-an-if-statement
if (animal is Dog dog)
{
    // ...
}
    
    
Dog dog = animal as Dog;
if (dog != null)
{
    // ...
}

string line;
while ( (line = reader.ReadLine() ) != null)
{
    /* ... */
}
    
    
// Getters and Setters
// https://stackoverflow.com/questions/5274752/properties-by-value-or-reference

// Generated "under-the-hood" code example

// this is how the getter method looks like
public ArrayList get_SpillageRiskDescriptions()
{
    return _SpillageRiskDescriptions;
}

// this is how the setter method looks like
public void set_SpillageRiskDescriptions(ArrayList value)
{
    _SpillageRiskDescriptions = value;
}
    
    
// https://stackoverflow.com/questions/5009823/c-sharp-getter-and-setter-shorthand    

private bool IsDirty { get; set; }

private int _myInt; // Doesn't need to be a property
Public int MyInt {
    get{return _myInt;}
    set{_myInt = value; IsDirty = true;}
}
}







// ================================================================================
// ======== Pattern Matching ======================================================
// ================================================================================

// https://stackoverflow.com/questions/59361400/is-this-pattern-matching-expression-equivalent-to-not-null

// The pattern-matching in C# supports property pattern matching. e.g.

// --------
[cs]
if (requestHeaders is HttpRequestHeader {X is 3, Y is var y})

// The semantics of a property pattern is that it first tests if the input is non-null. 
// so it allows you to write:
if (requestHeaders is {}) // will check if object is not null

// You can write the same type checking in any of the following manner that will provide a Not Null Check included:
if (s is object o) /*...*/  // o is of type object
if (s is string x) /*...*/  // x is of type string
if (s is {} x)     /*...*/  // x is of type string
if (s is {})       /*...*/
[/cs]





// Declaration Pattern         Declaration and type patterns
// Declaration Pattern         Declaration and type patterns
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#declaration-and-type-patterns

object greeting = "Hello, World!";
if (greeting is string message)
{
    Console.WriteLine(message.ToLower());  // output: hello, world!
}

// --------
var numbers = new int[] { 10, 20, 30 };
Console.WriteLine(GetSourceLabel(numbers));  // output: 1

var letters = new List<char> { 'a', 'b', 'c', 'd' };
Console.WriteLine(GetSourceLabel(letters));  // output: 2

static int GetSourceLabel<T>(IEnumerable<T> source) => source switch
{
    Array array => 1,
    ICollection<T> collection => 2,
    _ => 3,
};
// -----------------------------

int? xNullable = 7;
int y = 23;
object yBoxed = y;
if (xNullable is int a && yBoxed is int b)
{
    Console.WriteLine(a + b);  // output: 30
}

// -----------------------------

public abstract class Vehicle {}
public class Car : Vehicle {}
public class Truck : Vehicle {}

public static class TollCalculator
{
    public static decimal CalculateToll(this Vehicle vehicle) => vehicle switch
    {
        Car _ => 2.00m,
        Truck _ => 7.50m,
        null => throw new ArgumentNullException(nameof(vehicle)),
        _ => throw new ArgumentException("Unknown type of a vehicle", nameof(vehicle)),
    };
}

// -----------------------------

public static decimal CalculateToll(this Vehicle vehicle) => vehicle switch
{
    Car => 2.00m,
    Truck => 7.50m,
    null => throw new ArgumentNullException(nameof(vehicle)),
    _ => throw new ArgumentException("Unknown type of a vehicle", nameof(vehicle)),
};

// -----------------------------

if (input is not null)
{
    Console.WriteLine(input);
} else
{
    throw new ArgumentNullException(paramName: nameof(input), message: "Input should not be null");
}

// -----------------------------

// In a constant pattern, you can use any constant expression, such as:
    // an integer or floating-point numerical literal
    // a char
    // a string literal.
    // a Boolean value true or false
    // an enum value
    // the name of a declared const field or local
    // null
public static decimal GetGroupTicketPrice(int visitorCount) => visitorCount switch
{
    1 => 12.0m,
    2 => 20.0m,
    3 => 27.0m,
    4 => 32.0m,
    0 => 0.0m,
    _ => throw new ArgumentException($"Not supported number of visitors: {visitorCount}", nameof(visitorCount)),
};

// The expression must be a type that is convertible to the constant type, 
// with one exception: 
//      An expression whose type is Span<char> or ReadOnlySpan<char> can be matched against constant strings in C# 11 and later versions.


// -----------------------------
if (input is null)
{
    return;
}
// -----------------------------

if (input is not null)
{
    // ...
}



// ----------- Relational Patterns -----------
// Beginning with C# 9.0, you use a relational pattern to compare an expression result with a constant, as the following example shows:
Console.WriteLine(Classify(13));  // output: Too high
Console.WriteLine(Classify(double.NaN));  // output: Unknown
Console.WriteLine(Classify(2.4));  // output: Acceptable

static string Classify(double measurement) => measurement switch
{
    < -4.0 => "Too low",
    > 10.0 => "Too high",
    double.NaN => "Unknown",
    _ => "Acceptable",
};

// n a relational pattern, you can use any of the relational operators 
// <, >, <=, or >=. 
// The right-hand part of a relational pattern must be a constant expression.
// The constant expression can be of an integer, floating-point, char, or enum type.


// -----------
// To check if an expression result is in a certain range, match it against a conjunctive and pattern, as the following example shows:
Console.WriteLine(GetCalendarSeason(new DateTime(2021, 3, 14)));  // output: spring
Console.WriteLine(GetCalendarSeason(new DateTime(2021, 7, 19)));  // output: summer
Console.WriteLine(GetCalendarSeason(new DateTime(2021, 2, 17)));  // output: winter

static string GetCalendarSeason(DateTime date) => date.Month switch
{
    >= 3 and < 6 => "spring",
    >= 6 and < 9 => "summer",
    >= 9 and < 12 => "autumn",
    12 or (>= 1 and < 3) => "winter",
    _ => throw new ArgumentOutOfRangeException(nameof(date), $"Date with unexpected month: {date.Month}."),
};

If an expression result is null or fails to convert to the type of a constant by a nullable or unboxing conversion, a relational pattern doesn't match an expression.

For more information, see the Relational patterns section of the feature proposal note.
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/patterns3#relational-patterns




// ------------------- Logical Patterns -------------------
// Logical patterns

// Beginning with C# 9.0, you use the not, and, and or pattern combinators to create the following logical patterns:
// Negation not pattern that matches an expression when the negated pattern doesn't match the expression. The following example shows how you can negate a constant null pattern to check if an expression is non-null:

if (input is not null)
{
    // ...
}

// ----------------------

// Conjunctive and pattern that matches an expression when both patterns match the expression. The following example shows how you can combine relational patterns to check if a value is in a certain range:

Console.WriteLine(Classify(13));  // output: High
Console.WriteLine(Classify(-100));  // output: Too low
Console.WriteLine(Classify(5.7));  // output: Acceptable

static string Classify(double measurement) => measurement switch
{
    < -40.0 => "Too low",
    >= -40.0 and < 0 => "Low",
    >= 0 and < 10.0 => "Acceptable",
    >= 10.0 and < 20.0 => "High",
    >= 20.0 => "Too high",
    double.NaN => "Unknown",
};

// ------------------

// Disjunctive or pattern that matches an expression when either pattern matches the expression, as the following example shows:
Console.WriteLine(GetCalendarSeason(new DateTime(2021, 1, 19)));  // output: winter
Console.WriteLine(GetCalendarSeason(new DateTime(2021, 10, 9)));  // output: autumn
Console.WriteLine(GetCalendarSeason(new DateTime(2021, 5, 11)));  // output: spring

static string GetCalendarSeason(DateTime date) => date.Month switch
{
    3 or 4 or 5 => "spring",
    6 or 7 or 8 => "summer",
    9 or 10 or 11 => "autumn",
    12 or 1 or 2 => "winter",
    _ => throw new ArgumentOutOfRangeException(nameof(date), $"Date with unexpected month: {date.Month}."),
};

// -----------------

// Precedence and order of checking
// 
// The following list orders pattern combinators starting from the highest precedence to the lowest:
// 
    // not
    // and
    // or

// -----------------
// To explicitly specify the precedence, use parentheses, as the following example shows:
// 
// static bool IsLetter(char c) => c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z');

// For more information, see the Pattern combinators section of the feature proposal note.
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/patterns3#pattern-combinators

// ----------------------- Property pattern ----------------------- 
// (Same as above) https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#declaration-and-type-patterns



// A property pattern matches an expression when an expression result is non-null and every nested pattern matches the corresponding property or field of the expression result.

// You can also add a run-time type check and a variable declaration to a property pattern, as the following example shows:

static bool IsConferenceDay(DateTime date) => date is { Year: 2020, Month: 5, Day: 19 or 20 or 21 };

Console.WriteLine(TakeFive("Hello, world!"));  // output: Hello
Console.WriteLine(TakeFive("Hi!"));  // output: Hi!
Console.WriteLine(TakeFive(new[] { '1', '2', '3', '4', '5', '6', '7' }));  // output: 12345
Console.WriteLine(TakeFive(new[] { 'a', 'b', 'c' }));  // output: abc

static string TakeFive(object input) => input switch
{
    string { Length: >= 5 } s => s.Substring(0, 5),
    string s => s,

    ICollection<char> { Count: >= 5 } symbols => new string(symbols.Take(5).ToArray()),
    ICollection<char> symbols => new string(symbols.ToArray()),

    null => throw new ArgumentNullException(nameof(input)),
    _ => throw new ArgumentException("Not supported input type."),
};
// -----------------

// A property pattern is a recursive pattern. That is, you can use any pattern as a nested pattern. Use a property pattern to match parts of data against nested patterns, as the following example shows:

public record Point(int X, int Y);
public record Segment(Point Start, Point End);

static bool IsAnyEndOnXAxis(Segment segment) =>
    segment is { Start: { Y: 0 } } or { End: { Y: 0 } };
    
// The preceding example uses two features available in C# 9.0 and later: or pattern combinator and record types.


// -----------------
// Beginning with C# 10, you can reference nested properties or fields within a property pattern. This is known as an extended property pattern. For example, you can refactor the method from the preceding example into the following equivalent code:
static bool IsAnyEndOnXAxis(Segment segment) =>
    segment is { Start.Y: 0 } or { End.Y: 0 };



// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/patterns#property-pattern
    
// ------ Extended Property Patterns ------
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/extended-property-patterns
// Allows:
if (e is MethodCallExpression { Method.Name: "MethodName" })
// instead of 
if (e is MethodCallExpression { Method: { Name: "MethodName" } })

// { Prop1.Prop2: pattern } is exactly equivalent to { Prop1: { Prop2: pattern } }

// Note that this will include the null check when T is a nullable value type or a reference type. This null check means that the nested properties available will be the properties of T0, not of T.
// Repeated member paths are allowed. The compilation of pattern matching can take advantage of common parts of patterns