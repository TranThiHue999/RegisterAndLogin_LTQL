using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RegisterAndLogin_LTQL.Models;

namespace RegisterAndLogin_LTQL.Controllers
{
    public class AccountController : Controller
    {
        Encrytion encry = new Encrytion();
        LTQLDBEntities db = new LTQLDBEntities();
        // GET: Account
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [Obsolete]
        public ActionResult Register(Account acc)
        {
            if (ModelState.IsValid)
            {
                //mã hóa mật khẩu khi lưu và database
                acc.Password = encry.PasswordEncrytion(acc.Password);
                object p = db.Accounts.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            return View(acc);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(Account acc)
        {
            if (ModelState.IsValid)
            {
                string encrytionpass = encry.PasswordEncrytion(acc.Password);
                int model = db.Accounts.Where(m => m.Username == acc.Username && m.Password == encrytionpass).ToList().Count();
                //thông tin đăng nhập chính xác
                if (model == 1)
                {
                    FormsAuthentication.SetAuthCookie(acc.Username, true);
                    return RedirectToAction("Index", " Home");
                }
                else
                {
                    ModelState.AddModelError("", "THông tin đăng nhập không chính xác ");
                }
            }
            return View(acc);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}