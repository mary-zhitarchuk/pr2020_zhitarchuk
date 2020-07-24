using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealSurfClub.DAL;
using RealSurfClub.Helpers;
using RealSurfClub.Models.DBModels;


namespace RealSurfClub.Controllers
{
    public class FeedController : Controller
    {
        private SurfDbContext dbContext = new SurfDbContext(); 

        // GET: Feed
        public ActionResult Index()
        {
            var posts = dbContext.Posts.OrderByDescending(c => c.Id).ToList();
            ViewBag.Posts = posts;
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(Post model, HttpPostedFileBase imageData)
        {

            if(!ModelState.IsValid)
            {
                var postsN = dbContext.Posts.OrderByDescending(c => c.Id).ToList();
                ViewBag.Posts = postsN;

                return View("Index", model);
            }

            if(imageData == null && model.Text == null)
            {
                ModelState.AddModelError(string.Empty, "Не загружено ни изображение, ни текст");
                var postsN = dbContext.Posts.OrderByDescending(c=>c.Id).ToList();
                ViewBag.Posts = postsN;
                return View("Index", model);
            }

            model.PubishDate = DateTime.Now;

            if (imageData != null)
            {
                model.Photo = ImageSaveHelper.SaveImage(imageData);
            }

           

            var userId = Convert.ToInt32(Session["UserId"]);
            var userInDb = dbContext.Users.FirstOrDefault(c => c.Id == userId);

            if (userInDb == null)
            {
                //пользователь не авторизован
                TempData["errorMessage"] = "Время сессии истекло. Авторизуйтесь повторно.";
     
                return RedirectToAction("Index", "Home");
            }

            model.Author = userInDb;

            dbContext.Posts.Add(model);

            dbContext.SaveChanges();

            var posts = dbContext.Posts.OrderByDescending(c => c.Id).ToList();
            ViewBag.Posts = posts;

            ModelState.Clear();

            return View("Index");
        }

    }
}