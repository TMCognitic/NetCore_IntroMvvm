namespace Tools.Mvvm.Commands
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;

        public DelegateCommand(Action execute, Func<bool>? canExecute = null)
        {
            ArgumentNullException.ThrowIfNull(execute);

            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return (_canExecute is null) ? true : _canExecute();
        }

        public void Execute(object? parameter)
        {
            _execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
