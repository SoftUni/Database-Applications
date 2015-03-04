namespace AttachingDetachingEntities
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using UsingEntityFrameworkModel;

    public class AttachDetachEntities
    {
        public static void Main()
        {
            var projectId = 1;
            var project = GetProject(projectId);
            Console.WriteLine(project.Name);

            UpdateProject(project, project.Name + "Updated");

            var updatedProduct = GetProject(projectId);
            Console.WriteLine(updatedProduct.Name);

            PlayWithDetatch();
        }

        public static Project GetProject(int id)
        {
            using (SoftUniEntities northwindEntities = new SoftUniEntities())
            {
                Project product = northwindEntities.Projects
                    .First(p => p.ProjectID == id);

                return product;
            }
        }

        public static void UpdateProject(Project product, string newName)
        {
            using (SoftUniEntities northwindEntities = new SoftUniEntities())
            {
                northwindEntities.Projects.Attach(product); // This line is required!
                product.Name = newName;
                northwindEntities.SaveChanges();
            }
        }

        public static void PlayWithDetatch()
        {
            SoftUniEntities softUniEntities = new SoftUniEntities();
            Employee newEmployee = new Employee
            {
                FirstName = "Vladimir",
                LastName = "Georgiev",
                JobTitle = "Technical Trainer",
                DepartmentID = 1,
                HireDate = new DateTime(2013, 12, 16),
                Salary = 10000
            };
            softUniEntities.Employees.Add(newEmployee);
            softUniEntities.SaveChanges();

            // Now the employee is stored in the database. Let's print its department
            Console.WriteLine(newEmployee.Department); // prints "null"

            // Find the employee by primary key --> returns the same object (unmodified)
            // Still prints "null" (due to caching and identity resolution)
            var employeeById = softUniEntities.Employees.Find(newEmployee.EmployeeID);
            Console.WriteLine(employeeById.Department); // null (due to caching)

            // Find the product by query still uses "identity resolution" (caching)
            var employeeFromDb =
                (from emp in softUniEntities.Employees
                 where emp.EmployeeID == newEmployee.EmployeeID
                 select emp).FirstOrDefault();
            Console.WriteLine(employeeFromDb.Department); // null (due to caching)

            // Detach the object from the context --> remove it from the cache
            ((IObjectContextAdapter)softUniEntities).ObjectContext.Detach(newEmployee);

            // This change will not be tracked by the context
            newEmployee.FirstName = "Vlado";

            // This will make no changes in the DB (detatched objects are not tracked)
            softUniEntities.SaveChanges();

            // Now find the product by primary key (detached entities are not cached)
            var detachedEmployee = softUniEntities.Employees.Find(newEmployee.EmployeeID);
            Console.WriteLine(detachedEmployee.Department); // works (no caching)
        }
    }

}