using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class JiasAndJiesController : Controller
    {
        // Show
        // GET: JiasAndJies
        public ActionResult Index()
        {
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["Jia"];
            if (cookie == null)
            { return View(); }
            else
            {
                Session["jiami"] = HttpUtility.UrlDecode(cookie.Values["JiaMi"]).ToString();
                Session["jiemi"] = HttpUtility.UrlDecode(cookie.Values["JieMi"]).ToString();
                return RedirectToAction("IndexJie", "JiasAndJies");
            }
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
                HttpCookie cookie = new HttpCookie("Jia");
                //Set Expire Time
                cookie.Expires = DateTime.Now.AddDays(3);
                //Save to client
                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
                cookie.Values["JieMi"] = HttpUtility.UrlEncode(JiaMi);
                cookie.Values["JiaMi"] = HttpUtility.UrlEncode("Encoded data: " + Guid.NewGuid().ToString());
                Session["jiami"] = HttpUtility.UrlDecode(cookie.Values["JiaMi"]).ToString();
                Session["jiemi"] = HttpUtility.UrlDecode(cookie.Values["JieMi"]).ToString();
                return Content("<script>alert('Encode successfully！');window.open('" + Url.Action("Indexget", "JiasAndJies") + "', '_self')</script>");
            }
            else
                Session["jiami"] = "Sorry. Unable to encode";
                return Content("<script>alert('Sorry. Unable to encode');window.open('" + Url.Action("Indexget", "JiasAndJies") + "', '_self')</script>");
        }


        //Decode
        // GET: JiasAndJies
        public ActionResult IndexJie()
        {
            return View();
        }
    }
}