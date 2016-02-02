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
        public ActionResult Upload()
        {
            var file = Request.InputStream ;

            var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);

            System.IO.File.WriteAllBytes(@"D:\img", memoryStream.ToArray());

            return View("Index");
        }
    }
}