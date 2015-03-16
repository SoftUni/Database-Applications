using System;
using Transactions_in_EF_Example;

class TransactionsInEFExample
{
    static void Main()
    {
        InsertTownAddressEvent();

        // This will fail due to unique constraint (duplicated event)
        InsertTownAddressEvent();
    }

    private static void InsertTownAddressEvent()
    {
        var context = new SoftUniEntities();

        var town = new Town();
        town.Name = "Developer City " + DateTime.Now.Ticks;
        context.Towns.Add(town);

        var addr = new Address();
        addr.AddressText = (DateTime.Now.Ticks % 1000) + ", Developer Rd.";
        addr.Town = town;
        context.Addresses.Add(addr);

        var ev = new Event();
        ev.Address = addr;
        ev.Name = "Party";
        ev.Date = new DateTime(2015, 1, 1);
        context.Events.Add(ev);

        Console.WriteLine("Inserting new town, address and event...");
        context.SaveChanges();
        Console.WriteLine("Done.");
    }
}
