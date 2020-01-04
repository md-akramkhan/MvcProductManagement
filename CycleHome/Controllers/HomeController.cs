using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CycleHome.Controllers
{
    public class HomeController : Controller
    {
        public CycleHomeEntities db = new CycleHomeEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PictureAdd()
        {
            Picture picture = new Picture();
            return View(picture);
        }
        [HttpPost]
        public ActionResult PictureAdd(Picture model, HttpPostedFileBase pic)
        {
            var db = new CycleHomeEntities();
            if (pic != null)
            {
                model.PictureTitle = new byte[pic.ContentLength];
                pic.InputStream.Read(model.PictureTitle, 0, pic.ContentLength);
            }
            pic.SaveAs(Server.MapPath("~/Pictures/" + pic.FileName));
            db.Pictures.Add(model);
            db.SaveChanges();
            return View(model);
        }
        public ActionResult ShowPicture()
        {
            var db = new CycleHomeEntities();
            var item = (from d in db.Pictures
                        select d).ToList();
            return View(item);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}