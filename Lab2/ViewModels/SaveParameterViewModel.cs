using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Lab2.ViewModels
{
    public class SaveParameterViewModel
    {
        public ObservableCollection<SearchParameter> SearchParameters { get; }

        // Делегати для отримання вибраних атрибута та значення
        public Func<string> SelectedAttributeProvider { get; set; }
        public Func<string> SelectedValueProvider { get; set; }

        public ICommand SaveSearchParameterCommand { get; }

        public SaveParameterViewModel(ObservableCollection<SearchParameter> searchParameters)
        {
            SearchParameters = searchParameters;
            SaveSearchParameterCommand = new Command(SaveSearchParameter);
        }

        private void SaveSearchParameter()
        {
            var selectedAttribute = SelectedAttributeProvider?.Invoke();
            var selectedValue = SelectedValueProvider?.Invoke();

            if (!string.IsNullOrEmpty(selectedAttribute) && !string.IsNullOrEmpty(selectedValue))
            {
                if (!SearchParameters.Any(p => p.Attribute == selectedAttribute && p.Value == selectedValue))
                {
                    SearchParameters.Add(new SearchParameter
                    {
                        Attribute = selectedAttribute,
                        Value = selectedValue
                    });
                }
            }
        }
    }
}
