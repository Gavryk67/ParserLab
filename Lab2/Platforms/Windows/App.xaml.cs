using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.UI.Xaml;
using System.Threading.Tasks;

namespace Lab2.WinUI
{
    public partial class App : MauiWinUIApplication
    {
        public App()
        {
            this.InitializeComponent();
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        /*protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);

            // Отримуємо головне вікно
            var mainWindow = Microsoft.Maui.MauiWinUIApplication.Current.Application.Windows[0].Handler.PlatformView as Microsoft.UI.Xaml.Window;

            if (mainWindow != null)
            {
                // Додаємо обробник події закриття
                mainWindow.Closed += async (sender, e) =>
                {
                    // Запобігаємо автоматичному закриттю
                    e.Handled = true;

                    // Відображаємо діалогове вікно підтвердження
                    bool shouldExit = await ShowExitConfirmationAsync();

                    if (shouldExit)
                    {
                        e.Handled = false; // Дозволяємо закриття
                    }
                };
            }
        }

        private async Task<bool> ShowExitConfirmationAsync()
        {
            string title = "Підтвердження виходу";
            string message = "Чи дійсно ви хочете завершити роботу з програмою?";
            string accept = "Так";
            string cancel = "Ні";

            // Відображення діалогового вікна через MainPage
            var result = await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);

            return result;
        }*/
    }
}
