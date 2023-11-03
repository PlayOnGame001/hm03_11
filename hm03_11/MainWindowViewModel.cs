using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace hm03_11
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            CurrentName = "";
            CurrentSurname = "";
        }

        public string? CurrentSurname
        {
            get
            {
                return _currentSurname;
            }
            set
            {
                _currentSurname = value;
                RaisePropertyChanged(nameof(CurrentSurname));
            }
        }
        private string? _currentName;

        public string? CurrentName
        {
            get
            {
                return _currentName;
            }
            set
            {
                _currentName = value;
                RaisePropertyChanged(nameof(CurrentName));
            }
        }
        private string? _currentSurname;

        private ObservableCollection<Person> _persons = new ObservableCollection<Person>();

        public ObservableCollection<Person> Persons
        {
            get
            {
                return _persons;
            }
            set
            {
                _persons = value;
                // Вызов следующего метода нужен только если свойству присвоить новую коллекцию
                // При изменении текущей коллекции, она сама будет оповещать подписчика (ListBox)
                // о своем изменении
                RaisePropertyChanged(nameof(Persons));
            }
        }

        private DelegateCommand? _AddPersonCommand;
        public ICommand AddPerson
        {
            get
            {
                if (_AddPersonCommand == null)
                {
                    _AddPersonCommand = new DelegateCommand(Add, CanAdd);
                }
                return _AddPersonCommand;
            }
        }
        private void Add(object? parameter)
        {
            Persons.Add(new Person() { Name = CurrentName, Surname = CurrentSurname });
            CurrentName = "";
            CurrentSurname = "";
        }

        private bool CanAdd(object? parameter)
        {
            if (CurrentName == "" || CurrentSurname == "")
                return false;
            return true;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}