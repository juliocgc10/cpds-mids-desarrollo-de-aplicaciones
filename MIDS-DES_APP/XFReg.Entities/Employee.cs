using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace XFReg.Entities
{
    public class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Fields
        private string name;
        private string secondName;
        private string lastName;
        private DateTime birthday;
        private string rfc;
        private string email;
        private string phoneNumber;
        private int employeeNumber;
        private string department;
        private string jobPosition;
        private string jobEmail;
        private string jobPhoneNumber;
        private string password;

        #endregion

        #region Properties
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string SecondName
        {
            get => secondName; set
            {
                secondName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => lastName; set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }
        public DateTime Birthday
        {
            get => birthday; set
            {
                birthday = value;
                OnPropertyChanged();
            }
        }
        public string Rfc
        {
            get => rfc; set
            {
                rfc = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => email; set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber; set
            {
                phoneNumber = value;
                OnPropertyChanged();
            }
        }
        public int EmployeeNumber
        {
            get => employeeNumber;

            set
            {
                employeeNumber = value;
                OnPropertyChanged();
            }
        }
        public string JobEmail
        {
            get => jobEmail;
            set
            {
                jobEmail = value;
                OnPropertyChanged();
            }
        }
        public string Department
        {
            get => department;
            set
            {
                department = value;
                OnPropertyChanged();
            }
        }
        public string JobPosition
        {
            get => jobPosition;
            set
            {
                jobPosition = value;
                OnPropertyChanged();
            }
        }
        public string JobPhoneNumber
        {
            get => jobPhoneNumber; set
            {
                jobPhoneNumber = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public string PhotoUrl
        {
            get => $"icon_user_{new Random().Next(1, 11)}.png";
        }

        public string FullName
        {
            get => $"{name} {secondName} {lastName}";
        }
        #endregion

        #region Constructors
        public Employee()
        {

        }
        #endregion

        #region Methods        

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
