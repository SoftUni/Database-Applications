using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ResolvingTheNplus1QueryProblem;

class SolvingTheNplus1QueryProblem
{
	static void Main()
	{
        PrintEmployeesWithNPlusOneQueryProblem();
        PrintEmployeesFast();
    }

    static void PrintEmployeesWithNPlusOneQueryProblem()
    {
        // We have N+1 query problem: 3*N + 1 queries will be executed
        // Foreach context.Employees will execute SELECT * FROM Employees
        // Accessing emp.Department will execute SELECT * FROM Departments
        // Accessing emp.Address will execute SELECT * FROM Addresses
        // Accessing emp.Address.Town execute will SELECT * FROM Towns

        Console.WriteLine("List employees (with N+1 query problem):");
        var emps = new List<string>();
        var startTime = DateTime.Now;
        var context = new SoftUniEntities();
        foreach (var emp in context.Employees)
        {
            emps.Add(String.Format("Employee: Name = {0}; Dept = {1}; Town = {2}",
              emp.LastName, emp.Department.Name, emp.Address.Town.Name));
        }
        Console.WriteLine("Time elapsed: {0}", DateTime.Now - startTime);
        Console.WriteLine(String.Join("\n", emps.Take(5)));
        Console.WriteLine("...");
        Console.WriteLine();
    }

    static void PrintEmployeesFast()
    {
        Console.WriteLine("List employees (without N+1 query problem):");
        var emps = new List<string>();
        var startTime = DateTime.Now;
        var context = new SoftUniEntities();
        foreach (var emp in context.Employees.Include(e => e.Department).Include(e => e.Address.Town))
        {
            emps.Add(String.Format("Employee: Name = {0}; Dept = {1}; Town = {2}",
                emp.LastName, emp.Department.Name, emp.Address.Town.Name));
        }
        Console.WriteLine("Time elapsed: {0}", DateTime.Now - startTime);
        Console.WriteLine(String.Join("\n", emps.Take(5)));
        Console.WriteLine("...");
        Console.WriteLine();
    }
}
