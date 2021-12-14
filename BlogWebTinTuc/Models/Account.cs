using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogWebTinTuc.Models
{
    public class Account
    {

        [Display(Name = "Tên tài khoản")]
        [Key]
        [Required(ErrorMessage = "Tên người dùng không được để trống")]
        public string Username { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Phân quyền")]
        [StringLength(10)]
        public string RoleID { get; set; }
        public Role Role { get; set; }
    }
}