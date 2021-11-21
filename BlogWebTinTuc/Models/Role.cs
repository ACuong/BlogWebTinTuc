using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogWebTinTuc.Models
{
    public class Role
    {
        [Key]
        [StringLength(10)]
        [Display(Name = "ID chức vụ")]
        public string RoleID { get; set; }

        [Display(Name = "Tên chức vụ")]
        [StringLength(10)]
        public string RoleName { get; set; }
    }
}