namespace JoinAndGroup
{
    using System;
    using System.Linq;

    using UsingEntityFrameworkModel;

    public class JoinAndGroupExample
    {
        public static void Main()
        {
            SoftUniEntities softUniEntities = new SoftUniEntities();
            JoinEmployeesWithDepartments(softUniEntities);
            JoinEmployeesWithDepartmentsExtentedMethods(softUniEntities);
            GroupEmployeesByJobTitle(softUniEntities);
            GroupEmployeesByJobTitleExtentedMethods(softUniEntities);
        }

        public static void JoinEmployeesWithDepartments(SoftUniEntities softUniEntities)
        {
            var employees =
                from employee in softUniEntities.Employees
                join department in softUniEntities.Departments
                on employee.DepartmentID equals department.DepartmentID
                select new
                {
                    EmployeeName = employee.FirstName + " " + employee.LastName,
                    Department = department.Name,
                    Salary = employee.Salary
                };

            Logger.PrintQueries(employees);
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        public static void JoinEmployeesWithDepartmentsExtentedMethods(SoftUniEntities softUniEntities)
        {
            var employees =
            softUniEntities.Employees.Join(
                softUniEntities.Departments,
                employee => employee.DepartmentID,
                department => department.DepartmentID,
                (employee, department) => new
                {
                    CustomerName = employee.FirstName + " " + employee.LastName,
                    Department = department.Name,
                    Salary = employee.Salary
                });
            Logger.PrintQueries(employees);
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        public static void GroupEmployeesByJobTitle(SoftUniEntities softUniEntities)
        {
            var groupedEmployees =
                from employee in softUniEntities.Employees
                group employee by employee.JobTitle;

            Logger.PrintQueries(groupedEmployees);
            foreach (var employeesGroup in groupedEmployees)
            {
                Console.WriteLine(employeesGroup.Key);
                foreach (var employee in employeesGroup)
                {
                    Console.WriteLine(employee.FirstName + " " + employee.LastName);
                }

                Console.WriteLine(Logger.SeparatorLine);
            }
        }

        public static void GroupEmployeesByJobTitleExtentedMethods(SoftUniEntities softUniEntities)
        {
            var groupedEmployees = softUniEntities.Employees
                .GroupBy(customer => customer.JobTitle);
            Logger.PrintQueries(groupedEmployees);
            foreach (var employeesGroup in groupedEmployees)
            {
                Console.WriteLine(employeesGroup.Key);
                foreach (var employee in employeesGroup)
                {
                    Console.WriteLine(employee.FirstName + " " + employee.LastName);
                }
                Console.WriteLine(Logger.SeparatorLine);
            }
        }
    }
}