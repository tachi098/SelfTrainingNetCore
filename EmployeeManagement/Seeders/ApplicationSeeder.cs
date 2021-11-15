using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Seeders
{
    public class ApplicationSeeder
    {
        public void OnModelSeeders(ModelBuilder modelBuilder)
        {
            // Department
            new DepartmentSeeder(modelBuilder);

            // Employee 
            new EmployeeSeeder(modelBuilder);
        }
    }
}
