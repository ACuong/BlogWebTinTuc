using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWebTinTuc.Controllers;
using BlogWebTinTuc.Models;

namespace BlogWebTinTuc.Areas.Admin.Controllers
{
    [Authorize(Roles ="1")]
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }
     
    }
}