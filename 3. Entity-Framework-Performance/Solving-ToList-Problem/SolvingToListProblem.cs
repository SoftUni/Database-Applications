using System;
using System.Linq;
using System.Collections.Generic;
using Solving_ToList_Problem;

class SolvingToListProblem
{
    static void Main()
    {
        ShowEmployeesFromRedmondSlow();
        ShowEmployeesFromRedmondFast();
    }

    private static void ShowEmployeesFromRedmondSlow()
    {
        var context = new SoftUniEntities();
        List<string> employeesFromRedmond =
            context.Employees
            .ToList()
            .OrderBy(e => e.LastName)
            .Where(e => e.Address.Town.Name == "Redmond")
            .ToList()
            .Select(e => e.LastName)
            .ToList();
        Console.WriteLine(string.Join(", ", employeesFromRedmond));
    }

    private static void ShowEmployeesFromRedmondFast()
    {
        var context = new SoftUniEntities();
        List<string> employeesFromRedmond =
            context.Employees
            .OrderBy(e => e.LastName)
            .Where(e => e.Address.Town.Name == "Redmond")
            .Select(e => e.LastName)
            .ToList();
        Console.WriteLine(string.Join(", ", employeesFromRedmond));
    }
}
