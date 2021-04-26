using EmployeeSearchSample.Data.DBContext;
using EmployeeSearchSample.Entity.Interfaces;
using EmployeeSearchSample.Entity.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSearchSampleApi.Controllers
{
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private EmployeeSearchSampleApiDBContext apiContext;
        public EmployeeController(EmployeeSearchSampleApiDBContext apiContext)
        {
            this.apiContext = apiContext;
        }
        
        // GET api/values  
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            IEnumerable<EmployeeModel> result = await apiContext.GetEmployees();
            return Ok(result);
        }
       
        [HttpPost]
        [Route("Search")]
        public async Task<JsonResult> GetAllEmployees([FromBody] SearchEmployeeModel model)
        {
            IEnumerable<EmployeeModel> result = await apiContext.SearchEmployees(model);
            return Json(result);
        }

    }
}
