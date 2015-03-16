using System.Xml.Xsl;

class XSLTransform
{
    static void Main()
    {
        var xslt = new XslCompiledTransform();
        xslt.Load("../../catalog.xsl");
        xslt.Transform("../../catalog.xml", "../../catalog.html");
    }
}
