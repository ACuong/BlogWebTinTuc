using BlogWebTinTuc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWebTinTuc.Controllers
{
    public class HomeController : Controller
    {
        private WebTinTucDbContext db = new WebTinTucDbContext();
        public ActionResult Index()
        {
            var model = from c in db.Posts select c;
            return View(model.OrderByDescending(c => c.PostID));

        }

        public ActionResult DetailNews(string id)
        {
            var detailPost = db.Posts.Find(id);
            return View(detailPost);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}