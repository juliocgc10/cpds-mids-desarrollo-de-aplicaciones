using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Entities
{
    public abstract class Person : INotifyPropertyChanged
    {
        #region Fields
        private String name;
        private String secondName;
        private String lastName;
        private DateTime birthday;
        private String rfc;
        private string email;
        private string phoneNumber;

        public event PropertyChangedEventHandler PropertyChanged;
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
        #endregion

        #region Constructors
        public Person()
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
