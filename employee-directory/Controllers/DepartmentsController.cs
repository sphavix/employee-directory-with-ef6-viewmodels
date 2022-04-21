using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using employee_directory.BusineesLogic;
using employee_directory.Models;
using employee_directory.Models.ViewModels;

namespace employee_directory.Controllers
{
    public class DepartmentsController : Controller
    {
        private EmployeeDirectoryDbContext db = new EmployeeDirectoryDbContext();
        private DepartmentBusinessLogic departmentBusiness = new DepartmentBusinessLogic();

        // GET: Departments
        public ActionResult Index()
        {
            var departments = departmentBusiness.GetDepartments();
            return View(departments.AsQueryable());
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var department = departmentBusiness.GetDepartment(Convert.ToInt16(id));
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                departmentBusiness.AddDepartment(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var department = departmentBusiness.GetDepartment(Convert.ToInt16(id));
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentViewModel model)
        {
            try
            {
                departmentBusiness.EditDepartment(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            int Id = Convert.ToInt16(id);
            departmentBusiness.DeleteDepartment(Id);
            ViewBag.Feedback = "Department has been deleted";
            return RedirectToAction("Index");
        }

        //// POST: Departments/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Department department = db.Departments.Find(id);
        //    db.Departments.Remove(department);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
