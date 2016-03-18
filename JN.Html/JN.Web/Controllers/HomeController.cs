using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace JN.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(List<HttpPostedFileBase> excel)
        {
 
            excel.FirstOrDefault().SaveAs(Path.Combine(Server.MapPath("/Upload"), excel.First().FileName));
            return Json(excel.FirstOrDefault().FileName);
        }

        public ActionResult UploadifyDemo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Uploadify(HttpPostedFileBase file)
        {
            file.SaveAs(Path.Combine(Server.MapPath("/Upload"), file.FileName));
            return Json(file.FileName);
        }

        [HttpPost]
        public ActionResult Delete(string fileName)
        {
            System.IO.File.Delete(Path.Combine(Server.MapPath("/Upload"), fileName));
            return Json("Success");
        }
    }
}