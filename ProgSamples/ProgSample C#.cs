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

// ----------------------------------------------------------------------

// ----------------------------------------------------------------------

// ----------------------------------------------------------------------

// ----------------------------------------------------------------------


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



