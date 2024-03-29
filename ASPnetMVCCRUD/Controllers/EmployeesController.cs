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
            var e = new AddEmployeeViewModel();
            var departments = await mVCDemoDBContext.Departments.ToListAsync();
            var viewModel = new AddViewModel
            {
                emp = e,
                Departments = departments
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                //Id = Guid.NewGuid(),
                Name = addEmployeeRequest.emp.Name,
                Email = addEmployeeRequest.emp.Email,
                salary = addEmployeeRequest.emp.salary,
                Department = addEmployeeRequest.emp.Department,
                DateofBirth = addEmployeeRequest.emp.DateofBirth,
                Gender = addEmployeeRequest.emp.gender,
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
