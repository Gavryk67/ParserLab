using Lab2.ViewModels;

namespace Lab2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (BindingContext is MainViewModel viewModel)
            {
                viewModel.Transform.GetSelectedMethod(sender, e);
            }
        }
    }
}
