using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NPCIL.Models;
using System;
using System.Net.Http;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace NPCIL.Controllers
{
    public class LoginController : Controller
    {
        const string CookieUserId = "UserId";
        const string CookieUserName = "UserName";
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public LoginController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (HttpContext.Request.Cookies["NPCIL_username"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            loginModel.IsValid = cmn.GetScalerValue("exec PRC_UserLogin " +
               "@userName='" + loginModel.loginId + "'," +
               "@password='" + loginModel.password + "'");

            if (loginModel.IsValid == "True")
            {
                CookieOptions cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(5)
                };
                Response.Cookies.Append("NPCIL_username", loginModel.loginId, cookieOptions);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout() 
        {
            CookieOptions cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(-5)
            };
            Response.Cookies.Append("NPCIL_username", "", cookieOptions);
            return RedirectToAction("Login", "Login");
        }
    }
}

