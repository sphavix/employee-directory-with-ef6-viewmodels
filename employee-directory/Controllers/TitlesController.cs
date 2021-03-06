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
    public class TitlesController : Controller
    {
        private TitleBusinessLogic titleBusiness = new TitleBusinessLogic();
        public ActionResult Index()
        {
            var titles = titleBusiness.GetTitles();
            return View(titles.AsQueryable());
        }

        // GET: Titles/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var title = titleBusiness.GetTitle(Convert.ToInt16(id));
            return View(title);
        }

        // GET: Titles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Titles/Create
        [HttpPost]
        public ActionResult Create(TitleViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                    titleBusiness.AddTitle(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Titles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var title = titleBusiness.GetTitle(Convert.ToInt16(id));
            return View(title);
        }

        // POST: Titles/Edit/5
        [HttpPost]
        public ActionResult Edit(TitleViewModel model)
        {
            try
            {
                titleBusiness.EditTitle(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Titles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var title = titleBusiness.GetTitle(Convert.ToInt16(id));
            return View(title);
        }

        // POST: Titles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var Id = titleBusiness.GetTitleID(Convert.ToInt16(id));
                titleBusiness.DeleteTitle(Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
