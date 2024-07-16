﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPCIL.Models;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System;
using NPCIL.Helper;
using WebApplication1.Models;

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
                Banners = _npcilHelper.GetBanners(),
                Menus = _npcilHelper.GetMenus(),
                HorizontalNews = _npcilHelper.GetHorizontalNews(),
                VerticalNews = _npcilHelper.GetVerticalNews(),
                Tenders = _npcilHelper.GetTenders()
            };

            return View(model);
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