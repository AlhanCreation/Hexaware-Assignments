using System;

// Base class Employee
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Dob { get; set; }
    public double Salary { get; set; }

    // Parameterized constructor
    public Employee(int id, string name, DateTime dob, double salary)
    {
        Id = id;
        Name = name;
        Dob = dob;
        Salary = salary;
    }


    public virtual double ComputeSalary()
    {
        return Salary;
    }

    public virtual void Display()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, DOB: {Dob.ToShortDateString()}, Salary: {Salary}");
    }
}

// Derived class Manager
class Manager : Employee
{
    public double OnsiteAllowance { get; set; }
    public double Bonus { get; set; }

    // Parameterized constructor using base constructor
    public Manager(int id, string name, DateTime dob, double salary, double onsiteAllowance, double bonus)
        : base(id, name, dob, salary)
    {
        OnsiteAllowance = onsiteAllowance;
        Bonus = bonus;
    }

    // Overriding the ComputeSalary method
    public override double ComputeSalary()
    {
        return Salary + OnsiteAllowance + Bonus;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Onsite Allowance: {OnsiteAllowance}, Bonus: {Bonus}, Total Salary: {ComputeSalary()}");
    }
}

namespace Inheritance
{


    internal class Program
    {
        static void Main()
        {
            Employee emp = new Employee(101, "John Doe", new DateTime(1990, 5, 21), 50000);
            emp.Display();
            Console.WriteLine("\n");

            Manager mgr = new Manager(201, "Alice Smith", new DateTime(1985, 3, 15), 70000, 10000, 5000);
            mgr.Display();

            Console.ReadLine(); 

            
            
        }
    }
}