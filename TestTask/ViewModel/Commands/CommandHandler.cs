using System;
using System.Windows.Input;

namespace TestTask.ViewModel.Commands
{
    public class CommandHandler : ICommand
    {
        private readonly Action _action;
        private readonly Func<bool> _canExecute;

        public CommandHandler(Action action)
            : this(action, null)
        {
        }

        public CommandHandler(Action action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        bool ICommand.CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                return _canExecute.Invoke();
            }

            if (_action != null)
            {
                return true;
            }

            return false;
        }

        void ICommand.Execute(object parameter)
        {
            _action?.Invoke();
        }
    }
}
