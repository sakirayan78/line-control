using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LineEdit.Models;

namespace LineEdit.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private static string tt = "hello world";
        public ActionResult Index()
        {
            MyModals my = new MyModals() {content =tt};
            return View("Index",my);
        }
       
        [HttpPost]
        [ValidateInput(false)] 
        public ActionResult Index( MyModals myModals)
        {
            var   contentx =myModals.content;
            ViewData["con"] = contentx;
            tt = contentx;
            return View("Index", myModals);
        }
    }

}
