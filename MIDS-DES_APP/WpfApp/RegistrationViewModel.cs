using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Fields
        private bool newButtonVisibility;
        private bool editButtonvisibility;
        private bool deleteButtonVisibility;
        private bool saveButtonVisibility;
        private bool cancelButtonVisibility;

        private bool isEnabledControl;
        private Employee employee;

        private int selectedIndex;

        #endregion

        #region Properties
        public bool NewButtonVisibility
        {
            get => newButtonVisibility;
            set
            {
                newButtonVisibility = value;
                this.OnPropertyChanged();
            }
        }

        public bool EditButtonvisibility
        {
            get => editButtonvisibility;
            set
            {
                editButtonvisibility = value;
                this.OnPropertyChanged();
            }
        }

        public bool DeleteButtonVisibility
        {
            get => deleteButtonVisibility;
            set
            {
                deleteButtonVisibility = value;
                this.OnPropertyChanged();
            }
        }

        public bool SaveButtonVisibility
        {
            get => saveButtonVisibility;
            set
            {
                saveButtonVisibility = value;
                this.OnPropertyChanged();
            }
        }

        public bool CancelButtonVisibility
        {
            get => cancelButtonVisibility;
            set
            {
                cancelButtonVisibility = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsEnabledControl
        {
            get => isEnabledControl; set
            {
                isEnabledControl = value;
                this.OnPropertyChanged();
            }
        }

        public Employee Employee
        {
            get => employee;
            set
            {
                employee = value;
                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<Employee> Employees { get; set; }

        public ICommand NewEmployeeCommand { get; set; }
        public ICommand SaveEmployeeCommand { get; set; }
        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                selectedIndex = value;
                OnPropertyChanged();
                if (SelectedIndex >= 0)
                {
                    this.Employee = Employees[selectedIndex];
                }
                else
                {
                    this.Employee = new Employee() { Birthday = new DateTime(1989, 1, 1) };
                }
            }
        }
        #endregion

        #region Constructor
        public RegistrationViewModel()
        {
            DisabledEdition();
            Employees = new ObservableCollection<Employee>();
            NewEmployeeCommand = new ExecutionCommand(NewEmployee);
            SaveEmployeeCommand = new ExecutionCommand(SaveEmployee);
            this.SelectedIndex = -1;
        }
        #endregion

        #region Methods


        private void EnabledEdition()
        {
            this.NewButtonVisibility = false;
            this.EditButtonvisibility = false;
            this.DeleteButtonVisibility = false;
            this.SaveButtonVisibility = true;
            this.CancelButtonVisibility = true;
            this.IsEnabledControl = true;
        }

        private void DisabledEdition()
        {
            this.NewButtonVisibility = true;
            this.EditButtonvisibility = true;
            this.DeleteButtonVisibility = true;
            this.SaveButtonVisibility = false;
            this.CancelButtonVisibility = false;
            this.IsEnabledControl = false;
        }

        private void NewEmployee()
        {
            EnabledEdition();
            Employee = new Employee { EmployeeNumber = Guid.NewGuid().ToString() };
        }
        private void SaveEmployee()
        {
            Employees.Add(this.Employee);
            Employee = new Employee();
            DisabledEdition();
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }

    public class ExecutionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action action;
        public ExecutionCommand(Action action)
        {
            this.action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.action();
        }
    }
}
