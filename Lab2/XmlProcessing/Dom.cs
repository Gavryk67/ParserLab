using System;
using System.Resources;
using System.Xml;

namespace Lab2.XmlProcessing
{
    public class DomProcessingStrategy : IXmlProcessingStrategy
    {
        public void Process(string xmlFilePath, string xslFilePath, string htmlFilePath)
        {
            try
            {
                // Завантажуємо вихідний XML-документ
                XmlDocument originalDoc = new XmlDocument();
                originalDoc.Load(xmlFilePath);

                // Створюємо новий XML-документ
                XmlDocument resultDoc = new XmlDocument();

                // Додаємо кореневий елемент <catalog>
                XmlElement catalogElement = resultDoc.CreateElement("catalog");
                resultDoc.AppendChild(catalogElement);

                // Використовуємо XPath для вибору всіх <book>
                XmlNodeList bookNodes = originalDoc.SelectNodes("//book");

                if (bookNodes != null)
                {
                    foreach (XmlNode bookNode in bookNodes)
                    {
                        // Створюємо новий вузол <book> у результаті
                        XmlElement bookElement = resultDoc.CreateElement("book");

                        // Копіюємо атрибути
                        if (bookNode.Attributes != null)
                        {
                            foreach (XmlAttribute attr in bookNode.Attributes)
                            {
                                bookElement.SetAttribute(attr.Name, attr.Value);
                            }
                        }

                        // Додаємо дочірні елементи: <title>, <price>, <description>
                        foreach (XmlNode childNode in bookNode.ChildNodes)
                        {
                            XmlElement childElement = resultDoc.CreateElement(childNode.Name);
                            childElement.InnerText = childNode.InnerText;
                            bookElement.AppendChild(childElement);
                        }

                        // Додаємо <book> до <catalog>
                        catalogElement.AppendChild(bookElement);
                    }
                }

                // Зберігаємо результат
                string resultFilePath = @"D:\КНУ\Курс2\ООП\ParserLab\Lab2\Resources\Modified_DOM.xml";
                resultDoc.Save(resultFilePath);

                XmlTransformer.TransformXmlToHtml(resultFilePath, xslFilePath, htmlFilePath);

                Console.WriteLine($"Обробка завершена. Результат збережено у файл: {resultFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка під час обробки DOM: {ex.Message}");
            }
        }
    }
}


