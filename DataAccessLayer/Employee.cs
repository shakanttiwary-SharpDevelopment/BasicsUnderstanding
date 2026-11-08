namespace DataAccessLayer
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public int DepartmentId { get; set; }

        public int CompanyId { get; set; }

        // Navigation Property
        public Department Department { get; set; }
    }
}
