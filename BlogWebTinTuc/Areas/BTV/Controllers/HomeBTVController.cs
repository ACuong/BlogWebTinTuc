﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWebTinTuc.Areas.BTV.Controllers
{
    [Authorize (Roles = "2")]
    public class HomeBTVController : Controller
    {
        // GET: BTV/HomeBTV
        public ActionResult Index()
        {
            return View();
        }
    }
}