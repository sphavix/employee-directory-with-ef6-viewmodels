using employee_directory.Models;
using employee_directory.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace employee_directory.BusineesLogic
{
    public class DepartmentBusinessLogic
    {
        public List<DepartmentViewModel> GetDepartments()
        {
            using(var _context = new EmployeeDirectoryDbContext())
            {
                var departments = _context.Departments.Select(x => new DepartmentViewModel
                {
                    DepartmentID = x.DepartmentID,
                    DepartmentName = x.DepartmentName,
                    IsActive = true,
                    IsDeleted = false
                }).ToList();
                return departments;
            }
        }

        public int GetDepartmentID(int id)
        {
            using(var context = new EmployeeDirectoryDbContext())
            {
                var getdepartment = context.Departments.FirstOrDefault(x => x.DepartmentID == id).DepartmentID;
                return getdepartment;
            }
        }

        public DepartmentViewModel GetDepartment(int id)
        {
            using(var context = new EmployeeDirectoryDbContext())
            {
                var department = context.Departments.Select(x => new DepartmentViewModel
                {
                    DepartmentID = x.DepartmentID,
                    DepartmentName = x.DepartmentName,
                    IsActive = true,
                    IsDeleted = false
                }).Where(x => x.DepartmentID == id).FirstOrDefault();
                return department;
            }
        }

        public void AddDepartment(DepartmentViewModel model)
        {
            using(var context = new EmployeeDirectoryDbContext())
            {
                var department = new Department()
                {
                    DepartmentID = model.DepartmentID,
                    DepartmentName = model.DepartmentName,
                    IsActive = true,
                    IsDeleted = false
                };
                context.Departments.Add(department);
                context.SaveChanges();
            }
        }

        public void EditDepartment(DepartmentViewModel model)
        {
            using(var context = new EmployeeDirectoryDbContext())
            {
                var findDep = context.Departments.FirstOrDefault(x => x.DepartmentID == model.DepartmentID);
                if(findDep != null)
                {
                    findDep.DepartmentID = model.DepartmentID;
                    findDep.DepartmentName = model.DepartmentName;
                    findDep.IsActive = true;
                    findDep.IsDeleted = false;
                }
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteDepartment(int id)
        {
            using(var context = new EmployeeDirectoryDbContext())
            {
                var delete = context.Departments.FirstOrDefault(x => x.DepartmentID == id);
                if(delete != null)
                {
                    context.Departments.Remove(delete);
                    context.SaveChanges();
                }
            }
        }
    }
}