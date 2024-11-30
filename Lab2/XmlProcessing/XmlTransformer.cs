using System.Xml;
using System.Xml.Xsl;

public class XmlTransformer
{
    public static void TransformXmlToHtml(string xmlPath, string xslPath, string outputHtmlPath)
    {
        try
        {
            XslCompiledTransform xslt = new XslCompiledTransform();

            xslt.Load(xslPath);

            xslt.Transform(xmlPath, outputHtmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка під час трансформації: " + ex.Message);
        }
    }
}
