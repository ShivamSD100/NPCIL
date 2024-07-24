using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPCIL.Models;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System;
using NPCIL.Helper;
using WebApplication1.Models;
using System.Linq;

namespace NPCIL.Controllers
{
    public class HomePageController : Controller
    {

        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        private readonly INPCILHelper _npcilHelper;

        public HomePageController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment, INPCILHelper npcilHelper)
        {
            hostingEnvironment = environment;
            _npcilHelper = npcilHelper;
        }
        public ActionResult Index()
        {

            HomeModel model = new HomeModel()
            {
                Banners = _npcilHelper.GetActiveBanners(),
                Menus = _npcilHelper.GetActiveMenus(),
                HorizontalNews = _npcilHelper.GetActiveHorizontalNews(),
                VerticalNews = _npcilHelper.GetActiveVerticalNews(),
                Tenders = _npcilHelper.GetActiveTenders()
            };
            var language = HttpContext.Session.GetString("Language") ?? "English";
            ViewBag.SelectedLanguage = language;
            return View(model);
        }
        [HttpPost]
        public IActionResult SetLanguage(string language)
        {
            HttpContext.Session.SetString("Language", language);
            var returnUrl = Request.Headers["Referer"].ToString(); // Get the previous page URL
            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = Url.Action("Index", "Home"); // Default page if Referer is empty
            }
            return RedirectToAction("returnUrl");
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create(HomeModel model)
        {
            return View();
        }

        public ActionResult Edit(HomeModel model)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
