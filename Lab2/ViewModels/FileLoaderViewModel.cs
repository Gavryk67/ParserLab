using System.Windows.Input;

namespace Lab2.ViewModels
{
    public class FileLoaderViewModel
    {
        public string XmlFilePath { get; private set; }
        public ICommand LoadFileCommand { get; }

        public event Action<string> FileLoaded;

        public FileLoaderViewModel()
        {
            LoadFileCommand = new Command(async () => await SelectXmlFileAsync());
        }

        private async Task SelectXmlFileAsync()
        {
            var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                { DevicePlatform.WinUI, new[] { ".xml" } }
            });

            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = customFileType,
                PickerTitle = "Виберіть XML файл"
            });

            if (result != null)
            {
                XmlFilePath = result.FullPath;
                FileLoaded?.Invoke(XmlFilePath);
            }
        }
    }
}
