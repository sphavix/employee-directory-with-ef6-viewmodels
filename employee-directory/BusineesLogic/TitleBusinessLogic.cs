using employee_directory.Models;
using employee_directory.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace employee_directory.BusineesLogic
{
    public class TitleBusinessLogic
    {
        public List<TitleViewModel> GetTitles()
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                var titles = context.Titles.Select(x => new TitleViewModel
                {
                    TitleID = x.TitleID,
                    TitleName = x.TitleName,
                    IsActive = true,
                    IsDeleted = false
                }).ToList();
                return titles;
            }
        }

        public int GetTitleID(int id)
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                var gettitles = context.Titles.FirstOrDefault(x => x.TitleID == id).TitleID;
                return gettitles;
            }
        }

        public TitleViewModel GetTitle(int id)
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                var title = context.Titles.Select(x => new TitleViewModel
                {
                    TitleID = x.TitleID,
                    TitleName = x.TitleName,
                    IsActive = true,
                    IsDeleted = false
                }).Where(x => x.TitleID == id).FirstOrDefault();
                return title;
            }
        }

        public void AddTitle(TitleViewModel model)
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                var title = new Title()
                {
                    TitleID = model.TitleID,
                    TitleName = model.TitleName,
                    IsActive = true,
                    IsDeleted = false
                };
                context.Titles.Add(title);
                context.SaveChanges();
            }
        }

        public void EditTitle(TitleViewModel model)
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                var findTitle = context.Titles.FirstOrDefault(x => x.TitleID == model.TitleID);
                if (findTitle != null)
                {
                    findTitle.TitleID = model.TitleID;
                    findTitle.TitleName = model.TitleName;
                    findTitle.IsActive = true;
                    findTitle.IsDeleted = false;
                }
                context.SaveChanges();
            }
        }

        public void DeleteTitle(int id)
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                var delete = context.Titles.FirstOrDefault(x => x.TitleID == id);
                if (delete != null)
                {
                    context.Titles.Remove(delete);
                    context.SaveChanges();
                }
            }
        }
    }
}