using System;
using System.Windows.Input;

namespace Effects2000.Utils
{
    public class ParameterDelegateCommand<TParameter> : ICommand
    {
        private readonly Func<bool> canExecute;
        private readonly Action<TParameter> execute;
        public ParameterDelegateCommand(Func<bool> canExecute, Action<TParameter> execute)
        {
            if (execute == null) throw new ArgumentNullException("execute", "Cannot be null!");

            this.canExecute = canExecute;
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute();
        }

        private void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            execute((TParameter)parameter);
        }
    }
}
