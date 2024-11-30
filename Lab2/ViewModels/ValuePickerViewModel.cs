using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Lab2.ViewModels
{
    public class ValuePickerViewModel : PickerViewModelBase
    {
        private readonly FileLoaderViewModel _fileLoader;
        private readonly AttributePickerViewModel _attribute;
        public string SelectedAttribute { get; private set; }

        public ValuePickerViewModel(FileLoaderViewModel fileLoader, AttributePickerViewModel AttributeSelected)
        {
            _fileLoader = fileLoader;
            _attribute = AttributeSelected;
            _attribute.AttributeSelected += OnAttributeSelected;
        }

        private void OnAttributeSelected(string selectedAttribute)
        {
            SelectedAttribute = selectedAttribute;
            LoadItems();
        }

        public override void LoadItems()
        {
            Items.Clear();

            if (!string.IsNullOrEmpty(_fileLoader.XmlFilePath) && !string.IsNullOrEmpty(SelectedAttribute))
            {
                var doc = XDocument.Load(_fileLoader.XmlFilePath);
                var values = new HashSet<string>();

                foreach (var element in doc.Descendants())
                {
                    foreach (var attribute in element.Attributes())
                    {
                        if (attribute.Name.LocalName == SelectedAttribute)
                        {
                            values.Add(attribute.Value);
                        }
                    }
                }

                foreach (var value in values)
                {
                    Items.Add(value);
                }
            }
        }
    }

}
