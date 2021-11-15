using EmployeeManagement.Models;
using EmployeeManagement.Seeders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions options): base(options) {}
        
        public DbSet<Department> GetDepartments { get; set; }
        public DbSet<Employee> GetEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Relationship
            //Department-Employee(One-To-Many)
            modelBuilder.Entity<Department>()
                .HasMany(d => d.GetEmployees)
                .WithOne(e => e.GetDepartment);
            #endregion

            /*create Seeder*/
            new ApplicationSeeder().OnModelSeeders(modelBuilder);
        }
    }
}
