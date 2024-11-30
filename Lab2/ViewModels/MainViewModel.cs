using System.Collections.ObjectModel;
using System.Windows.Input;
using Lab2.XmlProcessing;

namespace Lab2.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public FileLoaderViewModel FileLoader { get; }
        public AttributePickerViewModel Attributes { get; }
        public ValuePickerViewModel Values { get; }
        public SaveParameterViewModel SaveParameter { get; }
        public ClearParametersViewModel ClearParameters { get; }
        public TransformViewModel Transform { get; }
        public ObservableCollection<SearchParameter> SearchParameters { get; } = new ObservableCollection<SearchParameter>();
        public ObservableCollection<SearchResult> SearchResults { get; } = new ObservableCollection<SearchResult>();
        public ICommand SearchCommand { get; }

        public MainViewModel()
        {
            FileLoader = new FileLoaderViewModel();
            Attributes = new AttributePickerViewModel(FileLoader, SearchParameters);
            Values = new ValuePickerViewModel(FileLoader, Attributes);

            SaveParameter = new SaveParameterViewModel(SearchParameters)
            {
                SelectedAttributeProvider = () => Attributes.SelectedItem,
                SelectedValueProvider = () => Values.SelectedItem
            };

            ClearParameters = new ClearParametersViewModel(SearchParameters);

            Transform = new TransformViewModel(FileLoader);

            SearchCommand = new Command(ExecuteSearch);
        }


        private void ExecuteSearch()
        {
            if (string.IsNullOrEmpty(FileLoader.XmlFilePath)) return;

            var searchProcessor = new SearchProcessor(FileLoader.XmlFilePath, SearchParameters);
            var results = searchProcessor.ExecuteSearch();

            SearchResults.Clear();
            foreach (var result in results)
            {
                SearchResults.Add(result);
            }
        }
    }
}
