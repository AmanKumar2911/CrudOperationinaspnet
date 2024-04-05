using ASPnetMVCCRUD.Data;
using ASPnetMVCCRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ASPnetMVCCRUD.Controllers
{
    public class LoginController : Controller {
        private readonly MVCDemoDBContext _mVCDemoDBContext;

        public LoginController(MVCDemoDBContext mVCDemoDBContext)
        {
            _mVCDemoDBContext = mVCDemoDBContext;
        }

        public IActionResult Index()
        {
            return View();
            
        }
        [HttpPost]
        public IActionResult Index(Employee employee)
        {
            Employee? e = _mVCDemoDBContext.Employees.FirstOrDefault(obj => obj.Email == employee.Email);
            if(e!=null){
                return RedirectToAction("Index","Employees");
            }
            return RedirectToAction("Index");
            
        }
    }
}