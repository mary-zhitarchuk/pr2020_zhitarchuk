using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RealSurfClub.DAL;
using RealSurfClub.Helpers;
using RealSurfClub.Models.ViewModels;

namespace RealSurfClub.Controllers
{
    public class HomeController : Controller
    {
        SurfDbContext dbContext = new SurfDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var useInDb = dbContext.Users.FirstOrDefault(
                    c=> c.Nickname == model.Nickname &&
                    c.Password == model.Password
                    );
                if(useInDb!= null) 
                {
                    FormsAuthentication.SetAuthCookie(useInDb.Nickname, model.RememberMe); // авторизация через куки
                    Session["UserId"] = useInDb.Id.ToString();
                    Session["Nickname"] = useInDb.Nickname;
                    Session["Photo"] = ImageUrlHelper.GetUrl(useInDb.Photo);

                    return RedirectToAction("Index", "Feed");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Неверный псевдоним или пароль!");
                }

            }

            return View("Index", model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Request.Cookies.Clear();

            return RedirectToAction("Index", "Feed");


        }

    }
}
