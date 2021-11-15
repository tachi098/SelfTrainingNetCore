using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Seeders
{
    public class EmployeeSeeder
    {
        public EmployeeSeeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = "E001", Name = "Jack", Address = "US", DepartmentId = 1 },
                new Employee { Id = "E002", Name = "Kimmy", Address = "VN", DepartmentId = 1 }
            );
        }
    }
}
