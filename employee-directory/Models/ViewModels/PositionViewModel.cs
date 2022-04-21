using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace employee_directory.Models.ViewModels
{
    public class PositionViewModel
    {
        [Key]
        public int PositionID { get; set; }

        [Required]
        [Display(Name = "Position")]
        public string PositionName { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}