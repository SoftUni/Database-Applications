using System;
using System.Linq;
using Solving_Select_Everything_Problem;

class SelectEverythingExample
{
    static void Main()
    {
        ShowEmployeeTotalSalariesVerySlow();
        ShowEmployeeTotalSalariesSlow();
        ShowEmployeeTotalSalariesFast();
    }

    private static void ShowEmployeeTotalSalariesVerySlow()
    {
        var context = new SoftUniDbContext();
        decimal totalSalaries = 0;
        foreach (var emp in context.Employees)
        {
            totalSalaries += emp.Salary;
        }
        Console.WriteLine("Total salaries: {0:f2}", totalSalaries);
    }

    private static void ShowEmployeeTotalSalariesSlow()
    {
        var context = new SoftUniDbContext();
        var empSalaries = context.Employees.Select(e => e.Salary);
        decimal totalSalaries = 0;
        foreach (var salary in empSalaries)
        {
            totalSalaries += salary;
        }
        Console.WriteLine("Total salaries: {0:f2}", totalSalaries);
    }

    private static void ShowEmployeeTotalSalariesFast()
    {
        var context = new SoftUniDbContext();
        decimal totalSalaries = context.Employees.Sum(e => e.Salary);
        Console.WriteLine("Total salaries: {0:f2}", totalSalaries);
    }
}
