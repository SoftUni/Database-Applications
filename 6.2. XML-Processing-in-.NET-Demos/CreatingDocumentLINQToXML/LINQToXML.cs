using System.Xml.Linq;

class CreatingDocumentLINQToXML
{
    static void Main()
    {
        var booksXml = new XElement("books",
            new XElement("book",
                new XElement("author", "Don Box"),
                new XElement("title", "ASP.NET")
            ),
            new XElement("book",
                new XElement("author", "Svetlin Nakov and team"),
                new XElement("title", "Introduction to Programming with C#")
            )
        );

        System.Console.WriteLine(booksXml);

        booksXml.Save("../../books.xml");           
    }
}
