namespace ASPnetMVCCRUD.Models.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long salary { get; set; }
        public string Department { get; set; }
        public DateTime DateofBirth { get; set; }
        public char Gender { get; set; }

    }

    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }   
    }
    
}
