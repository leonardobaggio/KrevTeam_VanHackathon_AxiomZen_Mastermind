using MasterMindApi.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterMindApi.Controllers
{
    public class GameController : Controller
    {
        //
        // GET: /Game/
        public ActionResult Singleplayer()
        {
            if (Session["User"] == null)
                return RedirectToAction("Index", "Home");
            Users user = (Users)Session["User"];
            ViewBag.UserId = user.UserId;
            return View();
        }
        public ActionResult Multiplayer(int? id)
        {
            if (Session["User"] == null)
                return RedirectToAction("Index", "Home");
            Users user = (Users)Session["User"];
            
            ViewBag.UserId = user.UserId;
            ViewBag.GameId = (int)id;

            var context = new MastermindEntities();

            var game =  context.Games.Where(x => x.GameId == (int)id).FirstOrDefault();
            
            ViewBag.Player1 = game.Player_Name_1;
            ViewBag.Player2 = game.Player_Name_2;
            
            
            return View();
        }
	}
}