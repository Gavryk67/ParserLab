
using System;
using System.Linq;
using System.Xml.Linq;

namespace Lab2.XmlProcessing
{
    public class LinqToXmlProcessingStrategy : IXmlProcessingStrategy
    {
        public void Process(string xmlFilePath, string xslFilePath, string htmlFilePath)
        {
            try
            {
                var xmlDocument = XDocument.Load(xmlFilePath);

                if (!xmlDocument.Root.Elements("book").Any())
                {
                    Console.WriteLine("Файл XML не містить жодної книги.");
                    return;
                }

                Console.WriteLine("Список книг у файлі XML:");
                foreach (var book in xmlDocument.Descendants("book"))
                {
                    var title = book.Element("title")?.Value ?? "Невідомо";
                    var author = book.Attribute("author")?.Value ?? "Невідомо";
                    var genre = book.Attribute("genre")?.Value ?? "Невідомо";
                    var price = book.Element("price")?.Value ?? "Невідомо";
                    var description = book.Element("description")?.Value ?? "Немає опису";

                }

                string resultFilePath = @"D:\КНУ\Курс2\ООП\ParserLab\Lab2\Resources\Modified_LINQ.xml";
                xmlDocument.Save(resultFilePath);

                XmlTransformer.TransformXmlToHtml(resultFilePath, xslFilePath, htmlFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при обробці LINQ: {ex.Message}");
            }
        }
    }
}
