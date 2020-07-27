using RealSurfClub.DAL;
using RealSurfClub.Helpers;
using RealSurfClub.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RealSurfClub.Controllers
{
    public class RegisterController : Controller
    {
        SurfDbContext dbContext = new SurfDbContext();

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(User model, HttpPostedFileBase imageData)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != model.PasswordConfirm)
                {
                    ModelState.AddModelError(string.Empty, "Введенные пароли не совпадают!");
                    return View("Index", model);
                }

                var userIndb = dbContext.Users.FirstOrDefault(c => c.Nickname == model.Nickname);

                if (userIndb != null)
                {
                    ModelState.AddModelError(string.Empty, "Пользователь с таким именем уже существует");
                    return View("Index", model);
                }

                var emailIndb = dbContext.Users.FirstOrDefault(c => c.Email == model.Email);

                if (emailIndb != null)
                {
                    ModelState.AddModelError(string.Empty, "Такая почта уже зарегистрирована");
                    return View("Index", model);
                }


                if (imageData != null)
                {
                    if (!ImageFormatHelper.IsJpg(imageData))
                    {
                        ModelState.AddModelError(string.Empty, "Загруженное изображение не картинка формата JPG");
                        return View("Index", model);
                    }

                    model.Photo = ImageSaveHelper.SaveImage(imageData);
                }

                dbContext.Users.Add(model);
                dbContext.SaveChanges();

                FormsAuthentication.SetAuthCookie(model.Nickname, false); // авторизация через куки
                Session["UserId"] = model.Id.ToString();
                Session["Nickname"] = model.Nickname;
                Session["Photo"] = ImageUrlHelper.GetUrl(model.Photo);

                return RedirectToAction("Index", "Feed");
            }
            return View("Index", model);
        }

    }
}