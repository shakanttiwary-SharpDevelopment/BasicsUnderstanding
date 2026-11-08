using DataAccessLayer;
using DataAccessLayer.DTOs;

namespace LinqJoins.Services
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeDto>> GetEmployees();

        public Task<List<EmployeeDto>> GetEmployeesByDepartment(int departmentId);

    }
}
