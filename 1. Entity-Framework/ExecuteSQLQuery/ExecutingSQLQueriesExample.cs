namespace ExecutingSQLQueries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using UsingEntityFrameworkModel;

    public class ExecutingSQLQueriesExample
    {
        public static void Main()
        {
            int employeesCount = SelectEmployeesCount();
            Console.WriteLine("Employees count: {0}", employeesCount);

            Console.WriteLine("\nList of projects:");
            var projects = SelectTop5ProjectsIdAndName();
            foreach (var project in projects)
            {
                Console.WriteLine("{0}. {1}", project.Id, project.Name);
            }

            string jobTitle = "Production Supervisor";
            Console.WriteLine("\nList of {0}:", jobTitle);
            var employees = SelectEmployeeNamesByJobTitle("Production Supervisor");
            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }
        }

        public static int SelectEmployeesCount()
        {
            SoftUniEntities northwindEntities = new SoftUniEntities();
            string nativeSqlQuery = "SELECT count(*) FROM dbo.Employees";
            var queryResult = northwindEntities.Database.SqlQuery<int>(nativeSqlQuery);
            int customersCount = queryResult.FirstOrDefault();
            return customersCount;
        }

        public static IEnumerable<ProjectIdAndName> SelectTop5ProjectsIdAndName()
        {
            SoftUniEntities northwindEntities = new SoftUniEntities();
            string nativeSqlQuery =
                "SELECT TOP 5 ProjectID as Id, Name as Name " +
                "FROM dbo.Projects " +
                "ORDER BY ProjectID";
            var products =
                northwindEntities.Database.SqlQuery<ProjectIdAndName>(nativeSqlQuery);
            return products;
        }

        private static IEnumerable<string> SelectEmployeeNamesByJobTitle(string jobTitle)
        {
            SoftUniEntities northwindEntities = new SoftUniEntities();
            string nativeSqlQuery =
                "SELECT FirstName + ' ' + LastName " +
                "FROM dbo.Employees " +
                "WHERE JobTitle = {0}";
            object[] parameters = { jobTitle };
            var employees = northwindEntities.Database.SqlQuery<string>(nativeSqlQuery, parameters);
            return employees;
        }

        public class ProjectIdAndName
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}