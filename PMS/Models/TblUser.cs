
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PMS.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblAdvanceSalaries = new HashSet<TblAdvanceSalary>();
            TblElectricalSafeties = new HashSet<TblElectricalSafety>();
            TblNightShifts = new HashSet<TblNightShift>();
            TblOvertimes = new HashSet<TblOvertime>();
            TblPhoneInfos = new HashSet<TblPhoneInfo>();
            TblTimeKeepings = new HashSet<TblTimeKeeping>();
            TblUserDepartments = new HashSet<TblUserDepartment>();
            TblUserPositions = new HashSet<TblUserPosition>();
            TblUserRoles = new HashSet<TblUserRole>();
            TblWorkPerformances = new HashSet<TblWorkPerformance>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Tên người dùng là bắt buộc")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mã người dùng là bắt buộc")]
        [StringLength(50)]
        public string UserCode { get; set; }

        public DateTime? Dob { get; set; }

        [StringLength(20)]
        public string BankNo { get; set; }

        public decimal? SalaryConfficient { get; set; }

        [Required(ErrorMessage = "Ngày tuyển dụng là bắt buộc")]
        public DateTime EmploymentDate { get; set; }

        public DateTime? DateIssued { get; set; }

        [StringLength(100)]
        public string AccountName { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [StringLength(100)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [StringLength(100)]
        public string EmailAddress { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? OrderNumber { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedUser { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ModifiedUser { get; set; }

        public virtual ICollection<TblAdvanceSalary> TblAdvanceSalaries { get; set; }
        public virtual ICollection<TblElectricalSafety> TblElectricalSafeties { get; set; }
        public virtual ICollection<TblNightShift> TblNightShifts { get; set; }
        public virtual ICollection<TblOvertime> TblOvertimes { get; set; }
        public virtual ICollection<TblPhoneInfo> TblPhoneInfos { get; set; }
        public virtual ICollection<TblTimeKeeping> TblTimeKeepings { get; set; }
        public virtual ICollection<TblUserDepartment> TblUserDepartments { get; set; }
        public virtual ICollection<TblUserPosition> TblUserPositions { get; set; }
        public virtual ICollection<TblUserRole> TblUserRoles { get; set; }
        public virtual ICollection<TblWorkPerformance> TblWorkPerformances { get; set; }
    }
}

