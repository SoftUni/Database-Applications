namespace UpdatingDeletingInserting
{
    using System;
    using System.Linq;

    using UsingEntityFrameworkModel;

    public class UpdatingDeletingInsertingData
    {
        public static void Main()
        {
            Console.WriteLine("Program started.");
            PrintLastFiveProducts();

            int newProductId = CreateNewProduct("New Project", new DateTime(2015, 03, 22));
            Console.WriteLine("Created new project.");
            PrintLastFiveProducts();

            ModifyProductName(newProductId, "new name " + DateTime.Now.Ticks);
            Console.WriteLine("Modified the project {0}.", newProductId);
            PrintLastFiveProducts();

            Console.WriteLine("Deleted the project {0}.", newProductId);
            DeleteProduct(newProductId);
            PrintLastFiveProducts();
        }

        public static void PrintLastFiveProducts()
        {
            var softUniEntities = new SoftUniEntities();
            var lastFiveProjects =
                (from p in softUniEntities.Projects
                 orderby p.StartDate descending
                 select p).Take(5);
            Console.WriteLine("Last 5 products:");
            foreach (var project in lastFiveProjects)
            {
                Console.WriteLine("{0} - {1}", project.Name, project.Description);
            }

            Console.WriteLine();
        }

        public static int CreateNewProduct(string projectName, DateTime startDate)
        {
            var softUniEntities = new SoftUniEntities();
            var newProject = new Project
            {
                Name = projectName,
                StartDate = startDate
            };

            softUniEntities.Projects.Add(newProject);
            softUniEntities.SaveChanges();

            return newProject.ProjectID;
        }

        public static void ModifyProductName(int productId, string newName)
        {
            var softUniEntities = new SoftUniEntities();
            Project project = GetProductById(softUniEntities, productId);
            project.Name = newName;
            softUniEntities.SaveChanges();
        }

        public static void DeleteProduct(int productId)
        {
            var softUniEntities = new SoftUniEntities();
            Project project = GetProductById(softUniEntities, productId);
            softUniEntities.Projects.Remove(project);
            softUniEntities.SaveChanges();
        }

        public static Project GetProductById(SoftUniEntities entity, int projectId)
        {
            Project project = entity.Projects
                .FirstOrDefault(p => p.ProjectID == projectId);

            return project;
        }
    }

}