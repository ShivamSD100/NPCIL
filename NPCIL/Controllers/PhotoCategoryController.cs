using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPCIL.Models;
using System.Collections.Generic;
using System.Data;
using System.IO;
using WebApplication1.Models;

namespace NPCIL.Controllers
{
    [CheckSession]
    public class PhotoCategoryController : Controller
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public PhotoCategoryController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPhotoCategory()
        {
            return View();
        }

        public IActionResult PhotoCategoryList()
        {
            List<PhotoCategoryModel> photoList = new List<PhotoCategoryModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_PhotoCategory @qtype=2");
            foreach (DataRow dr in dt.Rows)
            {
                PhotoCategoryModel photoCategoryModel = new PhotoCategoryModel()
                {
                    PCid = int.Parse(dr["PhC_id"].ToString()),
                    title = dr["PhC_Title"].ToString()
                };
                photoList.Add(photoCategoryModel);
            }
            return View(photoList);
        }

        [HttpPost]
        public IActionResult AddPhotoCategory(PhotoCategoryModel photoCategoryModel)
        {
            string ret = cmn.AddDelMod("exec PRC_PhotoCategory @qtype='1'," +
                "@title='" + photoCategoryModel.title + "'");
            if (ret == "1")
            {
                return RedirectToAction("PhotoCategoryList");
            }
            else
            {
                return View();
            }
        }

        public IActionResult EditPhotoCategory(int id = 0)
        {
            PhotoCategoryModel obj = new PhotoCategoryModel();
            DataTable dt = cmn.GetDatatable("exec PRC_PhotoCategory @qtype='3', " +
                            "@id='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                obj.PCid = int.Parse(dt.Rows[0]["PhC_id"].ToString());
                obj.title = dt.Rows[0]["PhC_Title"].ToString();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult UpdatePhotoCategory(PhotoCategoryModel photoCategoryModel)
        {
            string ret = cmn.AddDelMod("exec PRC_PhotoCategory @qtype='4'," +
                "@id='" + photoCategoryModel.PCid + "'," +
                "@title='" + photoCategoryModel.title  + "'");
            if (ret == "4")
            {
                return RedirectToAction("PhotoCategoryList");
            }
            else
            {
                return View();
            }
        }

        public IActionResult DeletePhotoCategory(int id)
        {
            string ret = cmn.AddDelMod("exec PRC_PhotoCategory @qtype='5'," +
                            "@id='" + id + "'");
            if (ret == "5")
            {
                return RedirectToAction("PhotoCategoryList");
            }
            else
            {
                return View();
            }
        }
    }
}
