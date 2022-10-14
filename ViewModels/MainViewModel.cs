using System.Collections.ObjectModel;
using Tools.Mvvm.Commands;
using Tools.Mvvm.Observable;

namespace ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private int _value;
        private ICommand? _incrementCommand;
        private ICommand? _decrementCommand;
        private ICommand? _addCommand;

        private readonly ObservableCollection<int> _items;

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

        public ICommand? AddCommand
        {
            get
            {
                return _addCommand ??= new DelegateCommand(() => Items.Add(Value));
            }
        }

        public ObservableCollection<int> Items
        {
            get
            {
                return _items;
            }
        }

        public MainViewModel()
        {            
            _items = new ObservableCollection<int>();
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