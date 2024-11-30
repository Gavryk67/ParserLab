using System;
using System.Xml;
using System.Xml.Xsl;

namespace Lab2.XmlProcessing
{
    public class SaxProcessingStrategy : IXmlProcessingStrategy
    {
        public void Process(string xmlFilePath, string xslFilePath, string htmlFilePath)
        {
            try
            {
                string modifiedXmlPath = @"D:\КНУ\Курс2\ООП\ParserLab\Lab2\Resources\Modified_SAX.xml";

                using (XmlReader reader = XmlReader.Create(xmlFilePath))
                using (XmlWriter writer = XmlWriter.Create(modifiedXmlPath, new XmlWriterSettings { Indent = true }))
                {
                    writer.WriteStartDocument();

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "book")
                        {
                            writer.WriteStartElement("book");
                            writer.WriteAttributes(reader, true);

                            writer.WriteStartElement("processedBy");
                            writer.WriteString("SAX");
                            writer.WriteEndElement();
                        }
                        else if (reader.NodeType == XmlNodeType.Element)
                        {
                            writer.WriteStartElement(reader.Name);
                        }
                        else if (reader.NodeType == XmlNodeType.Text)
                        {
                            writer.WriteString(reader.Value);
                        }
                        else if (reader.NodeType == XmlNodeType.EndElement)
                        {
                            writer.WriteEndElement();
                        }
                    }

                    writer.WriteEndDocument();
                }

                XmlTransformer.TransformXmlToHtml(xmlFilePath, xslFilePath, htmlFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка під час обробки SAX: {ex.Message}");
            }
        }
    }
}
