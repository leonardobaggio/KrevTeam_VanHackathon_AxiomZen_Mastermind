using MasterMindApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterMindApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            
            if (Session["User"] != null)
            {
                ViewBag.UserCreated = true;
                Users user = (Users)Session["User"];
                ViewBag.UserId = user.UserId;
            }
            else {
                ViewBag.UserId = 0;
                ViewBag.UserCreated = false;
            }
            return View();            
        }
        [HttpPost]
        public ActionResult Index(Users user)
        {
            using (var context = new MastermindEntities())
            {
                context.Database.Connection.Open();

                var lstUsers = context.Users.Where(x => x.UserName == user.UserName).ToList();

                if (lstUsers.Count > 0)
                {
                    Session["User"] = lstUsers.FirstOrDefault();
                    return RedirectToAction("Index");
                }

                context.Users.Add(user);
                context.SaveChanges();
                Session["User"] = user;
            }

            return RedirectToAction("Index");
        }

    }
}
