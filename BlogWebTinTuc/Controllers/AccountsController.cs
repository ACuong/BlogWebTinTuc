//using BlogWebTinTuc.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Security;

//namespace BlogWebTinTuc.Controllers
//{
//    public class AccountsController : Controller
//    {
//        // GET: Accounts
//        public ActionResult Index()
//        {

//            Encryption Encry = new Encryption();
//            WebTinTucDbContext db = new WebTinTucDbContext();

//            // GET: Account
//            [HttpGet]
//            public ActionResult Register()
//            {
//                return View();
//            }
//            [HttpPost]
//            [ValidateAntiForgeryToken]
//            [AllowAnonymous]
//            public ActionResult Register(Account acc)
//            {
//                if (ModelState.IsValid)
//                {
//                    // mã hóa mật khẩu
//                    acc.Password = Encry.PasswordEncryption(acc.Password);
//                    db.Accounts.Add(acc);
//                    db.SaveChanges();
//                    return RedirectToAction("Login", "Account");
//                }
//                return View(acc);
//            }
//            public ActionResult Login(string returnUrl)
//            {
//                if (CheckSession() != 0)
//                {
//                    return RedirectToLocal(returnUrl);
//                }

//                ViewBag.ReturnUrl = returnUrl;
//                return View();
//            }
//            [HttpPost]
//            [ValidateAntiForgeryToken]
//            [AllowAnonymous]
//            public ActionResult Login(Account acc, string returnUrl)
//            {
//                try
//                {
//                    if (!string.IsNullOrEmpty(acc.Username) && !string.IsNullOrEmpty(acc.Password))
//                    {
//                        using (var db = new WebTinTucDbContext())
//                        {
//                            var passToMD5 = Encry.PasswordEncryption(acc.Password);
//                            var account = db.Accounts.Where(m => m.Username.Equals(acc.Username) && m.Password.Equals(passToMD5)).Count();
//                            if (account == 1)
//                            {
//                                FormsAuthentication.SetAuthCookie(acc.Username, false);
//                                Session["idUser"] = acc.Username;
//                                Session["roleUser"] = acc.RoleID;
//                                return RedirectToLocal(returnUrl);
//                            }
//                            ModelState.AddModelError("", "Thông tin đăng nhập chưa chính xác");
//                        }
//                    }
//                    ModelState.AddModelError("", "username and password is required.");
//                }
//                catch
//                {
//                    ModelState.AddModelError("", "Hệ thống đang được bảo trì, vui lòng liên hệ với quản trị viên");
//                }
//                return View(acc);
//            }
//            public ActionResult Logout()
//            {
//                FormsAuthentication.SignOut();
//                return RedirectToAction("Index", "Home");
//            }
//            //kiểm tra người dùng đăng nhập quyền gì
//            //private int CheckSession()
//            //{
//            //    using (var db = new WebTinTucDbContext())
//            //    {
//            //        var user = HttpContext.Session["idUser"];
//            //        if (user != null)
//            //        {
//            //            var role = db.Accounts.Find(user.ToString()).RoleID;
//            //            if (role.ToString() == "Admin")
//            //            {
//            //                return 1;
//            //            }

//            //            else if (role.ToString() == "BTV")
//            //            {
//            //                return 2;
//            //            }
//            //        }
//            //    }
//            //    return 0;
//            //}

//            //private ActionResult RedirectToLocal(string returnUrl)
//            //{
//            //    if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
//            //    {

//            //        if (CheckSession() == 1)
//            //        {
//            //            return RedirectToAction("Index", "Home_Ad", new { Area = "Admins" });
//            //        }
//            //        else if (CheckSession() == 2)
//            //        {
//            //            return RedirectToAction("Index", "HomeNV", new { Area = "NhanVien" });
//            //        }
//            //        if (Url.IsLocalUrl(returnUrl))
//            //        {
//            //            return Redirect(returnUrl);
//            //        }
//            //        else
//            //        {
//            //            return RedirectToAction("Index", "Home");
//            //        }
//            //    }
//            //    return RedirectToAction("Index", "Home");
//            //}
           
//        }
//    }
//}