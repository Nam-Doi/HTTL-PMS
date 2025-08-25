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
        [Required(ErrorMessage = "Tên trường Name là bắt buộc")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Tên trường Shortname là bắt buộc")]
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        [Required(ErrorMessage ="Trường này là bắt buộc")]
        public int Status { get; set; }

        public virtual ICollection<TblUserDepartment> TblUserDepartments { get; set; }
    }
}
