using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MyCollage.Models;

namespace MyCollage.ViewModel
{
    public class DepartmentVM : Department
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "Department Name")]
        public string Name { get; set; }
    }

}