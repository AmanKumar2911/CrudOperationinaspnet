using ASPnetMVCCRUD.Models.Domain;

namespace ASPnetMVCCRUD.Models
{
    public class AddView{
        public Employee Emp {get ; set;}
        public List<Department>? Departments {get; set;}
    }
}