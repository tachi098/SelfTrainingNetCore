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
    public class EmployeeImpl : IEmployee
    {
        private readonly ApplicationContext context;

        public EmployeeImpl(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateEmployee(Employee employee)
        {
            context.Add(employee);
            int added = await context.SaveChangesAsync();
            return added > 0;
        }

        public async Task<bool> DeleteEmployee(string id)
        {
            Employee employee = await context.GetEmployees.SingleOrDefaultAsync(e => e.Id.Equals(id));
            context.Remove(employee);
            int deleted = await context.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<Employee> GetEmployee(string id)
        {
            return await context.GetEmployees.SingleOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await context.GetEmployees.Include(c => c.GetDepartment).ToListAsync();
        }

        public async Task<bool> IsExist(string id)
        {
            Employee employee = await context.GetEmployees.SingleOrDefaultAsync(e => e.Id.Equals(id));
            return employee != null;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            context.Update(employee);
            int updated = await context.SaveChangesAsync();
            return updated > 0;
        }
    }
}
