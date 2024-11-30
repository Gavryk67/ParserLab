using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Lab2.ViewModels
{
    public class ClearParametersViewModel
    {
        public ICommand ClearParametersCommand { get; }
        public ClearParametersViewModel(ObservableCollection<SearchParameter> searchParameters)
        {
            ClearParametersCommand = new Command(() => searchParameters.Clear());
        }
    }
}
