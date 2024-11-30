using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Lab2.ViewModels
{
    public abstract class PickerViewModelBase : BaseViewModel
    {
        public ObservableCollection<string> Items { get; } = new();

        private string _selectedItem;
        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged();
                    OnSelectedItemChanged();
                }
            }
        }
        public abstract void LoadItems();

        protected virtual void OnSelectedItemChanged() { }
    }
}

