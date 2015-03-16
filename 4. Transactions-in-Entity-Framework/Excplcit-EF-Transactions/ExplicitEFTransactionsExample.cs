
using System;
using System.Linq;

using Excplcit_EF_Transactions;

class ExplicitEFTransactionsExample
{
    static void Main()
    {
        var context = new SoftUniEntities();
        using (var dbContextTransaction = context.Database.BeginTransaction())
        {
            try
            {
                context.Database.ExecuteSqlCommand("UPDATE Employees " +
                  "SET Salary = Salary * 1.2 WHERE LastName = 'Wilson'");
                
                var empsQuery = context.Employees.Where(
                  e => e.Projects.Count() >= 3);
                foreach (var emp in empsQuery)
                {
                    emp.JobTitle = "Senior " + emp.JobTitle;
                }
                context.SaveChanges();

                context.Database.ExecuteSqlCommand("UPDATE Employees " +
                  "SET Salary = NULL WHERE LastName = 'Brown'");

                dbContextTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbContextTransaction.Rollback();
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }
}
