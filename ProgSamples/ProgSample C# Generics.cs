
// =======================================================================================================================================
// https://stackoverflow.com/questions/14150508/how-to-get-null-instead-of-the-keynotfoundexception-accessing-dictionary-value-b
// How to get null instead of the KeyNotFoundException accessing Dictionary value by key?
// =======================================================================================================================================

// Implementation
public static TV GetValue<TK, TV>(this IDictionary<TK, TV> dict, TK key, TV defaultValue = default(TV))
{
    TV value;
    return dict.TryGetValue(key, out value) ? value : defaultValue;
}

// ---
// Usage
MyDictionary.GetValue("key1");
 MyDictionary.GetValue("key2", -1);
 MyDictionary.GetValue("key3")?.SomeMethod();

// ---------------------------------------------------------------------------------------------------------------------------------------

public static U Get<T, U>(this Dictionary<T, U> dict, T key)
    where U : class
{
    U val;
    dict.TryGetValue(key, out val);
    return val;
}

// ---------------------------------------------------------------------------------------------------------------------------------------

public interface INullValueDictionary<T, U>
    where U : class
{
    U this[T key] { get; }
}

public class NullValueDictionary<T, U> : Dictionary<T, U>, INullValueDictionary<T, U>
    where U : class
{
    U INullValueDictionary<T, U>.this[T key]
    {
        get
        {
            U val;
            this.TryGetValue(key, out val);
            return val;
        }
    }
}


//create some dictionary
NullValueDictionary<int, string> dict = new NullValueDictionary<int, string>
{
    {1,"one"}
};
//have a reference to the interface
INullValueDictionary<int, string> idict = dict;

try
{
    //this throws an exception, as the base class implementation is utilized
    Console.WriteLine(dict[2] ?? "null");
}
catch { }
//this prints null, as the explicit interface implementation
//in the derived class is used
Console.WriteLine(idict[2] ?? "null");


// =======================================================================================================================================
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/where-generic-type-constraint
// where (generic type constraint) (C# Reference)
// =======================================================================================================================================

// 'where' clause in a generic definition specifies constraints on the types that are used as arguments for type parameters in a generic type, method, delegate, or local function

public class AGenericClass<T> where T : IComparable<T> { }

// ---------------------------------------------------------------------------------------------------------------------------------------

public class UsingEnum<T> where T : System.Enum { }

public class UsingDelegate<T> where T : System.Delegate { }

public class Multicaster<T> where T : System.MulticastDelegate { }

// ---------------------------------------------------------------------------------------------------------------------------------------

class MyClass<T, U>
    where T : class
    where U : struct
{ }

// ---------------------------------------------------------------------------------------------------------------------------------------

public abstract class B
{
    public void M<T>(T? item) where T : struct { }
    public abstract void M<T>(T? item);

}

// ---------------------------------------------------------------------------------------------------------------------------------------

public class D : B
{
    // Without the "default" constraint, the compiler tries to override the first method in B
    public override void M<T>(T? item) where T : default { }
}

// ---------------------------------------------------------------------------------------------------------------------------------------

#nullable enable
    class NotNullContainer<T>
        where T : notnull
    {
    }
#nullable restore

// ---------------------------------------------------------------------------------------------------------------------------------------

class UnManagedWrapper<T>
    where T : unmanaged
{ }

// ---------------------------------------------------------------------------------------------------------------------------------------

public class MyGenericClass<T> where T : IComparable<T>, new()
{
    // The following line is not possible without new() constraint:
    T item = new T();
}

// ---------------------------------------------------------------------------------------------------------------------------------------

public interface IMyInterface { }

namespace CodeExample
{
    class Dictionary<TKey, TVal>
        where TKey : IComparable<TKey>
        where TVal : IMyInterface
    {
        public void Add(TKey key, TVal val) { }
    }
}

// ---------------------------------------------------------------------------------------------------------------------------------------

public void MyMethod<T>(T t) where T : IMyInterface { }

// ---------------------------------------------------------------------------------------------------------------------------------------

delegate T MyDelegate<T>() where T : new();

// ---------------------------------------------------------------------------------------------------------------------------------------


// =======================================================================================================================================
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/where-generic-type-constraint
// where clause (C# Reference)
// =======================================================================================================================================
// The where clause is used in a query expression to specify which elements from the data source will be returned in the query expression.
// It applies a Boolean condition (predicate) to each source element (referenced by the range variable) and returns those for which the specified condition is true.
// A single query expression may contain multiple where clauses and a single clause may contain multiple predicate subexpressions.



// =======================================================================================================================================
// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-interfaces
// Generic Interfaces (C# Programming Guide)
// =======================================================================================================================================

// When an interface is specified as a constraint on a type parameter, only types that implement the interface can be used.


//Type parameter T in angle brackets.
public class GenericList<T> : System.Collections.Generic.IEnumerable<T>
{
    protected Node head;
    protected Node current = null;

    // Nested class is also generic on T
    protected class Node
    {
        public Node next;
        private T data;  //T as private member datatype

        public Node(T t)  //T used in non-generic constructor
        {
            next = null;
            data = t;
        }

        public Node Next
        {
            get { return next; }
            set { next = value; }
        }

        public T Data  //T as return type of property
        {
            get { return data; }
            set { data = value; }
        }
    }

    public GenericList()  //constructor
    {
        head = null;
    }

    public void AddHead(T t)  //T as method parameter type
    {
        Node n = new Node(t);
        n.Next = head;
        head = n;
    }

    // Implementation of the iterator
    public System.Collections.Generic.IEnumerator<T> GetEnumerator()
    {
        Node current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    // IEnumerable<T> inherits from IEnumerable, therefore this class
    // must implement both the generic and non-generic versions of
    // GetEnumerator. In most cases, the non-generic method can
    // simply call the generic method.
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class SortedList<T> : GenericList<T> where T : System.IComparable<T>
{
    // A simple, unoptimized sort algorithm that
    // orders list elements from lowest to highest:

    public void BubbleSort()
    {
        if (null == head || null == head.Next)
        {
            return;
        }
        bool swapped;

        do
        {
            Node previous = null;
            Node current = head;
            swapped = false;

            while (current.next != null)
            {
                //  Because we need to call this method, the SortedList
                //  class is constrained on IComparable<T>
                if (current.Data.CompareTo(current.next.Data) > 0)
                {
                    Node tmp = current.next;
                    current.next = current.next.next;
                    tmp.next = current;

                    if (previous == null)
                    {
                        head = tmp;
                    }
                    else
                    {
                        previous.next = tmp;
                    }
                    previous = tmp;
                    swapped = true;
                }
                else
                {
                    previous = current;
                    current = current.next;
                }
            }
        } while (swapped);
    }
}

// A simple class that implements IComparable<T> using itself as the
// type argument. This is a common design pattern in objects that
// are stored in generic lists.
public class Person : System.IComparable<Person>
{
    string name;
    int age;

    public Person(string s, int i)
    {
        name = s;
        age = i;
    }

    // This will cause list elements to be sorted on age values.
    public int CompareTo(Person p)
    {
        return age - p.age;
    }

    public override string ToString()
    {
        return name + ":" + age;
    }

    // Must implement Equals.
    public bool Equals(Person p)
    {
        return (this.age == p.age);
    }
}

public class Program
{
    public static void Main()
    {
        //Declare and instantiate a new generic SortedList class.
        //Person is the type argument.
        SortedList<Person> list = new SortedList<Person>();

        //Create name and age values to initialize Person objects.
        string[] names = new string[]
        {
            "Franscoise",
            "Bill",
            "Li",
            "Sandra",
            "Gunnar",
            "Alok",
            "Hiroyuki",
            "Maria",
            "Alessandro",
            "Raul"
        };

        int[] ages = new int[] { 45, 19, 28, 23, 18, 9, 108, 72, 30, 35 };

        //Populate the list.
        for (int x = 0; x < 10; x++)
        {
            list.AddHead(new Person(names[x], ages[x]));
        }

        //Print out unsorted list.
        foreach (Person p in list)
        {
            System.Console.WriteLine(p.ToString());
        }
        System.Console.WriteLine("Done with unsorted list");

        //Sort the list.
        list.BubbleSort();

        //Print out sorted list.
        foreach (Person p in list)
        {
            System.Console.WriteLine(p.ToString());
        }
        System.Console.WriteLine("Done with sorted list");
    }
}

// ---------------------------------------------

// Multiple interfaces can be specified as constraints on a single type, as follows:
class Stack<T> where T : System.IComparable<T>, IEnumerable<T>
{
}

// ---------------------------------------------
// An interface can define more than one type parameter, as follows:

interface IDictionary<K, V>
{
}

// ---------------------------------------------
// The rules of inheritance that apply to classes also apply to interfaces:
interface IMonth<T> { }

interface IJanuary : IMonth<int> { }  //No error
interface IFebruary<T> : IMonth<int> { }  //No error
interface IMarch<T> : IMonth<T> { }    //No error
                                       //interface IApril<T>  : IMonth<T, U> {}  //Error

// Generic interfaces can inherit from non-generic interfaces if the generic interface is covariant, which means it only uses its type parameter as a return value. In the .NET class library, IEnumerable<T> inherits from IEnumerable because IEnumerable<T> only uses T in the return value of GetEnumerator and in the Current property getter.

// ---------------------------------------------
// Concrete classes can implement closed constructed interfaces, as follows:
interface IBaseInterface<T> { }

class SampleClass : IBaseInterface<string> { }

// ---------------------------------------------
// Generic classes can implement generic interfaces or closed constructed interfaces as long as the class parameter list supplies all arguments required by the interface, as follows:
interface IBaseInterface1<T> { }
interface IBaseInterface2<T, U> { }

class SampleClass1<T> : IBaseInterface1<T> { }          //No error
class SampleClass2<T> : IBaseInterface2<T, string> { }  //No error


// Beginning with C# 11, interfaces may declare static abstract or static virtual members.

// =======================================================================================================================================
// https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics
// Generic classes and methods
// =======================================================================================================================================

// Declare the generic class.
public class GenericList<T>
{
    public void Add(T input) { }
}
class TestGenericList
{
    private class ExampleClass { }
    static void Main()
    {
        // Declare a list of type int.
        GenericList<int> list1 = new GenericList<int>();
        list1.Add(1);

        // Declare a list of type string.
        GenericList<string> list2 = new GenericList<string>();
        list2.Add("");

        // Declare a list of type ExampleClass.
        GenericList<ExampleClass> list3 = new GenericList<ExampleClass>();
        list3.Add(new ExampleClass());
    }
}

// ---------------------------------------------

// type parameter T in angle brackets
public class GenericList<T>
{
    // The nested class is also generic on T.
    private class Node
    {
        // T used in non-generic constructor.
        public Node(T t)
        {
            next = null;
            data = t;
        }

        private Node? next;
        public Node? Next
        {
            get { return next; }
            set { next = value; }
        }

        // T as private member data type.
        private T data;

        // T as return type of property.
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
    }

    private Node? head;

    // constructor
    public GenericList()
    {
        head = null;
    }

    // T as method parameter type:
    public void AddHead(T t)
    {
        Node n = new Node(t);
        n.Next = head;
        head = n;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node? current = head;

        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
}
// --- ^ Usage -------
class TestGenericList
{
    static void Main()
    {
        // int is the type argument
        GenericList<int> list = new GenericList<int>();

        for (int x = 0; x < 10; x++)
        {
            list.AddHead(x);
        }

        foreach (int i in list)
        {
            System.Console.Write(i + " ");
        }
        System.Console.WriteLine("\nDone");
    }
}

// =======================================================================================================================================
// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
// Constraints on type parameters (C# Programming Guide)
// =======================================================================================================================================
// Constraint
where T : struct              //  The type argument must be a non-nullable value type.  Because all value types have an accessible parameterless constructor, the struct constraint implies the new() constraint and can't be combined with the new() constraint. You can't combine the struct constraint with the unmanaged constraint.
where T : class               //  The type argument must be a reference type. This constraint applies also to any class, interface, delegate, or array type. In a nullable context, T must be a non-nullable reference type.
where T : class?              //  The type argument must be a reference type, either nullable or non-nullable. This constraint applies also to any class, interface, delegate, or array type.
where T : notnull             //  The type argument must be a non-nullable type. The argument can be a non-nullable reference type or a non-nullable value type.
where T : default             //  This constraint resolves the ambiguity when you need to specify an unconstrained type parameter when you override a method or provide an explicit interface implementation. The default constraint implies the base method without either the class or struct constraint. For more information, see the default constraint spec proposal.
where T : unmanaged           //  The type argument must be a non-nullable unmanaged type. The unmanaged constraint implies the struct constraint and can't be combined with either the struct or new() constraints.
where T : new()               //  The type argument must have a public parameterless constructor. When used together with other constraints, the new() constraint must be specified last. The new() constraint can't be combined with the struct and unmanaged constraints.
where T : <base class name>   //  The type argument must be or derive from the specified base class. In a nullable context, T must be a non-nullable reference type derived from the specified base class.
where T : <base class name>?  //  The type argument must be or derive from the specified base class. In a nullable context, T may be either a nullable or non-nullable type derived from the specified base class.
where T : <interface name>    //  The type argument must be or implement the specified interface. Multiple interface constraints can be specified. The constraining interface can also be generic. In a nullable context, T must be a non-nullable type that implements the specified interface.
where T : <interface name>?   //  The type argument must be or implement the specified interface. Multiple interface constraints can be specified. The constraining interface can also be generic. In a nullable context, T may be a nullable reference type, a non-nullable reference type, or a value type. T may not be a nullable value type.
where T : U                   //  The type argument supplied for T must be or derive from the argument supplied for U. In a nullable context, if U is a non-nullable reference type, T must be non-nullable reference type. If U is a nullable reference type, T may be either nullable or non-nullable.

// ---------------------------------------------

public class Employee
{
    public Employee(string name, int id) => (Name, ID) = (name, id);
    public string Name { get; set; }
    public int ID { get; set; }
}

public class GenericList<T> where T : Employee
{
    private class Node
    {
        public Node(T t) => (Next, Data) = (null, t);

        public Node? Next { get; set; }
        public T Data { get; set; }
    }

    private Node? head;

    public void AddHead(T t)
    {
        Node n = new Node(t) { Next = head };
        head = n;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node? current = head;

        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    public T? FindFirstOccurrence(string s)
    {
        Node? current = head;
        T? t = null;

        while (current != null)
        {
            //The constraint enables access to the Name property.
            if (current.Data.Name == s)
            {
                t = current.Data;
                break;
            }
            else
            {
                current = current.Next;
            }
        }
        return t;
    }
}

// ---------------------------------------------

// Multiple constraints can be applied to the same type parameter, and the constraints themselves can be generic types, as follows:
class EmployeeList<T> where T : Employee, IEmployee, System.IComparable<T>, new()
{
    // ...
}

// ---------------------------------------------
// Constraining multiple parameters
// You can apply constraints to multiple parameters, and multiple constraints to a single parameter, as shown in the following example:
class Base { }
class Test<T, U>
    where U : struct
    where T : Base, new()
{ }

// ---------------------------------------------
// Type parameters as constraints
//
// The use of a generic type parameter as a constraint is useful when a member function with its own type parameter has to constrain that parameter to the type parameter of the containing type, as shown in the following example:
public class List<T>
{
    public void Add<U>(List<U> items) where U : T {/*...*/}
}

// ---------------------------------------------
// Type parameters can also be used as constraints in generic class definitions. The type parameter must be declared within the angle brackets together with any other type parameters:
//Type parameter V is used as a type constraint.
public class SampleClass<T, U, V> where T : V { }
// ---------------------------------------------
// Unmanaged constraint
unsafe public static byte[] ToByteArray<T>(this T argument) where T : unmanaged
{
    var size = sizeof(T);
    var result = new Byte[size];
    Byte* p = (byte*)&argument;
    for (var i = 0; i < size; i++)
        result[i] = *p++;
    return result;
}
// ---------------------------------------------
// Delegate constraints
public static TDelegate? TypeSafeCombine<TDelegate>(this TDelegate source, TDelegate target)
    where TDelegate : System.Delegate
    => Delegate.Combine(source, target) as TDelegate;
// ----------

Action first = () => Console.WriteLine("this");
Action second = () => Console.WriteLine("that");

var combined = first.TypeSafeCombine(second);
combined!();

Func<bool> test = () => true;
// Combine signature ensures combined delegates must
// have the same type.
//var badCombined = first.TypeSafeCombine(test);

// ---------------------------------------------
// Enum constraints

// Enum.GetValues and Enum.GetName use reflection, which has performance implications. You can call EnumNamedValues to build a collection that is cached and reused rather than repeating the calls that require reflection.
public static Dictionary<int, string> EnumNamedValues<T>() where T : System.Enum
{
    var result = new Dictionary<int, string>();
    var values = Enum.GetValues(typeof(T));

    foreach (int item in values)
        result.Add(item, Enum.GetName(typeof(T), item)!);
    return result;
}
// ---------------------------------------------
// Type arguments implement declared interface
// Some scenarios require that an argument supplied for a type parameter implement that interface. For example:
public interface IAdditionSubtraction<T> where T : IAdditionSubtraction<T>
{
    public abstract static T operator +(T left, T right);
    public abstract static T operator -(T left, T right);
}
// This pattern enables the C# compiler to determine the containing type for the overloaded operators, or any static virtual or static abstract method.

// ------ Without Constraint: -------
// Without this constraint, the parameters and arguments would be required to be declared as the interface, rather than the type parameter:
public interface IAdditionSubtraction<T> where T : IAdditionSubtraction<T>
{
    public abstract static IAdditionSubtraction<T> operator +(
        IAdditionSubtraction<T> left,
        IAdditionSubtraction<T> right);

    public abstract static IAdditionSubtraction<T> operator -(
        IAdditionSubtraction<T> left,
        IAdditionSubtraction<T> right);
}
// ---------------------------------------------




// =======================================================================================================================================
// https://www.functionx.com/csharp40/interfaces/cugi.htm
// Programming: Creating and Using a Generic Interface
// =======================================================================================================================================

// Creating a Generic Interface
public interface ICounter<T>
{
}

// You should also add the members that the implementers will have to override. Here is an example:
public interface ICounter<T>
{
    int Count { get; }
    T Get(int index);
}



// In the same way, you can derive a generic interface from another generic interface. Here is an example:
public interface ICounter<T>
{
    int Count { get; }
    T Get(int index);
}

public interface IPersons<T> : ICounter<T>
{
    void Add(T item);
}
// ---------------------------------------------

// Implementing a Generic Interface
// After creating the generic interface, when deriving a class from it, follow the formula we reviewed for inheriting from a generic class. Here is an example:
public interface ICounter<T>
{
    int Count { get; }
    T Get(int index);
}

public interface IPersons<T> : ICounter<T>
{
    void Add(T item);
}

public class People<T> : IPersons<T>
{

}

// -------------
// When implementing the derived class, you must observe all rules that apply to interface derivation. That is, you must implement all the members of the generic interface. Of course, you can also add new members if you want. Here is an example:

public interface ICounter<T>
{
    int Count { get; }
    T Get(int index);
}

public interface IPersons<T> : ICounter<T>
{
    void Add(T item);
}

public class People<T> : IPersons<T>
{
    private int size;
    private T[] persons;

    public People()
    {
        size = 0;
        persons = new T[10];
    }

    public int Count { get { return size; } }

    public void Add(T pers)
    {
        persons[size] = pers;
        size++;
    }

    public T Get(int index) { return persons[index]; }
}

// ---------------------------------------------
using System;

public interface ICounter<T>
{
    int Count { get; }
    T Get(int index);
}

public interface IPersons<T> : ICounter<T>
{
    void Add(T item);
}

public class People<T> : IPersons<T>
{
    private int size;
    private T[] persons;

    public People()
    {
        size = 0;
        persons = new T[10];
    }

    public int Count { get { return size; } }

    public void Add(T pers)
    {
        persons[size] = pers;
        size++;
    }

    public T Get(int index) { return persons[index]; }
}

public class Employee
{
    public long EmployeeNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double HourlySalary { get; set; }

    public Employee(long number = 0, string fName = "John",
                    string lName = "Doe", double salary = 12.05D)
    {
        EmployeeNumber = number;
        FirstName = fName;
        LastName = lName;
        HourlySalary = salary;
    }

    public override string ToString()
    {
        base.ToString();

        return string.Format("================================\n" +
                             "Employee Record\n" +
                             "--------------------------------\n" +
                             "Employee #:    {0}\nFirst Name:    {1}\n" +
                             "Last Name:     {2}\nHourly Salary: {3}",
                             EmployeeNumber, FirstName,
                             LastName, HourlySalary);
    }
}

public class Exercise
{
    public static int Main()
    {
        IPersons<Employee> employees = new People<Employee>();

        Employee empl = null;

        empl = new Employee();
        empl.EmployeeNumber = 253055;
        empl.FirstName = "Joseph";
        empl.LastName = "Denison";
        empl.HourlySalary = 12.85;
        employees.Add(empl);

        empl = new Employee();
        empl.EmployeeNumber = 204085;
        empl.FirstName = "Raymond";
        empl.LastName = "Ramirez";
        empl.HourlySalary = 9.95;
        employees.Add(empl);

        empl = new Employee();
        empl.EmployeeNumber = 970044;
        empl.FirstName = "Christian";
        empl.LastName = "Riley";
        empl.HourlySalary = 14.25;
        employees.Add(empl);

        for (int i = 0; i < employees.Count; i++)
        {
            Employee staff = employees.Get(i);

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Employee #:    {0}", staff.EmployeeNumber);
            Console.WriteLine("First Name:    {0}", staff.FirstName);
            Console.WriteLine("Last Name:     {0}", staff.LastName);
            Console.WriteLine("Hourly Salary: {0}", staff.HourlySalary);
        }

        return 0;
    }
}
// This would produce:
//
// Employee #:    253055
// First Name:    Joseph
// Last Name:     Denison
// Hourly Salary: 12.85
//
// Employee #:    204085
// First Name:    Raymond
// Last Name:     Ramirez
// Hourly Salary: 9.95
//
// Employee #:    970044
// First Name:    Christian
// Last Name:     Riley
// Hourly Salary: 14.25
// Press any key to continue . . .

// ---------------------------------------------
// Passing a Generic Interface as Argument
using System;

public interface IShapes<T>
{
    int Count { get; }
    void Add(T item);
    T Get(int index);
}

public class GeometricShapes<T> : IShapes<T>
{
    private int size;
    private T[] items;

    public GeometricShapes()
    {
        size = 0;
        items = new T[10];
    }

    public int Count { get { return size; } }

    public void Add(T item)
    {
        this.items[this.size] = item;
        this.size++;
    }

    public T Get(int index) { return this.items[index]; }
}

public interface IRound
{
    string Name { get; }
    double Radius { get; set; }
    double Diameter { get; }
    double Circumference { get; }
    double Area { get; }
}

public class Circle : IRound
{
    protected double rad;
    protected string id;

    public Circle(double radius = 0.00D)
    {
        this.rad = radius;
    }

    public string Name { get { return "Circle"; } }

    public double Radius
    {
        get { return rad; }
        set
        {
            if (rad <= 0) rad = 0;
            else rad = value;
        }
    }

    public double Diameter { get { return rad * 2; } }

    public double Circumference { get { return rad * 2 * 3.14159; } }

    public double Area { get { return rad * rad * 3.14159; } }
}

public class Exercise
{
    public Circle GetShape()
    {
        double rad = 0.00D;

        Console.Write("Enter the radius: ");
        rad = double.Parse(Console.ReadLine());

        return new Circle(rad);
    }

    public void ShowShapes(IShapes<IRound> shps)
    {
        for (int i = 0; i < shps.Count; i++)
        {
            IRound rnd = shps.Get(i);

            Console.WriteLine("================================");
            Console.WriteLine("{0} Characteristics", rnd.Name);
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Radius:        {0}", rnd.Radius);
            Console.WriteLine("Diameter:      {0}", rnd.Diameter);
            Console.WriteLine("Circumference: {0}", rnd.Circumference);
            Console.WriteLine("Area:          {0}", rnd.Area);
        }
        Console.WriteLine("===============================");
    }

    public static int Main()
    {
        Exercise exo = new Exercise();
        GeometricShapes<IRound> shapes = new GeometricShapes<IRound>();

        IRound rnd = exo.GetShape();
        shapes.Add(rnd);
        rnd = exo.GetShape();
        shapes.Add(rnd);
        rnd = exo.GetShape();
        shapes.Add(rnd);
        rnd = exo.GetShape();
        shapes.Add(rnd);
        rnd = exo.GetShape();
        shapes.Add(rnd);

        Console.Clear();
        exo.ShowShapes(shapes);

        return 0;
    }
}

Here is an example of running the
// ---------------------------------------------
Additional Techniques of Using Built-In Interfacces


Creating a List From an Existing Collection

In our introduction to the List<> class, we mentioned the default constructor and the constructor that allows you to specify the start amount of memory for a new List variable. The List class is equipped with a third constructor whose syntax is:

public List(IEnumerable<T> collection);

This constructor allows you to create a new list using an existing collection of items. To use it, pass it a list created from a collection class that implements the IEnumerable<> interface. Here is an example:

using System;
using System.Collections.Generic;

public class Employee
{
    public long EmployeeNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double HourlySalary { get; set; }

    public Employee(long number = 0, string fName = "John",
                    string lName = "Doe", double salary = 12.05D)
    {
        EmployeeNumber = number;
        FirstName = fName;
        LastName = lName;
        HourlySalary = salary;
    }
}

public class Records<T> : IEnumerable<T>
{
    private int size;
    private T[] items;

    public Records()
    {
        size = 0;
        items = new T[10];
    }

    public virtual int Count
    {
        get { return size; }
    }

    public void Add(T item)
    {
        this.items[this.size] = item;
        this.size++;
    }

    public T Get(int index) { return items[index]; }

    public IEnumerator<T> GetEnumerator()
    {
        int counter = 0;

        while (counter < Count)
        {
            yield return items[counter];
            counter++;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        int counter = 0;

        while (counter < Count)
        {
            yield return items[counter];
            counter++;
        }
    }
}

public class Exercise
{
    public static int Main()
    {
        Records<Employee> contractors = new Records<Employee>();

        Employee empl = new Employee(397947, "David", "Redson", 18.75);
        contractors.Add(empl);
        contractors.Add(new Employee(174966, "Alfred", "Swanson", 12.94));
        contractors.Add(new Employee(848024, "Alima", "Bieyrou", 14.05));
        contractors.Add(new Employee(number: 397462, fName: "Robert",
                                     lName: "Nants", salary : 22.15));

        List<Employee> employees = new List<Employee>(contractors);

        return 0;
    }
}
// ----------------------------------------------
public interface IMyInterface2<T>
{
        T My();
}

public class MyConcrete2 : IMyInterface2<string>
{
    public string My()
    {
        throw new NotImplementedException();
    }
}


// =======================================================================================================================================
// https://learn.microsoft.com/en-us/dotnet/standard/generics/
// Generics in .NET
// =======================================================================================================================================

// Define and use generics

public class Generic<T>
{
    public T Field;
}
// ----------------------------------------------

public static void Main()
{
    Generic<string> g = new Generic<string>();
    g.Field = "A string";
    //...
    Console.WriteLine("Generic.Field           = \"{0}\"", g.Field);
    Console.WriteLine("Generic.Field.GetType() = {0}", g.Field.GetType().FullName);
}

// ----------------------------------------------
// Terminology
// A generic type definition is a class, structure, or interface declaration that functions as a template, with placeholders for the types that it can contain or use. For example, the System.Collections.Generic.Dictionary<TKey,TValue> class can contain two types: keys and values. Because a generic type definition is only a template, you cannot create instances of a class, structure, or interface that is a generic type definition.

// Generic type parameters, or type parameters, are the placeholders in a generic type or method definition. The System.Collections.Generic.Dictionary<TKey,TValue> generic type has two type parameters, TKey and TValue, that represent the types of its keys and values.

// A constructed generic type, or constructed type, is the result of specifying types for the generic type parameters of a generic type definition.

// A generic type argument is any type that is substituted for a generic type parameter.

// The general term generic type includes both constructed types and generic type definitions.

// Covariance and contravariance of generic type parameters enable you to use constructed generic types whose type arguments are more derived (covariance) or less derived (contravariance) than a target constructed type. Covariance and contravariance are collectively referred to as variance. For more information, see Covariance and contravariance

// Constraints are limits placed on generic type parameters. For example, you might limit a type parameter to types that implement the System.Collections.Generic.IComparer<T> generic interface, to ensure that instances of the type can be ordered. You can also constrain type parameters to types that have a particular base class, that have a parameterless constructor, or that are reference types or value types. Users of the generic type cannot substitute type arguments that do not satisfy the constraints.



// A generic method definition is a method with two parameter lists: a list of generic type parameters and a list of formal parameters. Type parameters can appear as the return type or as the types of the formal parameters, as the following code shows.
T Generic<T>(T arg)
{
    T temp = arg;
    //...
    return temp;
}

// ----------------


// Generic methods can appear on generic or nongeneric types
class A
{
    T G<T>(T arg)
    {
        T temp = arg;
        //...
        return temp;
    }
}
class Generic<T>
{
    T M(T arg)
    {
        T temp = arg;
        //...
        return temp;
    }
}


// ----------------------------------------------

// Limitations
// Enumerations cannot have generic type parameters
// Lightweight dynamic methods cannot be generic








// =======================================================================================================================================
// https://learn.microsoft.com/en-us/dotnet/standard/generics/
// Generics in .NET
// =======================================================================================================================================
// Covariance and contravariance in generics

//Covariance and contravariance are terms that refer to the ability to use a more derived type (more specific) or a less derived type (less specific) than originally specified. 
// Generic type parameters support covariance and contravariance to provide greater flexibility in assigning and using generic types.

// Covariance
// Enables you to use a more derived type than originally specified.
// You can assign an instance of IEnumerable<Derived> to a variable of type IEnumerable<Base>.

// Contravariance
// Enables you to use a more generic (less derived) type than originally specified.
// You can assign an instance of Action<Base> to a variable of type Action<Derived>.

// Invariance
// Means that you can use only the type originally specified. An invariant generic type parameter is neither covariant nor contravariant.
// You cannot assign an instance of List<Base> to a variable of type List<Derived> or vice versa.

// Covariance and contravariance are collectively referred to as variance


// -----------------------------------------------------------

// Covariant type parameters enable you to make assignments that look much like ordinary Polymorphism, as shown in the following code.

IEnumerable<Derived> d = new List<Derived>();
IEnumerable<Base> b = d;

// The List<T> class implements the IEnumerable<T> interface, so List<Derived> (List(Of Derived) in Visual Basic) implements IEnumerable<Derived>. The covariant type parameter does the rest.

// -----------------------------------------------------------

// Contravariance, on the other hand, seems counterintuitive. The following example creates a delegate of type Action<Base> (Action(Of Base) in Visual Basic), and then assigns that delegate to a variable of type Action<Derived>.
Action<Base> b = (target) => { Console.WriteLine(target.GetType().Name); };
Action<Derived> d = b;
d(new Derived());


// Generic interfaces with covariant type parameters

// Several generic interfaces have covariant type parameters, for example, IEnumerable<T>, IEnumerator<T>, IQueryable<T>, and IGrouping<TKey,TElement>. All the type parameters of these interfaces are covariant, so the type parameters are used only for the return types of the members.
// The following example illustrates covariant type parameters ...
using System;
using System.Collections.Generic;

class Base
{
    public static void PrintBases(IEnumerable<Base> bases)
    {
        foreach(Base b in bases)
        {
            Console.WriteLine(b);
        }
    }
}

class Derived : Base
{
    public static void Main()
    {
        List<Derived> dlist = new List<Derived>();

        Derived.PrintBases(dlist);
        IEnumerable<Base> bIEnum = dlist;
    }
}

// -----------------------------------------------------------

// Generic interfaces with contravariant type parameters
using System;
using System.Collections.Generic;

abstract class Shape
{
    public virtual double Area { get { return 0; }}
}

class Circle : Shape
{
    private double r;
    public Circle(double radius) { r = radius; }
    public double Radius { get { return r; }}
    public override double Area { get { return Math.PI * r * r; }}
}

class ShapeAreaComparer : System.Collections.Generic.IComparer<Shape>
{
    int IComparer<Shape>.Compare(Shape a, Shape b)
    {
        if (a == null) return b == null ? 0 : -1;
        return b == null ? 1 : a.Area.CompareTo(b.Area);
    }
}

class Program
{
    static void Main()
    {
        // You can pass ShapeAreaComparer, which implements IComparer<Shape>,
        // even though the constructor for SortedSet<Circle> expects
        // IComparer<Circle>, because type parameter T of IComparer<T> is
        // contravariant.
        SortedSet<Circle> circlesByArea =
            new SortedSet<Circle>(new ShapeAreaComparer())
                { new Circle(7.2), new Circle(100), null, new Circle(.01) };

        foreach (Circle c in circlesByArea)
        {
            Console.WriteLine(c == null ? "null" : "Circle with area " + c.Area);
        }
    }
}

/* This code example produces the following output:
null
Circle with area 0.000314159265358979
Circle with area 162.860163162095
Circle with area 31415.9265358979
 */

// -----------------------------------------------------------

// Generic delegates with variant type parameters
// The Func generic delegates, such as Func<T,TResult>, have covariant return types and contravariant parameter types. The Action generic delegates, such as Action<T1,T2>, have contravariant parameter types. This means that the delegates can be assigned to variables that have more derived parameter types and (in the case of the Func generic delegates) less derived return types.
// The last generic type parameter of the Func generic delegates specifies the type of the return value in the delegate signature. It is covariant (out keyword), whereas the other generic type parameters are contravariant (in keyword).

// The following code illustrates this. The first piece of code defines a class named Base, a class named Derived that inherits Base, and another class with a static method (Shared in Visual Basic) named MyMethod. The method takes an instance of Base and returns an instance of Derived. (If the argument is an instance of Derived, MyMethod returns it; if the argument is an instance of Base, MyMethod returns a new instance of Derived.) In Main(), the example creates an instance of Func<Base, Derived> (Func(Of Base, Derived) in Visual Basic) that represents MyMethod, and stores it in the variable f1.
public class Base {}
public class Derived : Base {}

public class Program
{
    public static Derived MyMethod(Base b)
    {
        return b as Derived ?? new Derived();
    }

    static void Main()
    {
        Func<Base, Derived> f1 = MyMethod;
    
// -----------------------------------------------------------

// Covariant return type.
Func<Base, Base> f2 = f1;
Base b2 = f2(new Base());

// -----------------------------------------------------------

// Contravariant parameter type.
Func<Derived, Derived> f3 = f1;
Derived d3 = f3(new Derived());

// -----------------------------------------------------------
// Covariant return type and contravariant parameter type.
Func<Derived, Base> f4 = f1;
Base b4 = f4(new Derived());
// -----------------------------------------------------------


// Variance in non-generic delegates
// In the preceding code, the signature of MyMethod exactly matches the signature of the constructed generic delegate: Func<Base, Derived> (Func(Of Base, Derived) in Visual Basic). The example shows that this generic delegate can be stored in variables or method parameters that have more derived parameter types and less derived return types, as long as all the delegate types are constructed from the generic delegate type Func<T,TResult>.

// This is an important point. The effects of covariance and contravariance in the type parameters of generic delegates are similar to the effects of covariance and contravariance in ordinary delegate binding (see Variance in Delegates (C#) and Variance in Delegates (Visual Basic)). However, variance in delegate binding works with all delegate types, not just with generic delegate types that have variant type parameters. Furthermore, variance in delegate binding enables a method to be bound to any delegate that has more restrictive parameter types and a less restrictive return type, whereas the assignment of generic delegates works only if both delegate types are constructed from the same generic type definition.
// The following example shows the combined effects of variance in delegate binding and variance in generic type parameters. The example defines a type hierarchy that includes three types, from least derived (Type1) to most derived (Type3). Variance in ordinary delegate binding is used to bind a method with a parameter type of Type1 and a return type of Type3 to a generic delegate with a parameter type of Type2 and a return type of Type2. The resulting generic delegate is then assigned to another variable whose generic delegate type has a parameter of type Type3 and a return type of Type1, using the covariance and contravariance of generic type parameters. The second assignment requires both the variable type and the delegate type to be constructed from the same generic type definition, in this case, Func<T,TResult>.

using System;

public class Type1 {}
public class Type2 : Type1 {}
public class Type3 : Type2 {}

public class Program
{
    public static Type3 MyMethod(Type1 t)
    {
        return t as Type3 ?? new Type3();
    }

    static void Main()
    {
        Func<Type2, Type2> f1 = MyMethod;

        // Covariant return type and contravariant parameter type.
        Func<Type3, Type1> f2 = f1;
        Type1 t1 = f2(new Type3());
    }
}


// -----------------------------------------------------------


// Define variant generic interfaces and delegates
// C# have keywords that enable you to mark the generic type parameters of interfaces and delegates as covariant or contravariant.

// Note: If a method of an interface has a parameter that is a generic delegate type, a covariant type parameter of the interface type can be used to specify a contravariant type parameter of the delegate type.

// List of Types
// The following interface and delegate types have covariant and/or contravariant type parameters
Type                                                                    Covariant type parameters     Contravariant type parameters
Action<T> to Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T16>                           Yes
Comparison<T>                                                                                         Yes
Converter<TInput,TOutput>                                                                  Yes        Yes
Func<T,TResult> to Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T16,TResult>    Yes        Yes
Func<TResult>                                                                              Yes        
IComparable<T>                                                                                        Yes
IComparer<T>                                                                                          Yes
IEnumerable<T>                                                                             Yes        
IEnumerator<T>                                                                             Yes        
IEqualityComparer<T>                                                                                  Yes
IGrouping<TKey,TElement>                                                                   Yes 
IOrderedEnumerable<TElement>                                                               Yes 
IOrderedQueryable<T>                                                                       Yes 
IQueryable<T>                                                                              Yes 
Predicate