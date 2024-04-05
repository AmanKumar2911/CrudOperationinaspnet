using ASPnetMVCCRUD.Data;
using ASPnetMVCCRUD.Models;
using ASPnetMVCCRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPnetMVCCRUD.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly MVCDemoDBContext mVCDemoContext;

        public DepartmentController(MVCDemoDBContext mVCDemoContext)
        {
            this.mVCDemoContext = mVCDemoContext;
        }
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var department = await mVCDemoContext.Departments.ToListAsync();
            return View(department);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Add(AddDepartmentViewModel addDepartmentRequest)
        {
            var department = new Department()
            {
                DepartmentId = addDepartmentRequest.DepartmentID,
                DepartmentName = addDepartmentRequest.DepartmentName,
            };

            await mVCDemoContext.Departments.AddAsync(department);
            await mVCDemoContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id){
            if(id==null || id == 0){
                return NotFound();
            }
            Department? departmentFromDb = mVCDemoContext.Departments.Find(id);
            if(departmentFromDb == null)
            {
                return NotFound();
            }
            mVCDemoContext.Departments.Remove(departmentFromDb);
            mVCDemoContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
