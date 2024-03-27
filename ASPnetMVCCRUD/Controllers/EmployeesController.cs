using ASPnetMVCCRUD.Data;
using ASPnetMVCCRUD.Models;
using ASPnetMVCCRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPnetMVCCRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDemoDBContext mVCDemoDBContext;

        public EmployeesController(MVCDemoDBContext mVCDemoDBContext)
        {

            this.mVCDemoDBContext = mVCDemoDBContext;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await mVCDemoDBContext.Employees.ToListAsync();
            return View(employees);
        }

        public async Task<IActionResult> Add()
        {
            //var employees = await mVCDemoDBContext.Employees.ToListAsync();
            return View();
        }

        public async Task<IActionResult> Add1()
        {
            //var employees = await mVCDemoDBContext.Employees.ToListAsync();
            return  View();
        }
        [HttpPost]
        public async  Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                //Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                salary = addEmployeeRequest.salary,
                Department = addEmployeeRequest.Department,
                DateofBirth = addEmployeeRequest.DateofBirth,
                Gender = addEmployeeRequest.gender,
            };

            await mVCDemoDBContext.Employees.AddAsync(employee);
             await mVCDemoDBContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> department()
        {
            var employees = await mVCDemoDBContext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpPost]
        public async Task<IActionResult> department(string str)
        {
            var employees = await mVCDemoDBContext.Employees.ToListAsync();
            return View(employees);
        }


    }
}
