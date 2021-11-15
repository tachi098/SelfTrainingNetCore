using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Seeders
{
    public class DepartmentSeeder
    {
        public DepartmentSeeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "IT"},
                new Department { Id = 2, Name = "Developer"}
            );
        }
    }
}
