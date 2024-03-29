using ASPnetMVCCRUD.Data;

using ASPnetMVCCRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPnetMVCCRUD.Controllers
{


    [Route("api/Api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly MVCDemoDBContext mVCDemoDBContext;

        public ApiController(MVCDemoDBContext mVCDemoDBContext)
        {
            this.mVCDemoDBContext = mVCDemoDBContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAsync()
        {
            var departments = await mVCDemoDBContext.Departments.ToListAsync();

            return Ok(departments);
        }
    }
}