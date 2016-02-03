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
           // var file = Request.Files["files"] ;

           // excel.SaveAs(Path.Combine("D:", excel.FileName));

          

            return Json(new {
                    
            })
        }
    }
}