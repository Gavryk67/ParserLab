using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace Lab2.ViewModels
{    
    public class AttributePickerViewModel : PickerViewModelBase
    {
        private readonly FileLoaderViewModel _fileLoader;
        private readonly ObservableCollection<SearchParameter> _searchParameters;
        public event Action<string> AttributeSelected;

        protected override void OnSelectedItemChanged()
        {
            base.OnSelectedItemChanged();

            AttributeSelected?.Invoke(SelectedItem);
        }

        public AttributePickerViewModel(FileLoaderViewModel fileLoader, ObservableCollection<SearchParameter> searchParameters)
        {
            _fileLoader = fileLoader;
            _searchParameters = searchParameters;

            _fileLoader.FileLoaded += OnFileLoaded;
            _searchParameters.CollectionChanged += OnSearchParametersChanged;
        }

        ~AttributePickerViewModel()
        {
            _fileLoader.FileLoaded -= OnFileLoaded;
            _searchParameters.CollectionChanged -= OnSearchParametersChanged;
        }


        private void OnFileLoaded(string filePath)
        {
            LoadItems();
        }

        private void OnSearchParametersChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            LoadItems();
        }

        public override void LoadItems()
        {
            Items.Clear();

            if (!string.IsNullOrEmpty(_fileLoader.XmlFilePath))
            {
                var doc = XDocument.Load(_fileLoader.XmlFilePath);
                var attributes = new HashSet<string>();

                foreach (var element in doc.Descendants())
                {
                    foreach (var attribute in element.Attributes())
                    {
                        attributes.Add(attribute.Name.LocalName);
                    }
                }

                var usedAttributes = _searchParameters.Select(p => p.Attribute).ToHashSet();
                var availableAttributes = attributes.Except(usedAttributes);

                foreach (var attr in availableAttributes)
                {
                    Items.Add(attr);
                }
            }
        }
    }

}
