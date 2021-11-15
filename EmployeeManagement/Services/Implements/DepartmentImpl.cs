using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using EmployeeManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Implements
{
    public class DepartmentImpl : IDepartment
    {
        private readonly ApplicationContext context;

        public DepartmentImpl(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateDepartment(Department department)
        {
            context.Add(department);
            var added = await context.SaveChangesAsync();
            return added > 0;
        }

        public async Task<Department> GetDepartment(int id)
        {
            return await context.GetDepartments.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await context.GetDepartments.ToListAsync();
        }

        public async Task<bool> UpdateDepartment(Department department)
        {
            context.Update(department);
            var updated = await context.SaveChangesAsync();
            return updated > 0;
        }
    }
}
