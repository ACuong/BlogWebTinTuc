using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BlogWebTinTuc.Models
{
    public class Encryption
    {
        public string PasswordEncryption(String pass)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(pass.Trim(), "MD5");
        }
    }
}