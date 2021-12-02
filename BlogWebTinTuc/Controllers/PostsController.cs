using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogWebTinTuc.Models;

namespace BlogWebTinTuc.Controllers
{
    //[Authorize]
    public class PostsController : Controller
    {
        private WebTinTucDbContext db = new WebTinTucDbContext();
        AutoGenerateKey auKey = new AutoGenerateKey();
        // GET: Posts
        public ActionResult Index(string searchString, string CategoryID = "")
        {
            //1. Tạo danh sách danh mục để hiển thị ở giao diện View thông qua DropDownList
            var Post = from c in db.Posts select c;
            var Category = from c in db.Categorys select c;
            ViewBag.CategoryID = new SelectList(Category, "CategoryID", "CategoryName"); // danh sách Category

            //2. Tạo câu truy vấn kết 2 bảng Link, Category bằng hàm Include do 2 bảng có ràng buộc
            var links = db.Posts.Include(l => l.Category);

            //3. Tìm kiếm chuỗi truy vấn
            if (!String.IsNullOrEmpty(searchString))
            {
                links = links.Where(s => s.Title.Contains(searchString));
            }
            //4. Tìm kiếm theo CategoryID
            if(CategoryID != "")
            {
                links = links.Where(x => x.CategoryID == CategoryID);
            }

            return View(links.ToList());

            //var posts = db.Posts.Include(p => p.Category);
            //return View(posts.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            var emp = db.Posts.ToList().OrderByDescending(c => c.PostID);
            ViewBag.newUrl_image = emp.FirstOrDefault().Url_image;
            

            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {

            string NewID = "";
            var emp = db.Posts.ToList().OrderByDescending(c => c.PostID);
            var countPost = db.Posts.Count();
            if (countPost == 0)
            {
                NewID = "Post001";
            }
            else
            {
                NewID = auKey.GenerateKey(emp.FirstOrDefault().PostID);
            }
            ViewBag.newPostID = NewID;

            ViewBag.Categories = new SelectList(db.Categorys, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,Title,Url_image,Textbody,CategoryID")] Post post)
        {

         if (ModelState.IsValid)
                {
                    db.Posts.Add(post);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
         ViewBag.CategoryID = new SelectList(db.Categorys, "CategoryID", "CategoryName", post.CategoryID);
            
            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categorys, "CategoryID", "CategoryName", post.CategoryID);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,Title,Url_image,Textbody,CategoryID")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categorys, "CategoryID", "CategoryName", post.CategoryID);
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
