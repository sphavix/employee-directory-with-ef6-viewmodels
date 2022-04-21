using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace employee_directory.Models
{
    public class Title
    {
        [Key]
        public int TitleID { get; set; }
        public string TitleName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual  ICollection<Employee> Employee { get; set; }
    }
}