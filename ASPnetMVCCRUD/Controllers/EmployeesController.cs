using ASPnetMVCCRUD.Data;
using ASPnetMVCCRUD.Models;
using ASPnetMVCCRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            Employee e = new();
            List<Department> dep = await mVCDemoDBContext.Departments.ToListAsync();
            AddView obj = new AddView
            {
                Emp = e,
                Departments = dep

            };


            return View(obj);
        }

        // public async Task<IActionResult> Add1()
        // {
        //     //var employees = await mVCDemoDBContext.Employees.ToListAsync();
        //     return View();
        // }
        [HttpPost]
        public async Task<IActionResult> Add(AddView addEmployeeRequest)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    //Id = Guid.NewGuid(),
                    Name = addEmployeeRequest.Emp.Name,
                    Email = addEmployeeRequest.Emp.Email,
                    salary = addEmployeeRequest.Emp.salary,
                    Department = addEmployeeRequest.Emp.Department,
                    DateofBirth = addEmployeeRequest.Emp.DateofBirth,
                    Gender = addEmployeeRequest.Emp.Gender,
                };

                await mVCDemoDBContext.Employees.AddAsync(employee);
                await mVCDemoDBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            Employee e = new();
            List<Department> dep = await mVCDemoDBContext.Departments.ToListAsync();
            AddView obj = new AddView
            {
                Emp = e,
                Departments = dep

            };

            return View(obj);

        }

        // [HttpGet]
        // public async Task<IActionResult> department()
        // {
        //     var employees = await mVCDemoDBContext.Employees.ToListAsync();
        //     return View(employees);
        // }

        // [HttpPost]
        // public async Task<IActionResult> department(string str)
        // {
        //     var employees = await mVCDemoDBContext.Employees.ToListAsync();
        //     return View(employees);
        // }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            
            Employee? employeeFromDb = mVCDemoDBContext.Employees.Find(id);
            List<Department> dep = [.. mVCDemoDBContext.Departments];
            AddView addView = new()
            {
                Emp = employeeFromDb,
                Departments = dep
            };
            if (employeeFromDb == null)
            {
                return NotFound();
            }

            return View(addView);
        }

        [HttpPost]
        public IActionResult Edit(AddView obj)
        {
            mVCDemoDBContext.Employees.Update(obj.Emp);
            mVCDemoDBContext.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Employee? employeeFromDb = mVCDemoDBContext.Employees.Find(id);
            if (employeeFromDb == null)
            {
                return NotFound();
            }
            mVCDemoDBContext.Employees.Remove(employeeFromDb);
            mVCDemoDBContext.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
