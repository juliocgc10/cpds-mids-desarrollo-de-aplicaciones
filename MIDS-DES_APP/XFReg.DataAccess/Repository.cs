using System;
using System.Collections.Generic;
using System.Linq;
using XFReg.DataAccess.DataContext;

namespace XFReg.DataAccess
{
    public class Repository
    {
        private Entities.Employee ConvertToEntitiesEmployee(Employee emp)
        {
            return new Entities.Employee()
            {
                Birthday = emp.Birthday,
                Department = emp.Department,
                Email = emp.Email,
                EmployeeNumber = emp.EmployeeID,
                JobEmail = emp.JobEmail,
                JobPhoneNumber = emp.JobPhoneNumber,
                JobPosition = emp.JobPosition,
                LastName = emp.LastName,
                Name = emp.Name,
                Password = emp.Password,
                PhoneNumber = emp.PhoneNumber,
                Rfc = emp.RFC,
                SecondName = emp.SecondName
            };

        }

        private Employee ConvertFromEntitiesEmploye(Entities.Employee emp)
        {
            return new Employee()
            {

                Birthday = emp.Birthday,
                Department = emp.Department,
                Email = emp.Email,
                EmployeeID = emp.EmployeeNumber,
                JobEmail = emp.JobEmail,
                JobPhoneNumber = emp.JobPhoneNumber,
                JobPosition = emp.JobPosition,
                LastName = emp.LastName,
                Name = emp.Name,
                Password = emp.Password,
                PhoneNumber = emp.PhoneNumber,
                RFC = emp.Rfc,
                SecondName = emp.SecondName
            };
        }


        private void ConvertFromEntitiesEmploye(Entities.Employee emp, ref Employee empDB)
        {

            empDB.Birthday = emp.Birthday;
            empDB.Department = emp.Department;
            empDB.Email = emp.Email;
            empDB.EmployeeID = emp.EmployeeNumber;
            empDB.JobEmail = emp.JobEmail;
            empDB.JobPhoneNumber = emp.JobPhoneNumber;
            empDB.JobPosition = emp.JobPosition;
            empDB.LastName = emp.LastName;
            empDB.Name = emp.Name;
            empDB.Password = emp.Password;
            empDB.PhoneNumber = emp.PhoneNumber;
            empDB.RFC = emp.Rfc;
            empDB.SecondName = emp.SecondName;


        }
        public List<Entities.Employee> GetEmployees()
        {
            try
            {
                List<Entities.Employee> employees = new List<Entities.Employee>();
                using (cpdsEntities contex = new cpdsEntities())
                {
                    contex.Employee.ToList().ForEach(emp =>
                        {
                            employees.Add(ConvertToEntitiesEmployee(emp));
                        }
                    );
                }

                return employees;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Entities.Employee GetEmployeById(int employeeID)
        {
            try
            {
                using (cpdsEntities context = new cpdsEntities())
                {
                    if (context.Employee.Any(x => x.EmployeeID == employeeID))
                    {
                        return ConvertToEntitiesEmployee(context.Employee.FirstOrDefault(x => x.EmployeeID == employeeID));
                    }
                    return new Entities.Employee();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Entities.Employee InsertEmployee(Entities.Employee emp)
        {

            try
            {
                using (cpdsEntities context = new cpdsEntities())
                {
                    Employee newEmp = ConvertFromEntitiesEmploye(emp);
                    context.Employee.Add(newEmp);
                    context.SaveChanges();

                    emp.EmployeeNumber = newEmp.EmployeeID;
                    return emp;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Entities.Employee UpdateEmployee(Entities.Employee emp)
        {
            try
            {
                using (cpdsEntities context = new cpdsEntities())
                {
                    if (context.Employee.Any(x => x.EmployeeID == emp.EmployeeNumber))
                    {
                        Employee modEmp = context.Employee.FirstOrDefault(x => x.EmployeeID == emp.EmployeeNumber);
                        ConvertFromEntitiesEmploye(emp, ref modEmp);
                        context.SaveChanges();
                        return emp;

                    }

                    return new Entities.Employee();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Entities.Employee DeleteEmployee(int employeeID)
        {
            try
            {
                using (cpdsEntities context = new cpdsEntities())
                {
                    if (context.Employee.Any(x => x.EmployeeID == employeeID))
                    {
                        Employee deleteEmp = context.Employee.FirstOrDefault(x => x.EmployeeID == employeeID);

                        context.Employee.Remove(deleteEmp);
                        context.SaveChanges();
                    }
                    return new Entities.Employee();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
