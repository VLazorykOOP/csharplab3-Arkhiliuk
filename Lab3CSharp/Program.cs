using System;
using System.Collections.Generic;
using System.Linq;

class Triangle
{
    protected int a, b, c;
    protected int color;

    public Triangle(int a, int b, int c, int color)
    {
        if (a + b <= c || a + c <= b || b + c <= a)
            throw new ArgumentException("A triangle with these sides cannot exist.");
        this.a = a;
        this.b = b;
        this.c = c;
        this.color = color;
    }

    public void ShowSides()
    {
        Console.WriteLine($"Sides: a = {a}, b = {b}, c = {c}");
    }

    public int CalculatePerimeter() => a + b + c;

    public double CalculateArea()
    {
        double s = CalculatePerimeter() / 2.0;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    public int A
    {
        get => a;
        set
        {
            if (!IsValidTriangle(value, b, c))
                throw new ArgumentException("Invalid value for side a.");
            a = value;
        }
    }

    public int B
    {
        get => b;
        set
        {
            if (!IsValidTriangle(a, value, c))
                throw new ArgumentException("Invalid value for side b.");
            b = value;
        }
    }

    public int C
    {
        get => c;
        set
        {
            if (!IsValidTriangle(a, b, value))
                throw new ArgumentException("Invalid value for side c.");
            c = value;
        }
    }

    private bool IsValidTriangle(int a, int b, int c) => a + b > c && a + c > b && b + c > a;

    public int Color => color;
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void Show()
    {
        Console.WriteLine($"Person Name: {Name}, Age: {Age}");
    }
}

class Worker : Person
{
    public string Position { get; set; }

    public Worker(string name, int age, string position) : base(name, age)
    {
        Position = position;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Position: {Position}");
    }
}

class Engineer : Worker
{
    public string Field { get; set; }

    public Engineer(string name, int age, string position, string field) : base(name, age, position)
    {
        Field = field;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Field of Engineering: {Field}");
    }
}

class Program
{
    static void Main()
    {
        // Demonstration for Task 1: Triangles
        Console.WriteLine("Task 1: Triangle information:");
        List<Triangle> triangles = new List<Triangle>
        {
            new Triangle(3, 4, 5, 0xFF0000),
            new Triangle(5, 12, 13, 0x00FF00),
            new Triangle(8, 15, 17, 0x0000FF)
        };

        foreach (var triangle in triangles)
        {
            triangle.ShowSides();
            Console.WriteLine($"Perimeter: {triangle.CalculatePerimeter()}");
            Console.WriteLine($"Area: {triangle.CalculateArea()}");
            Console.WriteLine($"Color: {triangle.Color:X6}");
            Console.WriteLine();
        }

        // Demonstration for Task 2: Persons hierarchy
        Console.WriteLine("Task 2: Persons hierarchy:");
        List<Person> persons = new List<Person>
        {
            new Worker("John", 25, "Developer"),
            new Engineer("Alice", 30, "Senior Developer", "Software"),
            new Person("Bob", 20)
        };

        // Sorting by Age as an example criterion
        var sortedPersons = persons.OrderBy(p => p.Age).ToList();

        foreach (var person in sortedPersons)
        {
            person.Show();
            Console.WriteLine();
        }
    }
}