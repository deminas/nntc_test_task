using System.Windows.Input;
using TestTask.Data;
using TestTask.ViewModel.Commands;

namespace TestTask.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private string _newValue;
        IImutableList<string> _data;

        public IImutableList<string> Data
        {
            get
            {
                return _data;
            }
            private set
            {
                _data = value;
                OnPropertyChanged();
            }
        }

        public string NewValue
        {
            get
            {
                return _newValue;
            }
            set
            {
                _newValue = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            NewValue = "";
            Data = new ImutableList<string>();

            // Формирем демо данные
            Data = Data.Add("John");
            Data = Data.Add("Alice");
            Data = Data.Add("William");
            Data = Data.Add("Bob");
            Data = Data.Add("Grace");
            Data = Data.Add("Rob");
            Data = Data.Add("John");
            Data = Data.Add("Alice");
            Data = Data.Add("William");
            Data = Data.Add("Bob");
            Data = Data.Add("Grace");
            Data = Data.Add("Rob");
        }

        public ICommand ClickOkCommand => new CommandHandler(() =>
        {
            Data = Data.Add(NewValue);
            NewValue = "";
        });

        public ICommand DeleteItemCommand => new RelayCommand<int>((index) =>
        {
            Data = Data.Delete(index);
        });
    }
}
