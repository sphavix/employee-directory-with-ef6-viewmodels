using employee_directory.BusineesLogic;
using employee_directory.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace employee_directory.Controllers
{
    public class PositionsController : Controller
    {
        private PositionBusinessLogic positionBusiness = new PositionBusinessLogic();
        public ActionResult Index()
        {
            var positions = positionBusiness.GetPositions();
            return View(positions.AsQueryable());
        }

        // GET: Positions/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var position = positionBusiness.GetPosition(Convert.ToInt16(id));
            return View(position);
        }

        // GET: Positions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Positions/Create
        [HttpPost]
        public ActionResult Create(PositionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    positionBusiness.AddPosition(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Positions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var position = positionBusiness.GetPosition(Convert.ToInt16(id));
            return View(position);
        }

        // POST: Positions/Edit/5
        [HttpPost]
        public ActionResult Edit(PositionViewModel model)
        {
            try
            {
                positionBusiness.EditPosition(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Positions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var position = positionBusiness.GetPosition(Convert.ToInt16(id));
            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                int Id = positionBusiness.GetPositionID(id);
                positionBusiness.DeletePosition(Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
