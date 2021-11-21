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
        [Required(ErrorMessage = "Username is Required.")]
        public string Username { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "ID Phân quyền")]
        [StringLength(10)]
        public string RoleID { get; set; }
    }
}