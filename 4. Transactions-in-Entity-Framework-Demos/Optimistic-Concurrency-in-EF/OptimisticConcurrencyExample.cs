using System;
using System.Data.Entity.Infrastructure;
using System.Linq;

using Optimistic_Concurrency_in_EF;

class OptimisticConcurrencyExample
{
    static void Main()
    {
        CreateNewProject();
        CreateNewTown();
        EditProjectOptimisticConcurrencyLastWins();
        EditTownOptimisticConcurrencyFirstWins();
    }

    private static void CreateNewProject()
    {
        var context = new SoftUniEntities();
        var project = new Project { Name = "New Project", StartDate = DateTime.Now };
        context.Projects.Add(project);
        context.SaveChanges();
    }

    private static void EditProjectOptimisticConcurrencyLastWins()
    {
        // The first user changes some record
        var contextFirst = new SoftUniEntities();
        var lastProjectFirstUser = 
            contextFirst.Projects.OrderByDescending(p => p.ProjectID).First();
        lastProjectFirstUser.Name = "Changed by the First User";

        // The second user changes the same record
        var contextSecondUser = new SoftUniEntities();
        var lastProjectSecond =
            contextSecondUser.Projects.OrderByDescending(p => p.ProjectID).First();
        lastProjectSecond.Name = "Changed by the Second User";

        // Conflicting changes: last wins
        contextFirst.SaveChanges();
        contextSecondUser.SaveChanges();
    }

    private static void CreateNewTown()
    {
        var context = new SoftUniEntities();
        var town = new Town { Name = "New Town" };
        context.Towns.Add(town);
        context.SaveChanges();
    }

    private static void EditTownOptimisticConcurrencyFirstWins()
    {
        // The first user changes some record
        var contextFirst = new SoftUniEntities();
        var lastTownFirstUser =
            contextFirst.Towns.OrderByDescending(t => t.TownID).First();
        lastTownFirstUser.Name = "Changed by the First User";

        // The second user changes the same record
        var contextSecondUser = new SoftUniEntities();
        var lastTownSecondUser =
            contextSecondUser.Towns.OrderByDescending(t => t.TownID).First();
        lastTownSecondUser.Name = "Changed by the Second User";

        // Conflicting changes: first wins; second gets an exception
        contextFirst.SaveChanges();
        try
        {
            contextSecondUser.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Console.WriteLine("Error: concurrent change occurred.");
            Console.WriteLine(ex.Message);
        }
    }
}
