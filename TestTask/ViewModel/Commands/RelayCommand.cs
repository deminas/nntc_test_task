using System;
using System.Windows.Input;

namespace TestTask.ViewModel.Commands
{
    class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");

            if (canExecute != null)
            {
                _canExecute = canExecute;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            if (parameter == null && typeof(T).IsValueType)
            {
                return _canExecute(default);
            }

            return _canExecute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
