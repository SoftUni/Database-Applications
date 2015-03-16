using System;
using System.Xml.Linq;

class LINQtoXMLNamespaces
{
    static void Main(string[] args)
    {
        XNamespace ns = "http://linqinaction.net";
        XNamespace anotherNs = "http://publishers.org";

        var books = new XElement(XName.Get("books", "http://bookstore.org"));
        var bookLinq = new XElement(ns + "book",
            new XElement(ns + "title", "LINQ in Action"),
            new XElement(ns + "author", "Manning"),
            new XElement(ns + "author", "Steve Eichert"),
            new XElement(ns + "author", "Jim Wooley"),
            new XElement(anotherNs + "publisher", "Manning")
        );
        books.Add(bookLinq);

        var bookXml = new XElement(ns + "book",
            new XElement(ns + "title", "Beginning XML, 5th Edition"),
            new XElement(ns + "author", "Joe Fawcett, Danny Ayers, Liam R. E. Quin"),
            new XElement(anotherNs + "publisher", "Wrox")
        );
        books.Add(bookXml);

        Console.WriteLine(books);

        books.Save("../../books.xml");
    }
}
