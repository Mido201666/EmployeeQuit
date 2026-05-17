// ============================================================
// Program.cs
// Console App: IQuittable Interface + Employee Polymorphism
// ============================================================

using System;

// ──────────────────────────────────────────────────────────
// INTERFACE: IQuittable
// Defines a contract that any "quittable" object must follow.
// Any class implementing this interface MUST provide a Quit() method.
// ──────────────────────────────────────────────────────────
public interface IQuittable
{
    // A void method that represents the action of quitting.
    // No return value; just performs the quit behavior.
    void Quit();
}


// ──────────────────────────────────────────────────────────
// CLASS: Employee
// Represents a company employee with basic personal details.
// Inherits (implements) the IQuittable interface, meaning
// it MUST provide its own version of the Quit() method.
// ──────────────────────────────────────────────────────────
public class Employee : IQuittable
{
    // Property: stores the employee's first name
    public string FirstName { get; set; }

    // Property: stores the employee's last name
    public string LastName { get; set; }

    // Property: stores the employee's ID number
    public int EmployeeId { get; set; }

    // Property: stores the employee's job title
    public string JobTitle { get; set; }

    // Property: stores the employee's hourly or monthly salary
    public double Salary { get; set; }


    // ──────────────────────────────────────
    // CONSTRUCTOR
    // Called when creating a new Employee object.
    // Accepts all fields and assigns them to the properties above.
    // ──────────────────────────────────────
    public Employee(string firstName, string lastName, int employeeId, string jobTitle, double salary)
    {
        FirstName  = firstName;
        LastName   = lastName;
        EmployeeId = employeeId;
        JobTitle   = jobTitle;
        Salary     = salary;
    }


    // ──────────────────────────────────────
    // METHOD: Quit()
    // Required by the IQuittable interface.
    // Simulates the employee submitting their resignation:
    //   - Prints a dramatic farewell message to the console.
    // ──────────────────────────────────────
    public void Quit()
    {
        // Print a resignation message using the employee's full name and job title
        Console.WriteLine($"\n📝 RESIGNATION NOTICE");
        Console.WriteLine($"──────────────────────────────");
        Console.WriteLine($"Employee : {FirstName} {LastName}");
        Console.WriteLine($"ID       : {EmployeeId}");
        Console.WriteLine($"Title    : {JobTitle}");
        Console.WriteLine($"──────────────────────────────");
        Console.WriteLine($""{FirstName} has decided to leave the company.");
        Console.WriteLine($" Effective immediately. Best of luck to the team!"");
        Console.WriteLine($"──────────────────────────────\n");
    }


    // ──────────────────────────────────────
    // METHOD: DisplayInfo()
    // A helper method to print employee details to the console.
    // Not required by IQuittable; just useful for showing employee data.
    // ──────────────────────────────────────
    public void DisplayInfo()
    {
        Console.WriteLine($"👤 {FirstName} {LastName}  |  ID: {EmployeeId}  |  {JobTitle}  |  Salary: {Salary:C}");
    }
}


// ──────────────────────────────────────────────────────────
// CLASS: Program
// The entry point of the console application.
// Demonstrates interface usage and polymorphism.
// ──────────────────────────────────────────────────────────
class Program
{
    static void Main(string[] args)
    {
        // ── SECTION 1: Create a regular Employee object ──────────
        // We instantiate a new Employee using the constructor.
        // This is the normal, concrete usage of the class.
        Employee emp1 = new Employee("Sarah", "Johnson", 1042, "Senior Developer", 9500.00);

        // Display the employee's info before they quit
        Console.WriteLine("=== EMPLOYEE BEFORE QUITTING ===");
        emp1.DisplayInfo();


        // ── SECTION 2: Polymorphism via IQuittable ────────────────
        // Here is the KEY polymorphism concept:
        // We declare a variable of type IQuittable (the interface),
        // but assign it an Employee object (the concrete class).
        // This works because Employee implements IQuittable.
        //
        // The variable `quittable` can ONLY access methods
        // defined in IQuittable — in this case, just Quit().
        IQuittable quittable = new Employee("Marcus", "Rivera", 2077, "Product Manager", 11200.00);

        // We call Quit() through the interface reference.
        // Even though the actual object is an Employee,
        // C# knows to call Employee's version of Quit() — that's polymorphism!
        Console.WriteLine("=== CALLING Quit() VIA IQuittable REFERENCE ===");
        quittable.Quit();


        // ── SECTION 3: Calling Quit() on the original Employee ───
        // We can also call Quit() directly on the emp1 Employee object
        // (not through the interface), since Employee implements it.
        Console.WriteLine("=== CALLING Quit() DIRECTLY ON Employee OBJECT ===");
        emp1.Quit();


        // ── SECTION 4: Array of IQuittable objects ───────────────
        // Another great use of polymorphism:
        // We can store multiple Employee objects in an IQuittable array.
        // Each element only exposes the Quit() method (interface contract).
        Console.WriteLine("=== MASS RESIGNATION (IQuittable array) ===");

        // Create an array of IQuittable, each holding an Employee
        IQuittable[] resignations = new IQuittable[]
        {
            new Employee("Lena",  "Park",    3001, "UX Designer",       7800.00),
            new Employee("Omar",  "Hassan",  3002, "Data Analyst",       8200.00),
            new Employee("Priya", "Sharma",  3003, "Backend Engineer",   9100.00),
        };

        // Loop through each IQuittable and call Quit() on it
        // Even though the real objects are Employee, we access them as IQuittable
        foreach (IQuittable person in resignations)
        {
            // Polymorphic call: each object runs its own Quit() implementation
            person.Quit();
        }

        // Pause so the user can read the output before the console closes
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}

