using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Lab2.XmlProcessing;

namespace Lab2.ViewModels
{
    public class TransformViewModel : INotifyPropertyChanged
    {
        private string SelectedMethod;
        private string xmlPath;
        public ICommand TransformCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Dictionary<string, IXmlProcessingStrategy> _strategies;

        public TransformViewModel(FileLoaderViewModel fileLoader)
        {
            fileLoader.FileLoaded += OnFileLoaded;
            xmlPath = fileLoader.XmlFilePath;

            _strategies = new Dictionary<string, IXmlProcessingStrategy>
            {
                { "SAX", new SaxProcessingStrategy() },
                { "LINQ", new LinqToXmlProcessingStrategy() },
                { "DOM", new DomProcessingStrategy() }
            };

            TransformCommand = new Command(ExecuteTransform, CanExecuteTransform);
        }

        private void OnFileLoaded(string filePath)
        {
            xmlPath = filePath;
            OnPropertyChanged(nameof(xmlPath)); // Оповіщення про зміну властивості
            ((Command)TransformCommand).ChangeCanExecute(); // Оновлення доступності кнопки
        }

        public void GetSelectedMethod(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value && sender is RadioButton radioButton)
            {
                SelectedMethod = radioButton.Content.ToString();
                OnPropertyChanged(nameof(SelectedMethod));
                ((Command)TransformCommand).ChangeCanExecute();
            }
        }
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ExecuteTransform()
        {
            if (!_strategies.TryGetValue(SelectedMethod, out var strategy))
            {
                return;
            }

            string xslPath = @"D:\КНУ\Курс2\ООП\ParserLab\Lab2\Resources\Output.xslt";
            string outputHtmlPath = @"D:\КНУ\Курс2\ООП\ParserLab\Lab2\Resources\Output.html";

            if (SelectedMethod == "LINQ")
            {
                strategy.Process(xmlPath, xslPath, outputHtmlPath);
            }
            else if (SelectedMethod == "SAX")
            {
                strategy.Process(xmlPath, xslPath, outputHtmlPath);
            }
            else if (SelectedMethod == "DOM")
            {
                strategy.Process(xmlPath, xslPath, outputHtmlPath);

            }
        }

        private bool CanExecuteTransform()
        {
            return !string.IsNullOrEmpty(SelectedMethod) && !string.IsNullOrEmpty(xmlPath);
        }
    }

}