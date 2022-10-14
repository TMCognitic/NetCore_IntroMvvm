using Tools.Mvvm.Commands;
using Tools.Mvvm.Observable;

namespace ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private int _value;
        private ICommand? _incrementCommand;
        private ICommand? _decrementCommand;

        public int Value
        {
            get
            {
                return _value;
            }

            set
            {
                if(_value != value)
                {
                    _value = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand IncrementCommand
        {
            get
            {
                return _incrementCommand ??= new DelegateCommand(Increment, CanIncrement);
            }
        }
        public ICommand DecrementCommand
        {
            get
            {
                return _decrementCommand ??= new DelegateCommand(Decrement, CanDecrement);
            }
        }

        public MainViewModel()
        {
        }

        public void Increment() // <- Execute
        {
            Value++;
        }

        public bool CanIncrement() // <- CanExecute
        {
            return Value < 9;
        }

        public void Decrement() // <- Execute
        {
            Value--;
        }

        public bool CanDecrement() // <- CanExecute
        {
            return Value > 0;
        }
    }
}