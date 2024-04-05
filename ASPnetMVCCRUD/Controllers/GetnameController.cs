
using ASPnetMVCCRUD.Data;
using ASPnetMVCCRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ASPnetMVCCRUD.Controllers
{
    [Route("api/Getname")]
    [ApiController]
    public class GetnameController : ControllerBase
    {
        private readonly MVCDemoDBContext dBContext;

        public GetnameController(MVCDemoDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet("GetEmployeeNames")]
        public async Task<ActionResult<IEnumerable<string>>> GetEmployeeNames()
        {
            var names = await dBContext.Employees.Select(e => e.Name).ToListAsync();
            return Ok(names);
        }

        [HttpGet("GetEmployeeDetails")]
        public ActionResult<Employee> GetEmployeeDetails(string name)
        {
            var employee = dBContext.Employees.FirstOrDefault(e => e.Name == name);
            if (employee != null)
            {
                return Ok(employee);
            }
            else
            {
                return Ok(null);
            }
        }

    }
}