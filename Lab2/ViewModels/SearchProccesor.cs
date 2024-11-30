using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Xml.Linq;

namespace Lab2.ViewModels
{
    public class SearchProcessor
    {
        private readonly string _xmlFilePath;
        private readonly ObservableCollection<SearchParameter> _searchParameters;

        public SearchProcessor(string xmlFilePath, ObservableCollection<SearchParameter> searchParameters)
        {
            _xmlFilePath = xmlFilePath;
            _searchParameters = searchParameters;
        }

        public ObservableCollection<SearchResult> ExecuteSearch()
        {
            var results = new ObservableCollection<SearchResult>();

            if (string.IsNullOrEmpty(_xmlFilePath) || !_searchParameters.Any())
                return results;

            try
            {
                var doc = XDocument.Load(_xmlFilePath);

                var elements = doc.Descendants("book");
                foreach (var parameter in _searchParameters)
                {
                    elements = elements.Where(e => e.Attributes()
                        .Any(attr => attr.Name.LocalName == parameter.Attribute && attr.Value == parameter.Value));
                }

                foreach (var element in elements)
                {
                    var result = new SearchResult
                    {
                        Attributes = element.Attributes().ToDictionary(a => a.Name.LocalName, a => a.Value),
                        Children = element.Elements().ToDictionary(c => c.Name.LocalName, c => c.Value)
                    };
                    results.Add(result);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Search error: {ex.Message}");
            }

            return results;
        }
    }

    public class SearchResult
    {
        public Dictionary<string, string> Attributes { get; set; }
        public Dictionary<string, string> Children { get; set; }
    }
}
