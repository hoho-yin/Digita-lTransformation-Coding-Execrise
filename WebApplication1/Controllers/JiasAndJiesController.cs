using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class JiasAndJiesController : Controller
    {
        //Show
        // GET: JiasAndJies
        public ActionResult Index()
        {
            return View();
        }
        //Encode
        public ActionResult Indexget()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Indexpost()
        {
            string JiaMi = Convert.ToString(Request.Form["JiaMi"]);
            if (JiaMi.Trim().Length > 0)
            {
                Session["jiami"] = "Encoded Data: "+ Guid.NewGuid().ToString(); ;
                Session["jiemi"] = JiaMi;
                return Content("<script>alert('Encode data successfully 😊');window.open('" + Url.Action("Indexget", "JiasAndJies") + "', '_self')</script>");
            }
            else
                Session["jiami"] = "Sorry. Unable to encode data";
                return Content("<script>alert('Sorry. Unable to encode data');window.open('" + Url.Action("Indexget", "JiasAndJies") + "', '_self')</script>");
        }


        //Decode
        // GET: JiasAndJies
        public ActionResult IndexJie()
        {
            return View();
        }
    }
}