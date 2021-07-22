using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPOO
{
    public class Person
    {
        #region Propiedades
        private string name;
        private string secondName;
        private string lastName;
        private DateTime birthday;
        private string rfc;


        public string Name { get => name; }
        public string SecondName { get => secondName; }
        public string LastName { get => lastName; }
        public DateTime Birthday { get => birthday; }
        public string Rfc { get => rfc; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        #endregion

        #region Constructores
        public Person()
        {

        }

        public Person(string name, string secondName, string lastName, DateTime birthday, string rfc)
        {
            this.name = name;
            this.secondName = secondName;
            this.lastName = lastName;
            this.birthday = birthday;
            this.rfc = rfc;
        }

        public Person(string name, string secondName, string lastName, DateTime birthday, string rfc, string email, string phoneNumber) :
            this(name, secondName, lastName, birthday, rfc)
        {
            this.Email = email;
            this.PhoneNumber = phoneNumber;
        }
        #endregion

        public override string ToString()
        {
            string message = $"Hola, mi nombre es {this.name} {this.secondName} {this.lastName}. Nací el {this.birthday.ToString("D", CultureInfo.CreateSpecificCulture("es-mx"))}. Y mi RFC es: {this.rfc}";
            if (string.IsNullOrWhiteSpace(this.Email) && string.IsNullOrWhiteSpace(this.PhoneNumber))
            {
                return message;
            }

            if (!string.IsNullOrWhiteSpace(this.PhoneNumber))
            {
                message = $"{message} Mi télefono es: {this.PhoneNumber}";
            }

            if (string.IsNullOrWhiteSpace(this.Email))
            {
                message = $"{message} Mi correo es: {this.Email}";
            }
            NormalizationForm

            return message;


        }
    }
}
