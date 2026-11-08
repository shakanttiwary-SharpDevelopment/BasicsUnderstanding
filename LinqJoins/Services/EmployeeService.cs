using DataAccessLayer;
using DataAccessLayer.DAL;
using DataAccessLayer.DTOs;

namespace LinqJoins.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDAL _dataAccess;
        public EmployeeService(ApplicationDAL dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {
            var employees = from emp in _dataAccess.Employees
                            join dept in _dataAccess.Departments
                            on emp.DepartmentId equals dept.DepartmentId
                            select new EmployeeDto
                            {
                                Id = emp.EmployeeId,
                                Name = emp.EmployeeName,
                                Department = dept.DepartmentName
                            };
            return await Task.FromResult(employees.ToList());
        }
        public async Task<List<EmployeeDto>> GetEmployeesByDepartment(int departmentId)
        {
            var employees = from emp in _dataAccess.Employees
                            join dept in _dataAccess.Departments
                            on emp.DepartmentId equals dept.DepartmentId
                            into empDept 
                            from dept in empDept.DefaultIfEmpty()
                            where emp.DepartmentId == departmentId
                            select new EmployeeDto
                            {
                                Id = emp.EmployeeId,
                                Name = emp.EmployeeName,
                                Department = dept.DepartmentName
                            };
            return await Task.FromResult(employees.ToList());
        }


    }
}
