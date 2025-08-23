using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PMS.Models
{
    public partial class TblDepartment
    {
        public TblDepartment()
        {
            TblUserDepartments = new HashSet<TblUserDepartment>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "The Name Field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The ShortName Field is required")]
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }

        public virtual ICollection<TblUserDepartment> TblUserDepartments { get; set; }
    }
}
