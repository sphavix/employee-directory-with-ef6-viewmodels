using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace employee_directory.Models.ViewModels
{
    public class DepartmentViewModel
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        [Display(Name = "Department")]
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}