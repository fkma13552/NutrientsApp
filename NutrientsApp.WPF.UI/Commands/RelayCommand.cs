using System;
using System.Threading.Tasks;
using System.Windows.Input;
using NutrientsApp.WPF.UI.Annotations;

namespace NutrientsApp.WPF.UI.Commands
{
    public class RelayCommand : ICommand
    {
        private Task<Action<object>> execute;
        private Func<object, bool> canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Task<Action<object>> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object? parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public async void Execute(object? parameter)
        {
            await this.execute(parameter);
        }
        

    }
}