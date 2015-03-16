using System;
using System.Transactions;
using System.Data.SqlClient;

class TransactionScopeExample
{
    private const string CONNECTION_STRING = @"Server=(localdb)\MSSQLLocalDB; " +
        "Database=SoftUni; Integrated Security=true";

    static void Main()
    {
        SqlConnection dbCon = new SqlConnection(CONNECTION_STRING);
        using (dbCon)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                dbCon.Open();
                try
                {
                    Console.WriteLine("Transaction started.");

                    SqlCommand cmd = dbCon.CreateCommand();
                    cmd.CommandText = "INSERT INTO Towns(Name) VALUES ('New Town')";
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Inserted a new record.");

                    // This insert will fail (CompanyName cannot be null)
                    cmd.CommandText = "INSERT INTO Towns(Name) VALUES (NULL)";
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Inserted a new record.");

                    transaction.Complete();
                    Console.WriteLine("Transaction committed.");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Exception occurred: {0}", e.Message);
                    Console.WriteLine("Transaction cancelled.");
                }
            }
        }
    }
}
