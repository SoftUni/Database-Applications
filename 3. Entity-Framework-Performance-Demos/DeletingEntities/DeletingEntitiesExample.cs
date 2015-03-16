using System;
using System.Linq;

using DeletingEntities;

using EntityFramework.Extensions;

internal class DeletingEntitiesExample
{
    private static void Main()
    {
        var empId = CreateSampleEmployee();
        DeleteEmployeeSlow(empId);

        empId = CreateSampleEmployee();
        DeleteEmployeeFastNativeSQL(empId);

        empId = CreateSampleEmployee();
        DeleteEmployeeFastEFExtended(empId);
    }

    private static int CreateSampleEmployee()
    {
        var emp = new Employee()
                      {
                          FirstName = "First",
                          MiddleName = "M.",
                          LastName = "Last",
                          AddressID = 1,
                          DepartmentID = 1,
                          HireDate = DateTime.Now,
                          JobTitle = "Freelancer",
                          Salary = 25000
                      };
        var context = new SoftUniEntities();
        context.Employees.Add(emp);
        context.SaveChanges();
        return emp.EmployeeID;
    }

    private static void DeleteEmployeeSlow(int empId)
    {
        var context = new SoftUniEntities();
        var emp = context.Employees.Find(empId);
        context.Employees.Remove(emp);
        context.SaveChanges();
    }

    private static void DeleteEmployeeFastNativeSQL(int empId)
    {
        var context = new SoftUniEntities();
        context.Database.ExecuteSqlCommand("DELETE FROM Employees WHERE EmployeeID = {0}", empId);
    }

    private static void DeleteEmployeeFastEFExtended(int empId)
    {
        var context = new SoftUniEntities();
        context.Employees.Where(e => e.EmployeeID == empId).Delete();
    }
}