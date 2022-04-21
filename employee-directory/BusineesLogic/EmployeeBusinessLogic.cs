using employee_directory.Models;
using employee_directory.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace employee_directory.BusineesLogic
{
    public class EmployeeBusinessLogic
    {
        public List<EmployeeViewModel> GetEmployees()
        {
            using(var context = new EmployeeDirectoryDbContext())
            {
                var employees = context.Employees.Select(x => new EmployeeViewModel
                {
                    EmployeeNumber = x.EmployeeNumber,
                    TitleID = x.TitleID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateOfBirth = x.DateOfBirth,
                    IdentityNumber = x.IdentityNumber,
                    EmploymentDate = DateTime.Now,
                    EmailAddress = x.EmailAddress,
                    IsActive = true,
                    IsDeleted = false,
                    PositionID = x.PositionID,
                    DepartmentID = x.DepartmentID
                }).ToList();
                return employees;
            }
        }

        public int getEmployeeID(int id)
        {
            using(var context = new EmployeeDirectoryDbContext())
            {
                var employeeId = context.Employees.FirstOrDefault(x => x.EmployeeNumber == id).EmployeeNumber;
                return employeeId;
            }
        }

        public EmployeeViewModel GetEmployee(int id)
        {
            using(var context = new EmployeeDirectoryDbContext())
            {
                var employee = context.Employees.Select(x => new EmployeeViewModel
                {
                    EmployeeNumber = x.EmployeeNumber,
                    TitleID = x.TitleID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateOfBirth = x.DateOfBirth,
                    IdentityNumber = x.IdentityNumber,
                    EmploymentDate = DateTime.Now,
                    EmailAddress = x.EmailAddress,
                    IsActive = true,
                    IsDeleted = false,
                    PositionID = x.PositionID,
                    DepartmentID = x.DepartmentID
                }).Where(x => x.EmployeeNumber == id).FirstOrDefault();
                return employee;
            }
        }

        public void AddEmployee(EmployeeViewModel model)
        {
            using(var context = new EmployeeDirectoryDbContext())
            {
                var employee = new Employee()
                {
                    EmployeeNumber = model.EmployeeNumber,
                    TitleID = model.TitleID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    IdentityNumber = model.IdentityNumber,
                    EmploymentDate = DateTime.Now,
                    EmailAddress = model.EmailAddress,
                    IsActive = true,
                    IsDeleted = false,
                    PositionID = model.PositionID,
                    DepartmentID = model.DepartmentID
                };
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public void EditEmployee(EmployeeViewModel model)
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                var findEmployee = context.Employees.FirstOrDefault(x => x.EmployeeNumber == model.EmployeeNumber);
                if(findEmployee != null)
                {
                    findEmployee.EmployeeNumber = model.EmployeeNumber;
                    findEmployee.TitleID = model.TitleID;
                    findEmployee.FirstName = model.FirstName;
                    findEmployee.LastName = model.LastName;
                    findEmployee.DateOfBirth = model.DateOfBirth;
                    findEmployee.IdentityNumber = model.IdentityNumber;
                    findEmployee.EmploymentDate = DateTime.Now;
                    findEmployee.EmailAddress = model.EmailAddress;
                    findEmployee.IsActive = true;
                    findEmployee.IsDeleted = false;
                    findEmployee.PositionID = model.PositionID;
                    findEmployee.DepartmentID = model.DepartmentID;
                };
                context.SaveChanges();
            }
        }

        public void DeletedEmployee(int id)
        {
            using(var context = new EmployeeDirectoryDbContext())
            {
                var deleted = context.Employees.FirstOrDefault(x => x.EmployeeNumber == id);
                if(deleted != null)
                {
                    context.Employees.Remove(deleted);
                    context.SaveChanges();
                }
            }
        }
    }
}