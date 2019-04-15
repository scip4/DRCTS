using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DRCTS.Models;

namespace DRCTS.Controllers
{
    public class EmployeeController : ApiController
    {
        drctsRepository drcRepo = new drctsRepository();
        [Authorize]
        public IEnumerable<Employee> GetAllEmployee()
        {
            return drcRepo.getEmployees();
        }
        [Authorize]
        public IEnumerable<Employee> Get(int id)
        {
            return drcRepo.getEmployeesID(id);
        }
    }
}
