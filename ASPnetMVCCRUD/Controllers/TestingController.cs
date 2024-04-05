using ASPnetMVCCRUD.Data;
using Microsoft.AspNetCore.Mvc;

namespace ASPnetMVCCRUD.Controllers
{
    public class TestingController : Controller
    {
        private readonly MVCDemoDBContext dbContext;

        public TestingController(MVCDemoDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index(){
            return View();
        }
    }
}