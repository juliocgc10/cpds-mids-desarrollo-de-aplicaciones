using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Entities
{
    public sealed class Employee : Person
    {

        #region Fields
        private String employeeNumber;
        private String department;
        private String jobPosition;
        private String jobEmail;
        private String jobPhoneNumber;
        private String password;
        #endregion

        #region Properties
        public String EmployeeNumber
        {
            get => employeeNumber;

            set
            {
                employeeNumber = value;
                base.OnPropertyChanged();
            }
        }
        public String JobEmail
        {
            get => jobEmail;
            set
            {
                jobEmail = value;
                base.OnPropertyChanged();
            }
        }
        public String Department
        {
            get => department;
            set
            {
                department = value;
                base.OnPropertyChanged();
            }
        }
        public String JobPosition
        {
            get => jobPosition;
            set
            {
                jobPosition = value;
                base.OnPropertyChanged();
            }
        }
        public String JobPhoneNumber
        {
            get => jobPhoneNumber; set
            {
                jobPhoneNumber = value;
                base.OnPropertyChanged();
            }
        }
        public String Password
        {
            get => password;
            set
            {
                password = value;
                base.OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public Employee()
        {

        }
        #endregion

        #region Methods
        private void GenerateJobEmail()
        {
            Regex reg = new Regex("[^a-zA-Z0-9]");

            String normalizedName = reg.Replace(base.Name.ToLower().Normalize(NormalizationForm.FormD), "");
            String normalizationLastName = reg.Replace(base.LastName.ToLower().Split(' ')[0].Normalize(NormalizationForm.FormD), "");

            this.jobEmail = $"{normalizedName}.{normalizationLastName}@myapp.com";
        }
        #endregion
    }
}
