using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using EmployeeManagement.Services.Implements;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee employeeService;
        private readonly IDepartment departmentService;
        private readonly ApplicationContext context;

        public EmployeeController(IEmployee employeeService, IDepartment departmentService, ApplicationContext context)
        {
            this.employeeService = employeeService;
            this.departmentService = departmentService;
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await employeeService.GetEmployees();
            return View(employees);
        }

        public IActionResult Create()
        {
            Employee employee = new Employee();
            ViewData["Departmnets"] = new SelectList(context.GetDepartments, "Id", "Name");
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (!await employeeService.IsExist(employee.Id))
                {
                    int departmentId = (int)employee.DepartmentId;
                    Employee newEmployee = new Employee { Id = employee.Id, Name = employee.Name, Address = employee.Address, GetDepartment = await departmentService.GetDepartment(departmentId) };
                    await employeeService.CreateEmployee(newEmployee);
                }
                else
                {
                    ViewData["isExist"] = "Id is existed, Try again!";
                    ViewData["Departmnets"] = new SelectList(context.GetDepartments, "Id", "Name");
                    return View(employee);
                }
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await employeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(String id)
        {
            Employee employee = await employeeService.GetEmployee(id);
            ViewData["Departmnets"] = new SelectList(context.GetDepartments, "Id", "Name");
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Employee employee)
        {
            if (ModelState.IsValid)
            {
                int departmentId = (int)employee.DepartmentId;
                employee.GetDepartment = await departmentService.GetDepartment(departmentId);
                await employeeService.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}
