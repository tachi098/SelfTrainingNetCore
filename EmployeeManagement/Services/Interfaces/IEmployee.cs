using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string id);
        Task<bool> CreateEmployee(Employee employee);
        Task<bool> DeleteEmployee(string id);
        Task<bool> UpdateEmployee(Employee employee);
        Task<bool> IsExist(string id);
    }
}
