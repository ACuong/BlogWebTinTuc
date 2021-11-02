using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogWebTinTuc.Models
{
    public class Account
    {
        [Required(ErrorMessage = "Username is Required.")]
        [Key]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[StringLength(10)]
        //public string RoleID { get; set; }
    }
}