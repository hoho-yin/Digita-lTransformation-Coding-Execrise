using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class JiasAndJiesController : Controller
    {
        //显示
        // GET: JiasAndJies
        public ActionResult Index()
        {
            return View();
        }
        //加密
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
                string password = "";
                for (int i = 0; i < JiaMi.Length; i++)
                {
                    password = password + "*";
                }
                Session["jiami"] = "加密成功的数据:"+ password;
                Session["jiemi"] = JiaMi;
                return Content("<script>alert('加密成功！');window.open('" + Url.Action("Indexget", "JiasAndJies") + "', '_self')</script>");
            }
            else
                Session["jiami"] = "本次加密的数据不合法！";
                return Content("<script>alert('加密的数据不合法！');window.open('" + Url.Action("Indexget", "JiasAndJies") + "', '_self')</script>");
        }


        //解密
        // GET: JiasAndJies
        public ActionResult IndexJie()
        {
            return View();
        }
    }
}