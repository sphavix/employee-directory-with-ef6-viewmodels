using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace employee_directory.Models.ViewModels
{
    public class TitleViewModel
    {
        [Key]
        public int TitleID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string TitleName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Employee Employee { get; set; }
    }
}