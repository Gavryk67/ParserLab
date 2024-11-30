namespace Lab2.XmlProcessing
{
    public interface IXmlProcessingStrategy
    {
        void Process(string xmlFilePath, string xslFilePath, string htmlFilePath);
    }
}
