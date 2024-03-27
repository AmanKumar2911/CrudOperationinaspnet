using System.Reflection;

namespace ASPnetMVCCRUD.Models
{
    public class AddEmployeeViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long salary { get; set; }
        public string Department { get; set; }
        public DateTime DateofBirth { get; set; }
        public Char gender { get; set; }

    }

    public class AddDepartmentViewModel
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}
