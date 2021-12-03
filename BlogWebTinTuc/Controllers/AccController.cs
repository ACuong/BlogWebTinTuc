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
    [Authorize(Roles = "1")]
    public class AccController : Controller
    {
        private WebTinTucDbContext db = new WebTinTucDbContext();
        Encryption Encry = new Encryption();
        // GET: Acc
        public ActionResult Index(string searchString, string RoleID = "")
        {       
            //var Accounts = from c in db.Accounts select c;
            var Role = from c in db.Roles select c;
            ViewBag.RoleID = new SelectList(Role, "RoleID", "RoleName"); 

            var links = db.Accounts.Include(l => l.Role);
           
            if (!String.IsNullOrEmpty(searchString))
            {
                links = links.Where(s => s.Username.Contains(searchString));
            }

            if (RoleID != "")
            {
                links = links.Where(x => x.RoleID == RoleID);
            }

            return View(links.ToList());
        }

        // GET: Acc/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Acc/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");
            return View();
        }

        // POST: Acc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Password,RoleID")] Account account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    account.Password = Encry.PasswordEncryption(account.Password);
                    db.Accounts.Add(account);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Các trường không được để trống");
            }
            

            return View(account); 
        }

        // GET: Acc/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", account.RoleID);
            return View(account);
        }

        // POST: Acc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,Password,RoleID")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", account.RoleID);
            return View(account);
        }

        // GET: Acc/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Acc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
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
