using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XFReg.DataAccess;
using XFReg.Entities;

namespace XFReg.WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private Repository repository;
        public EmployeeController()
        {
            repository = new Repository();
        }
        // GET api/values
        public IEnumerable<Employee> Get()
        {
            return repository.GetEmployees();
        }

        // GET api/values/5
        public Employee Get(int id)
        {
            return repository.GetEmployeById(id);
        }

        // POST api/values
        public Employee Post([FromBody] Employee value)
        {
            return repository.InsertEmployee(value);
        }

        // PUT api/values/5
        public Employee Put([FromBody] Employee value)
        {
            return repository.UpdateEmployee(value);
        }

        // DELETE api/values/5
        public Employee Delete(int id)
        {
            return repository.DeleteEmployee(id);
        }
    }
}
