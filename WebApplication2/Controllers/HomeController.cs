using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsSite.Models;

namespace NewsSite.Controllers
{
    public class HomeController : Controller
    {
        NewsContext db = new NewsContext();
        public ActionResult Index()
        {
            
            return View(db.News);
        }
        
        public ActionResult Browse(int Id)
        {
            News BrowseNews = db.News
                .Where(i => i.Id == Id)
                .FirstOrDefault();
            ViewBag.Browsing = BrowseNews;
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public PartialViewResult Add(News newsAdd)
        {
            ViewBag.Message = "news add";
            db.News.Add(newsAdd);
            db.SaveChanges();
            return PartialView("_PartialAlertAdd");

        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            News DelNews = db.News
                .Where(i => i.Id == Id)
                .FirstOrDefault();
            ViewBag.Browsing = DelNews;
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int Id,string str)
        {
            News DelNews = db.News
                .Where(i => i.Id == Id)
                .FirstOrDefault();
            db.News.Remove(DelNews);
            db.SaveChanges();
            return View("Del");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}