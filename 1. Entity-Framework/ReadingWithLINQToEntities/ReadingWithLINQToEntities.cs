namespace ReadingWithLINQToEntities
{
    using System;
    using System.Data;
    using System.Linq;

    using UsingEntityFrameworkModel;

    public class ReadingLINQToEntities
    {
        public static void Main()
        {
            var softUniContext = new SoftUniEntities();
            var customer = new Town() { TownID = 3 };
            softUniContext.Entry(customer).State = EntityState.Deleted;
            softUniContext.SaveChanges();

            SelectFromSingleTable();
            SelectFromMultipleTables();
        }

        private static void SelectFromSingleTable()
        {
            var softUniContext = new SoftUniEntities();

            // Select data from sinlge table
            IQueryable<Employee> employees =
                from c in softUniContext.Employees
                where c.JobTitle == "Production Supervisor"
                select c;

            Logger.PrintQueries(employees);

            Console.WriteLine("The query is still not generated and executed.");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        private static void SelectFromMultipleTables()
        {
            var softUniContext = new SoftUniEntities();

            // Perform database SELECT from Orders joined to Customers
            var employees =
                from e in softUniContext.Employees
                where e.Department.Name == "Engineering"
                select e;

            Logger.PrintQueries(employees);

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}