using System;
using System.Windows.Input;

namespace HealthDivineSysClient.ViewModel.ViewModelTemplates
{
    public class RelayCommand : ICommand
    {

        //Fields
        private readonly Action<object>? _execute;
        private readonly Predicate<object>? _canExecute;

        //Constructors
        public RelayCommand(Action<object> execute)
        {
            _execute = execute;
            _canExecute = null;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        //Events
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Methods
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

    }
}
