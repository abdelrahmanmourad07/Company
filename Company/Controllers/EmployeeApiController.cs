using Company.Models;
using System.Linq; 
using System.Web.Http;
using System.Data.Entity; 
using System.Collections.Generic;

namespace Company.Controllers
{


    [Route("api/teamwork/{action}")]
    public class EmployeeApiController : ApiController
    {
        private CompanyEntities db = new CompanyEntities();

        [HttpGet]
        public List<Employee> GetAll()
        {
            var employees = db.Employees.Include(e => e.Department)?.ToList();
            return employees;
        }


        [HttpGet]
        public List<Employee> GetDevelopers()
        {
            var employees = db.Employees.Where(x => x.Name.ToLower().Contains("developer"))?.Include(e => e.Department)?.ToList();
            return employees;
        }

        [HttpPost]
        public void Create([FromBody] Employee value)
        {
            db.Employees.Add(value);
            db.SaveChanges(); 
        }
         
    }
}
