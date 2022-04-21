using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace employee_directory.Models.ViewModels
{
    public class EmployeeViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeNumber { get; set; }

        [Required]
        [Display(Name = "Title")]
        public int TitleID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }


        public DateTime EmploymentDate { get; set; }
        [Required]
        [Display(Name = "RSA ID")]
        public string IdentityNumber { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Required]
        [Display(Name = "Position")]
        public int PositionID { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        public virtual Title Title { get; set; }
        public virtual Position Position { get; set; }
        public virtual Department Department { get; set; }
    }
}