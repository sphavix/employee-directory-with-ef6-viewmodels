using employee_directory.BusineesLogic;
using employee_directory.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace employee_directory.Controllers
{
    
    public class EmployeesController : Controller
    {
        private EmployeeBusinessLogic employeesBusiness = new EmployeeBusinessLogic();
        private PositionBusinessLogic positionBusiness = new PositionBusinessLogic();
        private DepartmentBusinessLogic departmentBusiness = new DepartmentBusinessLogic();
        private TitleBusinessLogic titleBusiness = new TitleBusinessLogic();

        public ActionResult Index()
        {
            var employees = employeesBusiness.GetEmployees();
            return View(employees.AsQueryable());
        }

        
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var employee = employeesBusiness.GetEmployee(Convert.ToInt16(id));
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.TitleId = new SelectList(titleBusiness.GetTitles(), "TitleID", "TitleName");
            ViewBag.PositionId = new SelectList(positionBusiness.GetPositions(), "PositionID", "PositionName");
            ViewBag.DepartmentId = new SelectList(departmentBusiness.GetDepartments(), "DepartmentID", "DepartmentName");
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(EmployeeViewModel model)
        {
            try
            {
                employeesBusiness.AddEmployee(model);
                ViewBag.TitleId = new SelectList(titleBusiness.GetTitles(), "TitleID", "TitleName");
                ViewBag.PositionId = new SelectList(positionBusiness.GetPositions(), "PositionID", "PositionName");
                ViewBag.DepartmentId = new SelectList(departmentBusiness.GetDepartments(), "DepartmentID", "DepartmentName");
             
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.TitleId = new SelectList(titleBusiness.GetTitles(), "TitleID", "TitleName");
                ViewBag.PositionId = new SelectList(positionBusiness.GetPositions(), "PositionID", "PositionName");
                ViewBag.DepartmentId = new SelectList(departmentBusiness.GetDepartments(), "DepartmentID", "DepartmentName");
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
