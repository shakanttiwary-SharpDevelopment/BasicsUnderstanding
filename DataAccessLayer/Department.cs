using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public int CompanyId { get; set; }

        // Navigation Property
        public ICollection<Employee> Employees { get; set; }
    }
}
