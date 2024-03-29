

using ASPnetMVCCRUD.Models.Domain;

namespace ASPnetMVCCRUD.Models
{
    public class AddViewModel
    {
        public AddEmployeeViewModel emp {get;set;}
        public List<Department> Departments { get; set; }
        // Add other properties as needed
    }
}
