//=================================================================================================== 
// DATE: 10/12/2022 
//===================================================================================================
public interface IHaveHealth
{
    int Health { get; set; }
    int MaxHealth { get; set; }
}

public abstract class Unit : IHaveHealth
{
    public int MaxHealth { get; set; }
    public virtual int Health { get; set; }
}

public class Hero : Unit, IHaveHealth
{
}

public class Enemy : Unit, IHaveHealth
{
    private int _health;
    private int _bonusHealth;

    public override int Health
    {
        get { return _health + _bonusHealth; }
        set { throw new Exception(); }
    }
}
// --------------------------------------------------------------------------------------
public interface IHaveHealth
{
    int Health { get; set; }
}

public class Hero : IHaveHealth
{
    public int Health { get; set; }
}

public class Enemy : IHaveHealth
{
    private int _health;
    private int _bonusHealth;

    public int Health
    {
        get { return _health + _bonusHealth; }
        set { throw new Exception(); }
    }
}

// --------------------------------------------------------------------------------------
object[] thingsInMyZoo = {
    new Lion(), new Dog(), new Cat(), 
    new Cat(), new Troll(), new Pidgeon(), new Pidgeon(), new Dog(), new Lion(), new Cat(), 5, "Hello", true
};

for (var i = 0; i < thingsInMyZoo.Length; i++)
{
    object thing = thingsInMyZoo[i];

    if (thing is IFeedable feedable)
    {
        Console.WriteLine($"Feeding {thing}");
        feedable.Feed("Food");
    }
}



public abstract class Animal { }
public interface IFeedable {
    void Feed(string food);
}

public interface IAdoptable {
    void Adopt();
}

public interface ICarriable {
    void Carry();
}

public class Dog : Animal, IFeedable, IAdoptable {
    public void Feed(string food) { }
    public void Adopt() { }
}

public class Cat : Animal, IFeedable, IAdoptable, ICarriable {
    public void Feed(string food) { }
    public void Adopt() { }
    public void Carry() { }
}

public class Lion : Animal, IFeedable {
    public void Feed(string food) { }
}

public class Troll : IFeedable
{
    public void Feed(string food)
    {
    }
}

public class Pidgeon : Animal
{
    
}


// --------------------------------------------------------------------------------------

using Unit unit = new Unit();
// when unit leaves the scope, it will be disposed automatically

// --------------------------------------------------------------------------------------

Unit unit = new Unit();
unit.Dispose();

// --------------------------------------------------------------------------------------
public class Unit : IDispoable {
   public bool Disposed{get;private set;}
   public void Dispose(){
      Disposed = true;
   }

   public void Attack(){
      if(Disposed) throw new Exception();
      Console.WriteLine("Attack");
   }
}

// --------------------------------------------------------------------------------------

Hero hero = new Hero();
HealthPotion potion = new HealthPotion();
IConsumable consumable = potion;
hero.Use(consumable);
hero.Use(new ManaPotion());
hero.Use(new BiggerHealthPotion());
hero.Use(new HelloWorldPotion());

public interface IConsumable {
    void Consume(Hero hero);
}

public class Hero {
    public int Health {get;set;}
    public int Mana {get;set;}
    public void Use(IConsumable consumable) {
        Console.WriteLine($"{this} uses {consumable}.");
        consumable.Consume(this);
    }
}

public class HealthPotion : IConsumable {
    public void Consume(Hero hero) {
        hero.Health += 50;
    }
}

public class ManaPotion : IConsumable {
    public void Consume(Hero hero) {
        hero.Mana += 50;
    }
}

public class BiggerHealthPotion : IConsumable
{
    public void Consume(Hero hero)
    {
        hero.Health += 100;
    }
}

public class HelloWorldPotion : IConsumable
{
    public void Consume(Hero hero)
    {
        Console.WriteLine("Hello, World!");
    }
}

// --------------------------------------------------------------------------------------

Hero hero = new Hero();
HealthPotion potion = new HealthPotion();
IConsumable consumable = potion;
hero.Use(consumable);
hero.Use(new ManaPotion());

public interface IConsumable {
    void Consume(Hero hero);
}

public class Hero {
    public int Health {get;set;}
    public int Mana {get;set;}
    public void Use(IConsumable consumable) {
        Console.WriteLine($"{this} uses {consumable}.");
        consumable.Consume(this);
    }
}

public class HealthPotion : IConsumable {
    public void Consume(Hero hero) {
        hero.Health += 50;
    }
}

public class ManaPotion : IConsumable {
    public void Consume(Hero hero) {
        hero.Mana += 50;
    }
}

// --------------------------------------------------------------------------------------
Hero hero = new Hero();
Console.WriteLine(hero.Health);

public class Hero
{
    private int health = 100;
    private int level = 2;
    private int bonusHealthPerLevel = 5;

    public int Health => health + level * bonusHealthPerLevel;
}

// --------------------------------------------------------------------------------------

Player player1 = new Player("Marc");
Player player2 = new Player("C#");

Weapon scythe = new Weapon(10, "Scythe");
player1.Attack(player2);
player2.Attack(player1);
player1.Attack(player2);
player2.Attack(player1);
player1.Attack(player2);
player2.Attack(player1);

public class Weapon
{
    public int Damage { get; set; }
    public string Name { get; set; }
    public int Durability { get; set; }

    public Weapon(int damage, string name)
    {
        Damage = damage;
        Name = name;
        Durability = 2;
    }
}

public class Player
{
    public Weapon Weapon { get; set; }
    public string Name { get; }

    public Player(string name)
    {
        Name = name;
        Weapon = new Weapon(100, "a strong slap");
    }

    public void Attack(Player other)
    {
        if (Weapon.Durability < 1)
        {
            Console.WriteLine($"{this.Name} tries to attack {other.Name} with {Weapon.Name}. But it's broken.");
            return;
        }
        
        Console.WriteLine($"{this.Name} attacks {other.Name} with {Weapon.Name} (Durability: {Weapon.Durability}/2) for {Weapon.Damage} damage.");
        Weapon.Durability--;
    }
}

// --------------------------------------------------------------------------------------

Dog dog = new Dog();


public class Animal
{
    protected string name;

    public Animal()
    {
        name = "Animal";
    }
}

public class Dog : Animal
{
    private int bones;
    private string name;
    public Dog() : base()
    {
        bones = 5;
    }
}

// --------------------------------------------------------------------------------------

Animal dog = new Dog();
Animal cat = new Cat();
Animal mouse = new Mouse();
//Animal animal = new Animal();
dog.MakeSound();
cat.MakeSound();
mouse.MakeSound();

public abstract class Animal
{
    public int Age { get; set; }
    public void Breathe()
    {
        Console.WriteLine($"{this} breathes.");
    }

    public abstract void MakeSound();
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof!");
    }
}

public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow!");
    }
}

public class Mouse : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Squeak!");
    }
}


// --------------------------------------------------------------------------------------

// Trick, if you inherit from a class and want to make sure that everyone inheriting from you overrides a method:
public class Foo
{
    public virtual void Start()
    {
        
    }
}

public abstract class Bar : Foo
{
    public abstract void OnStart();

    public override void Start()
    {
        base.Start();
        OnStart();
    }
}

// --------------------------------------------------------------------------------------

Dog dog = new Dog();
dog.MakeSound();
Animal a = dog;
a.MakeSound();

Animal animal = CreateRandomAnimal();
animal.MakeSound(); // ??? => Woof!


Animal CreateRandomAnimal()
{
    if (Random.Shared.Next(2) == 0)
        return new Dog();
    else
        return new Cat();
}

public class Animal
{
    public virtual void MakeSound() => Console.WriteLine("???");
}

public class Cat : Animal
{
    // DO NOT FORGET TO USE THE OVERRIDE KEYWORD!
    public void MakeSound() => Console.WriteLine("Meow!");
}

public class Dog : Animal
{
    public override void MakeSound() => Console.WriteLine("Woof!");
}

// --------------------------------------------------------------------------------------

//=================================================================================================== 
// DATE: 10/11/2022 
//===================================================================================================
Animal animal = CreateRandomAnimal();
animal.Age = 17;
animal.IsHungry = true;
Console.WriteLine($"{animal} Age: {animal.Age}");

if (animal is Dog dog)
{
    dog.BonesChewedOn = 1000;
    Console.WriteLine($"{dog} chewed on {dog.BonesChewedOn} bones.");
}

Animal CreateRandomAnimal()
{
    if (Random.Shared.Next(2) == 0)
    {
        return new Dog();
    }
    else
    {
        return new Cat();
    }
}

public class Animal
{
    public int Age { get; set; }
    public bool IsHungry { get; set; }
}

public class Dog : Animal
{
    public string Name { get; set; }
    public int BonesChewedOn { get; set; }
}

public class Cat : Animal
{
    public bool LikesHuntingMice { get; set; }
}

// --------------------------------------------------------------------------------------

Dog dog = new Dog();
dog.Name = "Bello";
dog.Age = 12;

// Down-casting dog to parent type animal
Animal animal = dog;
Console.WriteLine(animal.Age);

Pet(animal);
// Down-casting dog to parameter type Animal
Pet(dog);

void Pet(Animal animal)
{
    Console.WriteLine("I'm petting "+animal);
    // Type-Checking the instance of class Animal
    // To see, whether this specific animal happens
    // to be a Dog and not a Cat or sth. like that
    if (animal is Dog dog)
    {
        Console.WriteLine(dog.Name);
    }
}

public class Animal
{
    public int Age { get; set; }
}

public class Dog : Animal
{
    public string Name { get; set; }
}

// --------------------------------------------------------------------------------------

//=================================================================================================== 
// DATE: 10/06/2022 
//===================================================================================================

public class Animal{
   public virtual void BePet() {
      Console.WriteLine($"{this} is being pet.");
   }
}

public class Mammal : Animal {
   public override void BePet(){
      Console.WriteLine($"{this} likes a soft belly-rub.");
   }
}

public class Dog : Mammal {
   public override void BePet(){
      base.BePet();
      Console.WriteLine($"{this} barks from excitement.");
   }
}


// --------------------------------------------------------------------------------------

// Method Virtualization

Animal one = new Animal();
one.age = 12;

Animal two = new Animal();
two.age = 24;

Dog three = new Dog();
three.age = 36;

Cat four = new Cat();
four.age = 5;

Animal[] animals = new Animal[4];
animals[0] = one; // Animal 12
animals[1] = two; // Animal 24
animals[2] = three; // Dog 36
animals[3] = four; // Cat 5

for (int i = 0; i < animals.Length; i++)
{
    Animal animal = animals[i];
    Pet(animal);
}

void Pet(Animal animal)
{
    Console.WriteLine($"Petting {animal} age {animal.age}");
    // type Animal gets cast up to its derived type Dog 
    animal.GetPet();
}


public class Animal
{
    public int age;
    public void Breathe()
    {
        Console.WriteLine($"{this} age {age} breathes.");
    }

    public virtual void GetPet()
    {
        Console.WriteLine($"{this} likes being pet.");
    }
}

public class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine($"{this} age {age} barks.");
    }

    public override void GetPet()
    {
        base.GetPet();
        Bark();
    }
}

public class Cat : Animal
{
    public void Meow()
    {
        Console.WriteLine($"{this} age {age} meows.");
    }

    public override void GetPet()
    {
        base.GetPet();
        Meow();
    }
}

public class Lion : Animal
{
    public void Roar()
    {
        Console.WriteLine($"{this} age {age} roars.");
    }
}

// --------------------------------------------------------------------------------------

Cat cat = (Cat) animal;
if(cat != null){
   cat.Meow();
}

// --------------------------------------------------------------------------------------

if(animal is Cat cat){
   cat.Meow();
}

// is short for
if(animal is Cat){
   Cat cat = animal as Cat;
   cat.Meow();
}

// --------------------------------------------------------------------------------------

Animal one = new Animal();
one.age = 12;
one.Breathe();

Animal two = new Animal();
two.age = 24;
two.Breathe();

Dog three = new Dog();
three.age = 36;
three.Breathe();
three.Bark();

// type Dog gets cast down to its base type Animal 
Pet(three);
Pet(new Cat());

void Pet(Animal animal)
{
    Console.WriteLine($"Petting {animal} age {animal.age}");
    // type Animal gets cast up to its derived type Dog 
    if (animal is Dog dog)
    {
        dog.Bark();
    }

    if (animal is Cat cat)
    {
        cat.Meow();
    }
}

public class Animal
{
    public int age;
    public void Breathe()
    {
        Console.WriteLine($"{this} age {age} breathes.");
    }
}

public class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine($"{this} age {age} barks.");
    }
}

public class Cat : Animal
{
    public void Meow()
    {
        Console.WriteLine($"{this} age {age} meows.");
    }
}

// --------------------------------------------------------------------------------------

// Classes -> Objects -> Inheritance
Animal one = new Animal();
one.age = 12;
one.Breathe();

Animal two = new Animal();
two.age = 24;
two.Breathe();

Dog three = new Dog();
three.age = 36;
three.Breathe();
three.Bark();

public class Animal
{
    public int age;
    public void Breathe()
    {
        Console.WriteLine($"{this} age {age} breathes.");
    }
}

public class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine($"{this} age {age} barks.");
    }
}

// --------------------------------------------------------------------------------------
// Multiple Files
// Divide and Conquer - Divide et Impera

public class Program
{
    public static void Main()
    {
        // your application code goes here
    }
}

// --------------------------------------------------------------------------------------

private: Member is only accessible to the class itself (e.g. Animal)
protected: Member is only accessible to the class itself and classes inheriting from it (e.g. Animal, Fish, Bear, Mammal, ...)
public: Member is accessible to any class (e.g. Animal, Car, Program, Game, Item)
Access Restricting Keyword

// --------------------------------------------------------------------------------------
//
//=================================================================================================== 
// DATE: 10/05/2022 
//===================================================================================================

Animal animal = new Animal(DateTime.Now);
animal.Breathe();

Dog dog = new Dog(new DateTime(1970, 1, 1));
dog.Bark();
dog.Breathe();

dog = new Dog();
dog.Bark();
dog.Breathe();

dog = new Dog(new DateTime(1990, 8, 11), "Bello");
dog.Bark();
dog.Breathe();

public class Animal
{
    private DateTime birthDate;
    public void Breathe()
    {
        Console.WriteLine($"{this} born on {birthDate} breathes.");
    }

    public Animal(DateTime birthDate)
    {
        Console.WriteLine("Animal gets constructed.");
        this.birthDate = birthDate;
    }
}

public class Dog : Animal
{
    private string name;

    public void Bark()
    {
        Console.WriteLine($"{this} barks.");
    }

    // provide a constructor with the same arguments as the base constructor
    public Dog(DateTime birthDate) : base(birthDate)
    {
        Console.WriteLine("Dog gets constructed.");
    }

    // provide a constructor with less arguments than the base constructor (you need to provide new values, then)
    public Dog() : base(DateTime.Now)
    {
        Console.WriteLine("Dog gets constructed.");
    }

    
    // provide a constructor with more arguments then the base constructor and then use the other arguments somehow else
    public Dog(DateTime birthDate, string name) : base(birthDate)
    {
        this.name = name;
    }
}

// --------------------------------------------------------------------------------------

Parrot parrot = new Parrot();
parrot.Walk();
parrot.Die();
parrot.Fly();
Sparrow sparrow = new Sparrow();
sparrow.Walk();
sparrow.Die();
sparrow.Fly();
Dog dog = new Dog();
dog.Walk();
dog.Swim();
dog.Die();
Salmon salmon = new Salmon();
salmon.Swim();
salmon.Die();

/*
 *
 * Animal (Die)
 * -- Terrestrial (Walk)
 * ---- Bird (Fly)
 * ------ Sparrow
 * ------ Parrot
 * ---- Dog (Swim)
 * -- Fish (Swim)
 * 
 */


public class Animal
{
    public void Die(){Console.WriteLine($"{this} dies.");}
}

public class Terrestrial : Animal
{
    public void Walk(){Console.WriteLine($"{this} walks.");}
}

public class Bird : Terrestrial
{
    public void Fly(){Console.WriteLine($"{this} flies.");}
}

public class Parrot : Bird
{
}

public class Sparrow : Bird
{
}

public class Dog : Terrestrial
{
    public void Swim(){Console.WriteLine($"{this} swims.");}
}

public class Salmon : Animal
{
    public void Swim(){Console.WriteLine($"{this} swims.");}
}

// --------------------------------------------------------------------------------------

Animal animal = new Animal();
animal.Breathe();
//animal.ChangeOwner();

Pet pet = new Pet();
pet.Breathe();
pet.ChangeOwner();

Dog dog = new Dog();
dog.Breathe();
dog.ChangeOwner();

public class Animal
{
    public void Breathe()
    {
        Console.WriteLine($"{this} breathes.");
    }
}

// Animal: is the parent class / base class
// Pet: is the child class / derived class
// Pet inherits from Animal
// A Pet IS AN Animal
public class Pet : Animal
{
    public void ChangeOwner()
    {
        Console.WriteLine($"{this} changes owner.");
    }
}

public class Parrot : Pet
{
}

// Every Dog is a Pet
// Every Pet is an Animal
// => Every Dog is an Animal
// Every Animal has an Age
// => Every Dog has an Age
public class Dog : Pet
{
}

// But not every Flower is a Rose (some of them might be Tulips)
public class Flower
{
    
}

public class Tulip : Flower
{
    
}

// Every Rose is a Flower
public class Rose : Flower
{
    
}

/*

           Animal (Breathe)
             |
             |
             v
            Pet (Breathe + ChangeOwner)
            / \
           /   \
          /     \
         /       \
        v         v
        Dog    Parrot 
   (Breathe + ChangeOwner)



*/

// --------------------------------------------------------------------------------------

Vehicle: Mount() | float maxSpeed, float handling, bool waterVehicle, int maxPassengers
    Car: Drive()
    Aircraft: Fly()

// --------------------------------------------------------------------------------------

All Vehicles have Mount(); and maxSpeed; need a driver else idle;
All Boats can move OnWater();
All AirCrafts can InAir(); can move while inAir all others need to be isGrounded to move
All Cars need tires && engine to work && fuel;
All Trains need rails to move;
All Horses needs water else tired;
Bicycle and Scooter need Player stamina -= each sec riding;

// --------------------------------------------------------------------------------------

vehicle (start, stop, weight, turning radius, power rating, length, height)
    car(indicators, headlights off/DLR/halfbeam/fullbeam, registration plate, number of seats)
aircraft(takeoff, land, position lights on/off, transponder code)
        airplane (wingspan)

// --------------------------------------------------------------------------------------
        
vehicle: Function: Moun/Unmount Property: maxSpeed   
    car    
        buggy
        cabriolet
        truck
        sportscar
        racecar
        van
    bus    
    train    
    aircraft    
        airplane
        helicopter
        jetpack
    horse    
    bicycle    
    tuk-tuk    
    boat    
    scooter   




// --------------------------------------------------------------------------------------

vehicle        
    car    
        buggy
        cabriolet
        truck
        sportscar
        racecar
        van
    bus    
    train    
    aircraft    
        airplane
        helicopter
        jetpack
    horse    
    bicycle    
    tuk-tuk    
    boat    
    scooter   



// --------------------------------------------------------------------------------------

vehicle
    aircraft
        airplane
        helicopter
        jetpack

    car
        tuk-tuk

        sportscar
            cabriolet
        racecar

        truck

    bicycle
        scooter



// --------------------------------------------------------------------------------------
        
vehicle
  -car
      cabriolet
      sportscar
      racecar
      van
      buggy

  -aircraft
      airplane
      helicopter
      jetpack

  -truck
  -boat
  -bus
  -bicycle
  -scooter
  -train
  -tuk tuk
  -horse

// --------------------------------------------------------------------------------------
  
vehicle        
    car    
        buggy
        cabriolet
        truck
        sportscar
        racecar
        van
    bus    
    train    
    aircraft    
        airplane
        helicopter
        jetpack
    horse    
    bicycle    
    tuk-tuk    
    boat    
    scooter




// --------------------------------------------------------------------------------------
Vehicle
  Boat
  Car
  Racecar
  Sportscar
  Cabriolet
  Buggy
  Tuk-Tuk
  Train
  Van
  Bus
  Truck
  Horse
  Bicycle
 AirCraft
   Airplane
   Helicopter
   Jetpack




// --------------------------------------------------------------------------------------
TRANSPORTATION
 LAND TRANSPORTATION
    ANIMAL
  HORSE
    WHEELS
  BUGGY
  BICYCLE 
  SCOOTER
   VEHICLE
QUICK WHEELS
       CAR
       SPORTCAR
       TRUCK
       BUS
       VAN
       RACECAR
     TRAIN 
      TUK-TUK
      CABRIOLET
 WATER 
     BOAT
AIR
    AIRPLANE
    AIRCRAFT
HELICOPTER
 UNREALFLY

JETPACK

// --------------------------------------------------------------------------------------

JetPack
Vehicle
    Bicycle
    Bus
    Boat
    Horse
    Scooter
    Tuk-Tuk
    Train
    Aircraft
        Airplane
        HeliCopter
    Car
        Buggy
        Cabriolet
        RaceCar
        Sportscar
        Truck
        Van

// --------------------------------------------------------------------------------------

Vehicle

Car
     Cab
     Buggy
    Sportcar
    Racecar
        Truck
        Van
        Bus

Two wheels
    Bicycle
    Scooter

Three wheels
    Tuk-Tuk

Aircraft
    Airplane
    Helicopter
    Jetpack

Rails
    Train

Water
    Boat

Organic
    Horse

// --------------------------------------------------------------------------------------
    
Vehicle
    Car
        Cabriolet
        Buggy
        Truck
        Sportscar
        Racecar
        Van
        Bus
        Tuk-tuk
    Aircraft
        Airplane
        Jetpack
        Helicopter
    Boat
    Bicycle
    Horse
    Scooter
    Train




// --------------------------------------------------------------------------------------

vehicle
    car
        buggy
        truck
        sportscar
        van
        bus
        cabriolet
        racecar
    train
    bicycle
    scooter
    tuk-tuk
    aircraft
        airplane
        jetpack
        helicopter
    horse
    boat



// --------------------------------------------------------------------------------------

Animal animal = new Animal();
animal.age = 12;
Console.WriteLine(animal.age);

Pet pet = new Pet();
pet.age = 7;
Console.WriteLine(pet.age);

Dog dog = new Dog();
dog.age = 6;
Console.WriteLine(dog.age);

public class Animal
{
    public int age;
}

// Animal: is the parent class / base class
// Pet: is the child class / derived class
// Pet inherits from Animal
// A Pet IS AN Animal
public class Pet : Animal
{
}

public class Parrot : Pet
{
}

// Every Dog is a Pet
// Every Pet is an Animal
// => Every Dog is an Animal
// Every Animal has an Age
// => Every Dog has an Age
public class Dog : Pet
{
}

// But not every Flower is a Rose (some of them might be Tulips)
public class Flower
{
    
}

public class Tulip : Flower
{
    
}

// Every Rose is a Flower
public class Rose : Flower
{
    
}

// --------------------------------------------------------------------------------------

//=================================================================================================== 
// DATE: 10/04/2022 
//===================================================================================================

Animal animal = new Animal("");
animal.SetName("Bello");
Console.WriteLine($"Animal Name: {animal.GetName()}");
animal.Promote();
Console.WriteLine($"Animal Name: {animal.GetName()}");
animal.Promote();
Console.WriteLine($"Animal Name: {animal.GetName()}");
animal.SetName("Rex");
Console.WriteLine($"Animal Name: {animal.GetName()}");
public class Animal {
  private string name;
  private bool isPromoted;
  public Animal(string name)
  {
    SetName(name);
  }
  public string GetName()
  {
    if (isPromoted)
    {
      return $"Officer {name}";
    }

    return name;
  }
  public void SetName(string name)
  {
    if (string.IsNullOrEmpty(name)) // validation
    {
      Console.WriteLine("Error: Name can not be empty.");
      return; // early-exit
    }
    this.name = name;
  }

  public void Promote()
  {
    isPromoted = true;
  }
}

// --------------------------------------------------------------------------------------

Animal animal = new Animal("");
animal.SetName("Bello");
Console.WriteLine($"Animal Name: {animal.GetName()}");
public class Animal {
  private string name;
  public Animal(string name)
  {
    SetName(name);
  }
  public string GetName()
  {
    return name;
  }
  public void SetName(string name)
  {
    if (string.IsNullOrEmpty(name)) // validation
    {
      Console.WriteLine("Error: Name can not be empty.");
      return; // early-exit
    }
    this.name = name;
  }
}




// --------------------------------------------------------------------------------------

//=================================================================================================== 
// DATE: 09/28/2022 
//===================================================================================================

Fields:
Make them non-static whenever you want the value to be individual to EACH instance of a class.
Make them static whenever you want the value to be singular shared by ALL instances of a class.
-> Or accessible without any instances.

Methods:
Make them non-static whenever you need to access non-static Members (Fields and Methods).
Make them static in any other case.

// --------------------------------------------------------------------------------------
//
//=================================================================================================== 
// DATE: 09/27/2022 
//===================================================================================================
Employee[] employees = new Employee[10];
int count = 0;

while (true)
{
    Console.WriteLine("Do you want to...");
    Console.WriteLine("1: Create a new Employee");
    Console.WriteLine("2: Print all Employees");
    string option = Console.ReadLine();
    if (option == "1")
    {
        // create new employee
        Employee e = new Employee();
        Console.WriteLine("Name?");
        e.name = Console.ReadLine();
        Console.WriteLine("Salary?");
        e.salary = Convert.ToInt32(Console.ReadLine());
        employees[count] = e;
        count++;
    }

    if (option == "2")
    {
        for (int i = 0; i < count; i++)
        {
            Employee e = employees[i];
            Console.WriteLine($"Employee: {e.name} Salary: {e.salary}");
        }
    }
}

public class Employee
{
    public string name;
    public int salary;
}

// --------------------------------------------------------------------------------------

for (int i = 0; i < employees.Length; i++)
        {
            if (employees[i] == null)
            {
                employees[i] = e;
                break;
            }
        }




// --------------------------------------------------------------------------------------

Employee[] employees = new Employee[10];

while (true)
{
    Console.WriteLine("Do you want to...");
    Console.WriteLine("1: Create a new Employee");
    Console.WriteLine("2: Print all Employees");
    string option = Console.ReadLine();
    if (option == "1")
    {
        Console.WriteLine("Creating Employee...");
        // create new employee
    }

    if (option == "2")
    {
        Console.WriteLine("Printing Employees...");
        // print all employees
    }
}

public class Employee
{
    public string name;
    public int salary;
}




// --------------------------------------------------------------------------------------

Animal a = new Animal();
Animal b = new Animal();
a.age = 12;
a.name = "Bello";
a.Sleep();
a.Sleep();
b.Sleep();

public class Animal {
    public string name;
    public int age;
    public bool isSleeping;
    public void Sleep()
    {
        if (isSleeping) return;
        Console.WriteLine($"{name} ({age}) takes a small nap.");
        isSleeping = true;
    }
}

// --------------------------------------------------------------------------------------

Animal animal = new Animal();
animal.age = 12;
animal.name = "Bello";
animal.Sleep();
animal.Sleep();

public class Animal {
    public string name;
    public int age;
    public bool isSleeping;
    public void Sleep()
    {
        if (isSleeping) return;
        Console.WriteLine($"{name} ({age}) takes a small nap.");
        isSleeping = true;
    }
}


// --------------------------------------------------------------------------------------

Animal myPet = new Animal();
myPet.name = "Bello";
Animal yourPet = new Animal();
yourPet.name = "Burger";
myPet.Sleep();
yourPet.Sleep();
public class Animal {
    public string name;
    public void Sleep() {
        Console.WriteLine($"{name} takes a small nap.");
    }
}

// --------------------------------------------------------------------------------------
Animal pet = new Animal(); //pet:#001
pet.name = "Bello"; //#001:"Bello"
pet = new Animal(); //pet:#002
pet.Sleep();
public class Animal {
    public string name;
    public void Sleep() {
        Console.WriteLine($"{name} takes a small nap.");
    }
}

// --------------------------------------------------------------------------------------

Animal pet = new Animal();
pet.name = "Bello";
pet.Sleep();

public class Animal {
    public string name;
    public void Sleep() {
        Console.WriteLine($"{name} takes a small nap.");
    }
}

// --------------------------------------------------------------------------------------

Animal myPet = new Animal();
myPet.Sleep();
public class Animal
{
    public void Sleep() {
        Console.WriteLine($"The animal takes a nap.");
    }
}

// --------------------------------------------------------------------------------------

Animal myPet = new Animal(); // myPet: #001
myPet.name = "Rex"; // #001: Rex
Animal yourPet = myPet; //yourPet: #001
Animal theirPet = yourPet; //theirPet: #001
yourPet = new Animal(); //yourPet: #002
yourPet.name = "Bello"; // #002: Bello
Console.WriteLine(theirPet.name);
public class Animal
{
    public string name;
}

// --------------------------------------------------------------------------------------

Animal myPet = new Animal();
Animal yourPet = myPet;
yourPet.name = "Bello";
Console.WriteLine(myPet.name);
public class Animal
{
    public string name;
}

// --------------------------------------------------------------------------------------

Animal myPet = new Animal();
myPet.name = "Bello";
myPet = new Animal();
Console.WriteLine(myPet.name);
public class Animal
{
    public string name;
}

// --------------------------------------------------------------------------------------

Animal myPet = new Animal();
Animal yourPet = new Animal();
myPet.name = "Bello";
yourPet.name = "Rex";
Console.WriteLine($"{myPet.name} & {yourPet.name}");
public class Animal
{
    public string name;
}

// --------------------------------------------------------------------------------------

// initialize a variable of class type `Animal`
// with a new instance of the Animal class.
Animal pet = new Animal();
// assign the string "Bello" to the field `name`
// of the class instance referenced by the
// `pet` variable`
pet.name = "Bello";
// read the value of field `name` of the class instance referenced by the
// `pet` variable`
Console.WriteLine(pet.name);
public class Animal
{
    public string name;
}

// --------------------------------------------------------------------------------------

Animal pet = null;
pet = new Animal();
pet = null;
public class Animal { }

// --------------------------------------------------------------------------------------

Animal pet = null;
pet = new Animal();
pet = null;
public class Animal { }

// --------------------------------------------------------------------------------------

//=================================================================================================== 
// DATE: 09/26/2022 
//===================================================================================================

void MakeFive(int[] myNumbers)
{
    myNumbers[0] = 5;
}

int[] numbers = {20};
MakeFive(numbers);
Console.WriteLine(numbers[0]);

// --------------------------------------------------------------------------------------

Player player = new Player();
player.gold = 15;
player.health = 10;

Potion smallPotion = new Potion();
smallPotion.costs = 10;
smallPotion.healAmount = 20;
smallPotion.ownedAmount = 0;



player.Buy(smallPotion);
player.Buy(smallPotion);
player.Sell(smallPotion);
player.Buy(smallPotion);
player.Use(smallPotion);

Potion freePotion = new Potion();
freePotion.costs = 0;
freePotion.healAmount = 1;
freePotion.ownedAmount = 0;

player.Buy(freePotion);
player.Use(freePotion);


class Potion{
    public int costs;
    public int healAmount;
    public int ownedAmount;
}

class Player {

    public int health;
    public int gold;

    public void Buy(Potion potion){
        if(gold < potion.costs) return;
        gold -= potion.costs;
        potion.ownedAmount++;
    }

    public void Sell(Potion potion){
        if(potion.ownedAmount < 1) return;
        potion.ownedAmount--;
        gold += potion.costs/2;
    }

    public void Use(Potion potion){
        if(potion.ownedAmount < 1) return;
        potion.ownedAmount--;
        health += potion.healAmount;
    }
}

// --------------------------------------------------------------------------------------

Player player;
player.health = 10;
player.gold = 17;

void BuyPotion(ref Potion potion)
{
    if (player.gold < potion.costs) return;

    player.gold -= potion.costs;
    potion.ownedAmount++;
}

void SellPotion(ref Potion potion)
{
    if (potion.ownedAmount < 1) return;

    potion.ownedAmount--;
    player.gold += potion.costs / 2;
}

void UsePotion(ref Potion potion)
{
    if (potion.ownedAmount < 1) return;

    potion.ownedAmount--;
    player.health += potion.healAmount;
}

Potion smallPotion;
smallPotion.costs = 10;
smallPotion.healAmount = 20;
smallPotion.ownedAmount = 0;

BuyPotion(ref smallPotion);
BuyPotion(ref smallPotion);
SellPotion(ref smallPotion);
BuyPotion(ref smallPotion);
UsePotion(ref smallPotion);

Potion freePotion;
freePotion.costs = 0;
freePotion.healAmount = 1;
freePotion.ownedAmount = 0;

BuyPotion(ref smallPotion);
UsePotion(ref smallPotion);

struct Potion
{
    public int costs;
    public int healAmount;
    public int ownedAmount;
}

struct Player
{
    public int health;
    public int gold;
}

// --------------------------------------------------------------------------------------

//=================================================================================================== 
// DATE: 09/22/2022 
//===================================================================================================

for(int y = 0; y < 3; y++){
   for(int x = 0; x < 3; x++){
      // print current cell grid[x, y]
      // print column-separator |
   }
   // print row-separator --------
}

// --------------------------------------------------------------------------------------

// Compiles
void SayHello()
{
    Console.WriteLine("Hello!");
}
SayHello();
struct SomeStruct{}

// Doesn't Compile
void SayHello()
{
    Console.WriteLine("Hello!");
}
struct SomeStruct{}
SayHello();

// --------------------------------------------------------------------------------------

//=================================================================================================== 
// DATE: 09/22/2022 
//===================================================================================================

// store firstName, lastName, age of 10 people

Person[] persons = new Person[3];

for (int i = 0; i < 3; i++)
{
    Console.WriteLine("We're asking for Person #"+i);
    Console.WriteLine("First Name?");
    persons[i].firstName = Console.ReadLine();
    Console.WriteLine("Last Name?");
    persons[i].lastName = Console.ReadLine();
    Console.WriteLine("Age?");
    persons[i].age = Convert.ToInt32(Console.ReadLine());
}

PrintPerson(persons[0]);
PrintPerson(persons[1]);
PrintPerson(persons[2]);

void PrintPerson(Person person)
{
    Console.WriteLine($"{person.firstName} {person.lastName} is {person.age} years old.");
}

struct Person
{
    public string firstName;
    public string lastName;
    public int age;
}

// --------------------------------------------------------------------------------------

// 1. Define a Struct:
struct Person
{
    public string firstName;
    public string lastName;
    public int age;
}

// 2. Create an Array of struct type:
Person[] people = new Person[3];

// --------------------------------------------------------------------------------------

// Program without Structs

// store firstName, lastName, age of 10 people

string[] firstNames = new string[3];
string[] lastNames = new string[3];
int[] ages = new int[3];

for (int i = 0; i < 3; i++)
{
    Console.WriteLine("We're asking for Person #"+i);
    Console.WriteLine("First Name?");
    firstNames[i] = Console.ReadLine();
    Console.WriteLine("Last Name?");
    lastNames[i] = Console.ReadLine();
    Console.WriteLine("Age?");
    ages[i] = Convert.ToInt32(Console.ReadLine());
}

PrintPerson(firstNames[0], lastNames[0], ages[0]);
PrintPerson(firstNames[1], lastNames[1], ages[1]);
PrintPerson(firstNames[2], lastNames[2], ages[2]);

void PrintPerson(string firstName, string lastName, int age)
{
    Console.WriteLine($"{firstName} {lastName} is {age} years old.");
}

// --------------------------------------------------------------------------------------

// Code Sample: Structs allow us to return multiple values from a Function:
char[,] grid = new char[3,3];

for(int y =0; y < 3; y++)
    for (int x = 0; x < 3; x++)
        grid[x, y] = ' ';

PrintGrid();

Coordinate userInput = AskUserInput();
Console.WriteLine($"You chose x: {userInput.x}");
Console.WriteLine($"You chose y: {userInput.y}");
grid[userInput.x, userInput.y] = 'X';

PrintGrid();

Coordinate AskUserInput()
{
    Coordinate result;
    Console.WriteLine("Please input x coordinate.");
    result.x = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Please input y coordinate.");
    result.y = Convert.ToInt32(Console.ReadLine());
    return result;
}

void PrintGrid()
{
    Console.WriteLine($@"
{grid[0,0]}|{grid[1,0]}|{grid[2,0]}
-----
{grid[0,1]}|{grid[1,1]}|{grid[2,1]}
-----
{grid[0,2]}|{grid[1,2]}|{grid[2,2]}
");
}

struct Coordinate
{
    public int x; // field (of type int) as part of this struct
    public int y; // they act like local variables
}

// --------------------------------------------------------------------------------------

// Using a struct variable by accessing its fields:
Console.WriteLine($"You chose x: {userInput.x}");
Console.WriteLine($"You chose y: {userInput.y}");
grid[userInput.x, userInput.y] = 'X';

// --------------------------------------------------------------------------------------
// 1. Define a Structure:
struct Coordinate
{
    public int x; // field of type int
    public int y; // they act like local variables
}

// 2. Use a Structure as a Return Type of a Function:
Coordinate AskUserInput()
{
    Coordinate result;
    Console.WriteLine("Please input x coordinate.");
    result.x = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Please input y coordinate.");
    result.y = Convert.ToInt32(Console.ReadLine());
    return result;
}

// --------------------------------------------------------------------------------------
//
//=================================================================================================== 
// DATE: 09/21/2022 
//===================================================================================================

// Good
public class PlayerScript : MonoBehaviour {
   public int health; // can be configured in the inspector

   public void TakeDamage(int damage){
      health -= damage; // changes the state, which is supposed to persist until the next frame
   }
}

// Bad:
public bool PlayerScript : MonoBehaviour {
   bool pressSpace;
   bool doJump; 

   public void Update(){
      pressSpace = Input.GetKeyDown(KeyCode.H);
      doJump = pressSpace && IsGrounded();
      if(doJump){
         rigidbody.AddForce(Vector3.up);
      }
   }
}


// Better:
public bool PlayerScript : MonoBehaviour{
   public void Update(){
      bool pressSpace = Input.GetKeyDown(KeyCode.H);
      bool doJump = pressSpace && IsGrounded();
      if(doJump){
         rigidbody.AddForce(Vector3.up);
      }
   }
}

// --------------------------------------------------------------------------------------

// create an array for the cells
char[,] cells = new char[3,3];
// initialize the array with empty spaces
for (int y = 0; y < 3; y++)
{
    for (int x = 0; x < 3; x++)
    {
        cells[x, y] = ' ';
    }
}
// set some X's for testing
for (int i = 0; i < 6; i++)
{
    cells[Random.Shared.Next(0, 3),Random.Shared.Next(0, 3)] = 'X';
}
// print the grid
Console.WriteLine(
$@"
{cells[0,0]}|{cells[1,0]}|{cells[2,0]}
-----
{cells[0,1]}|{cells[1,1]}|{cells[2,1]}
-----
{cells[0,2]}|{cells[1,2]}|{cells[2,2]}
");

// check row 0: 0 1 2 
// check row 1: 3 4 5
// check row 2: 6 7 8
for (int row = 0; row < 3; row++)
{
    CheckRow(row);
}

// function to check, whether all 3 cells in one row are 'X'
void CheckRow(int row)
{
    // check all three columns of that row
    for (int col = 0; col < 3; col++)
    {
        // if any of the cells is not an 'X', return
        if (cells[col, row] != 'X')
            return;
    }
    // if we came this far, the whole row is 'X's
    Console.WriteLine($"X won in Row {row}");
}

// --------------------------------------------------------------------------------------

// create an array for the cells
char[] cells = new char[9];
// initialize the array with empty spaces
Array.Fill(cells, ' ');
// set some X's for testing
for (int i = 0; i < 6; i++)
{
    cells[Random.Shared.Next(0, 9)] = 'X';
}
// print the grid
Console.WriteLine(
$@"
{cells[0]}|{cells[1]}|{cells[2]}
-----
{cells[3]}|{cells[4]}|{cells[5]}
-----
{cells[6]}|{cells[7]}|{cells[8]}
");

// check row 0: 0 1 2 
// check row 1: 3 4 5
// check row 2: 6 7 8

for (int row = 0; row < 3; row++)
{
    CheckRow(row);
}

// function to check, whether all 3 cells in one row are 'X'
void CheckRow(int row)
{
    // check all three columns of that row
    for (int col = 0; col < 3; col++)
    {
        // if any of the cells is not an 'X', return
        if (GetCell(col, row) != 'X')
            return;
    }
    // if we came this far, the whole row is 'X's
    Console.WriteLine($"X won in Row {row}");
}

char GetCell(int x, int y){
   return cells[GetIndex(x, y)];
}

// Get the index for cell at position (x/y)
int GetIndex(int x, int y)
{
    int width = 3;
    return x + y * width;
}

// --------------------------------------------------------------------------------------

// Bonus: Filling an Array
int[] numbers = new int[500];
Array.Fill(numbers, 99);

// --------------------------------------------------------------------------------------

// simple variable
string name = "Marc";
// array type variable with array size (10)
string[] streets = new string[10];
// array type variable with initializer
string[] names = { "Marc", "Alex", "Hanna", "Siri" };
// accessing values for reading
Console.WriteLine(names[3]);
// accessing values for writing / assignment
names[1] = "Attila";
Console.WriteLine(names[1]);
// iterating over an array for reading
for (int i = 0; i < names.Length; i++)
{
    Console.WriteLine(names[i]);
}
// iterating over an array for writing / assignment
for (int i = 0; i < names.Length; i++)
{
    names[i] += "!!";
}

for (int i = 0; i < names.Length; i++)
{
    Console.WriteLine(names[i]);
}
// --------------------------------------------------------------------------------------

//=================================================================================================== 
// DATE: 09/20/2022 
//===================================================================================================

// this is, what configurable players might look like:
{
    int[] playerConfigurations = new int[players];
    for (int i = 0; i < players; i++)
    {
        Console.WriteLine($"Do you want Player #{i} to be 0: User, 1: Easy AI, 2: Hard AI?");
        playerConfigurations[i] = Convert.ToInt32(Console.ReadLine());
    }
}
// --------------------------------------------------------------------------------------

//=================================================================================================== 
// DATE: 09/19/2022 
//===================================================================================================

// Unity Script Example
using UnityEngine; // namespaces?

// public? class?     the colon? (inheritance)
public class JumpScript : MonoBehaviour
{
    public Vector3 jumpForce; // struct
    void Update() // methods? instance method?
    {
        // static classes?
        if (Input.GetKeyDown(KeyCode.Space)) // enum
        {
            // generic methods
            GetComponent<RigidBody>().AddForce(jumpForce);
        }
    }
}

// --------------------------------------------------------------------------------------

Console.WriteLine("How many names do you want to store?");
int size = Convert.ToInt32(Console.ReadLine());
string[] names = new string[size];
while (true)
{
    Console.WriteLine("Do you want to [s]tore or [r]ead a name?");
    ConsoleKey key = Console.ReadKey().Key;
    if (key == ConsoleKey.S)
    {
        Console.WriteLine("At what index?");
        int index = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("What name?");
        string name = Console.ReadLine();
        names[index] = name;
    }

    if (key == ConsoleKey.R)
    {
        Console.WriteLine("At what index?");
        int index = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Name at Index [{index}]: {names[index]}");
    }
}

// --------------------------------------------------------------------------------------

Value Types get copied/cloned when assigning them to a new variable.
Arrays are Reference Types.
Reference Types share the same reference when assigning them to a new variable. This means that changes to one of them will affect the other.

// --------------------------------------------------------------------------------------

// function:
IEnemyEnemy CreateEnemy() {
    
}

// function call:
Enemy enemy = CreateEnemy(); // cannot convert IEnemy to Enemy

// function:
Enemy CreateEnemy(){
}

// function call:
var enemy = CreateEnemy();

// --------------------------------------------------------------------------------------

string[] items = {"Mana Potion", "Health Potion", "Strength Potion"};

void Use(string item)
{
    Console.WriteLine("Using "+item);
}

void UseItem(int number){
    if(items[number] != ""){
        Use(items[number]);
        items[number] = "";
    }
}

while (true)
{
    Console.WriteLine("What item do you want to use?");
    int number = Convert.ToInt32(Console.ReadLine());
    UseItem(number);
}

// --------------------------------------------------------------------------------------

// Having multiple items. Bad approach without using Arrays:
string item1 = "Mana Potion";
string item2 = "Health Potion";
string item3 = "Strength Potion";

void Use(string item)
{
    Console.WriteLine("Using "+item);
}

void UseItem(int number){
    if(number == 1 && item1 != ""){
        Use(item1);
        item1 = "";
    }
    if(number == 2 && item2 != ""){
        Use(item2);
        item2 = "";
    }
    if(number == 3 && item3 != ""){
        Use(item3);
        item3 = "";
    }
}

while (true)
{
    Console.WriteLine("What item do you want to use?");
    int number = Convert.ToInt32(Console.ReadLine());
    UseItem(number);
}

// --------------------------------------------------------------------------------------

// [THEORY]
programs = series of instructions
if = control code-flow using conditions
goto/loops = control code-flow to repeat instructions / to loop a hundred or a million or zero times
but how do we store hundreds or millions of information?

// --------------------------------------------------------------------------------------

//=================================================================================================== 
// DATE: 09/19/2022 
//===================================================================================================
// Using `return` to break out of nested `for` loops
void Function()
{
    for (int y = 0; y < 3; y++)
    {
        for (int x = 0; x < 3; x++)
        {
            if (x == 1)
            {
                return;
            }
            Console.WriteLine($"x: {x}, y: {y}");
        }
        Console.WriteLine("End of Row.");
    }
}

Function();
Console.WriteLine("End of App.");

// --------------------------------------------------------------------------------------

// Using `goto` to break out of nested for loops
for (int y = 0; y < 3; y++)
{
    for (int x = 0; x < 3; x++)
    {
        if (x == 1)
        {
            goto EndOfApp;
        }
        Console.WriteLine($"x: {x}, y: {y}");
    }
    Console.WriteLine("End of Row.");
}
EndOfApp:
Console.WriteLine("End of App.");

// --------------------------------------------------------------------------------------

for (int y = 0; y < 3; y++)
{
    for (int x = 0; x < 3; x++)
    {
        if (x == 1)
        {
            break;
        }
        Console.WriteLine($"x: {x}, y: {y}");
    }
}
// Output:
x: 0, y: 0
x: 1, y: 0
x: 2, y: 0
x: 0, y: 1
x: 1, y: 1
x: 2, y: 1
x: 0, y: 2
x: 1, y: 2
x: 2, y: 2

// --------------------------------------------------------------------------------------

// Only of the loop-block within the current iteration
for (int i = 0; i < 10; i++)
{
    if (i == 2)
        continue;
    if (i == 5)
        break;
    Console.WriteLine(i);
}
// --------------------------------------------------------------------------------------
while (true)
{
    Console.WriteLine("Give me any command.");
    string input = Console.ReadLine();
    if (input == "Quit")
    {
        break; // stops the current iteration and any further iteration
    }

    if (input == "Skip")
    {
        continue; // stops only the current iteration, but continues with next
    }

    Console.WriteLine("Received Command: "+input);
}

// Continue
for(int i = 0; i < numberOfPlayers; i++) {
  // if the player has disconnected already...
  if(PlayerIsDisconnected(i)){
    // then interrupt this loop iteration and continue with the next iteration ->
    continue;
  }
  // the code only reaches here, if the player #i has not disconnected :)
  SpawnPlayer(i);
  
  // -> the next iteration will begin after the end
}

// --------------------------------------------------------------------------------------
int matches = 7;
for ( int count = 0; count < matches; count++)
{
    Console.Write("|");
}
Console.WriteLine();
Console.WriteLine("That's all!");
// ----------
int matches = 7;
Console.WriteLine(new string('|', matches));
Console.WriteLine("That's all!");
// ----------

Console.WriteLine(new string(Enumerable.Repeat('|', 7).ToArray()));

// --------------------------------------------------------------------------------------

//=================================================================================================== 
// DATE: 09/15/2022 
//===================================================================================================
// Code Sample: A typical use case for a for Loop:
int matches = 7;
int count = 0; // initialization
while (count < matches) // loop-condition
{
    Console.Write("|");
    count++; // iteration
}
Console.WriteLine();
Console.WriteLine("That's all!");

// Code Sample: For Loop Syntax
for ( /*initialization*/; /*loop-condition*/; /*iteration*/)
{
    
}

// --------------------------------------------------------------------------------------

for(Console.WriteLine("Let's start!"); Random.Shared.NextDouble() < 0.99;Console.WriteLine("Hello!")) {
    
}

// --------------------------------------------------------------------------------------

bool GetRollSuccessful(float chance)
{
    float random = Random.Shared.NextSingle();
    return random < chance;
}

int trueCount = 0, falseCount = 0;
for (int i = 0; i < 100000; i++)
{
    if (GetRollSuccessful(0.5f))
        trueCount++;
    else
        falseCount++;
}

Console.WriteLine(trueCount);
Console.WriteLine(falseCount);

// --------------------------------------------------------------------------------------

bool GetRollSuccessful(double chance)
    => Random.Shared.NextDouble() < chance;

// --------------------------------------------------------------------------------------

bool GetRollSuccessful(double chance)
{
    double random = Random.Shared.NextDouble();
    return random < chance;
}

// --------------------------------------------------------------------------------------

string GetAnswer(string question)
{
    Console.WriteLine(question);
    return Console.ReadLine();
}

// --------------------------------------------------------------------------------------

//=================================================================================================== 
// DATE: 09/13/2022 
//===================================================================================================

void PrintMatches()
{
    if (Random.Shared.Next(0, 10) == 5)
    {
        Console.WriteLine("Crash.");
    }
    Console.WriteLine("|||||||||||");
}

void AITurn()
{
    PrintMatches();
}

void PlayerTurn()
{
    PrintMatches();
}

GameLoop:
PlayerTurn();
AITurn();
goto GameLoop;

// --------------------------------------------------------------------------------------

When Function X ends, it gets popped off the Call Stack. (Which means, that the Function that's below will get executed next)
// ---
X is on top of the call stack. So it gets executed (the next expression gets evaluated). Line by line.
// ---
Function X is invoked. Which pushes it on top of the Call Stack.

// --------------------------------------------------------------------------------------

void FunctionName()
{
    // write code from the function here
}

FunctionName();
// --------------------------------------------------------------------------------------
// Example: Accessing a variable from within a function
{
    int a = 3;
    void ChangeAToBeFive()
    {
        a = 5;
    }

    Console.WriteLine(a);
    ChangeAToBeFive();
    Console.WriteLine(a);
}

// --------------------------------------------------------------------------------------

//=================================================================================================== 
// DATE: 09/12/2022 
//===================================================================================================
int number = Random.Shared.Next(1, 101);
AskAgain:
int guess = Convert.ToInt32(Console.ReadLine());

if (guess != number)
{
    if (number < guess)
    {
        Console.WriteLine("The number is smaller.");
    }
    else
    {
        Console.WriteLine("The number is greater.");
    }
    goto AskAgain;
}
Console.WriteLine("It's the same. The End.");

// ---------
int number = Random.Shared.Next(1, 101);
int guess;
do
{
    guess = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(number < guess ? "The number is smaller." : "The number is greater.");
} while (guess != number);
Console.WriteLine("It's the same. The End.");
// ---------
int number = Random.Shared.Next(1, 101);
int guess = -1;

while (guess != number)
{
    guess = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(number < guess ? "The number is smaller." : "The number is greater.");
}
Console.WriteLine("It's the same. The End.");
// ---------
int number = Random.Shared.Next(1, 101);
AskAgain:
int guess = Convert.ToInt32(Console.ReadLine());

if (guess != number)
{
    Console.WriteLine(number < guess ? "The number is smaller." : "The number is greater.");
    goto AskAgain;
}
Console.WriteLine("It's the same. The End.");

// --------------------------------------------------------------------------------------

//=================================================================================================== 
// DATE: 09/08/2022 
//===================================================================================================
Console.WriteLine("What's your age?");
int age = Convert.ToInt32(Console.ReadLine());
if (age < 18)
{
    Console.WriteLine("Get out of here, kiddo!");
}
else // age >= 18
{
    Console.WriteLine("Welcome in!");
}

// --------------------------------------------------------------------------------------

// not required to know this, yet:
Number a = default;
Number b = default;
Number c = a + b;

public struct Number
{
    public int value;

    public static Number operator +(Number a, Number b)
    {
        return new Number
        {
            value = a.value + b.value
        };
    }
}

// --------------------------------------------------------------------------------------

//=================================================================================================== 
// DATE: 09/06/2022 
//===================================================================================================

// Asks the user for his age
Console.WriteLine("What's your age?");
string ageInput = Console.ReadLine();
int age = Convert.ToInt32(ageInput);
Console.Write("Next year, you'll be: ");
Console.WriteLine(age+1);

// --------------------------------------------------------------------------------------

//=================================================================================================== 
// DATE: 08/30/2022 
//===================================================================================================
    void Update()
    {
        Vector2 newVelocity = new Vector2(); // vector2d literal
        newVelocity.x = 5f; // vector2d set x
        newVelocity.y = _rigidbody2D.velocity.y; 
        // vector2d set y / rigidbody2d get velocity / vector2d get y
        _rigidbody2D.velocity = newVelocity; // rigidbody2d set velocity
    }

// --------------------------------------------------------------------------------------


//=================================================================================================== 
// DATE: 08/30/2022 
//===================================================================================================

// Completely undoing a commit:
In Fork:
-Right-Click on Old Commit
-Reset main to here
-Hard
-Push [force push]
