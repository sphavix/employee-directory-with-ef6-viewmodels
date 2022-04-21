using employee_directory.Models;
using employee_directory.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace employee_directory.BusineesLogic
{
    public class PositionBusinessLogic
    {
        public List<PositionViewModel> GetPositions()
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                var positions = context.Positions.Select(x => new PositionViewModel
                {
                    PositionID = x.PositionID,
                    PositionName = x.PositionName,
                    IsActive = true,
                    IsDeleted = false
                }).ToList();
                return positions;
            }
        }

        public int GetPositionID(int id)
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                var getposition = context.Positions.FirstOrDefault(x => x.PositionID == id).PositionID;
                return getposition;
            }
        }

        public PositionViewModel GetPosition(int id)
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                var position = context.Positions.Select(x => new PositionViewModel
                {
                    PositionID = x.PositionID,
                    PositionName = x.PositionName,
                    IsActive = true,
                    IsDeleted = false
                }).Where(x => x.PositionID == id).FirstOrDefault();
                return position;
            }
        }

        public void AddPosition(PositionViewModel model)
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                var position = new Position()
                {
                    PositionID = model.PositionID,
                    PositionName = model.PositionName,
                    IsActive = true,
                    IsDeleted = false
                };
                context.Positions.Add(position);
                context.SaveChanges();
            }
        }

        public void EditPosition(PositionViewModel model)
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                var findPos = context.Positions.FirstOrDefault(x => x.PositionID == model.PositionID);
                if (findPos != null)
                {
                    findPos.PositionID = model.PositionID;
                    findPos.PositionName = model.PositionName;
                    findPos.IsActive = true;
                    findPos.IsDeleted = false;
                }
                context.SaveChanges();
            }
        }

        public void DeletePosition(int id)
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                var delete = context.Positions.FirstOrDefault(x => x.PositionID == id);
                if (delete != null)
                {
                    context.Positions.Remove(delete);
                    context.SaveChanges();
                }
            }
        }
    }
}