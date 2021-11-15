using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IDepartment
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int id);
        Task<bool> UpdateDepartment(Department department); 
        Task<bool> CreateDepartment(Department department); 

    }
}
