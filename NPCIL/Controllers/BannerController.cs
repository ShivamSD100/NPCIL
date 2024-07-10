using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using WebApplication1.Models;

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Http;
using NPCIL.Controllers;
using Microsoft.AspNetCore.Hosting.Server;

namespace WebApplication1.Controllers
{
    [CheckSession]
    public class BannerController : Controller
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public BannerController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddBanner()
        {
            return View();
        }

        public IActionResult EditBanner(int id = 0)
        {
            ViewBag.abc = "Submit";
            BannerModel obj = new BannerModel();
            DataTable dt = cmn.GetDatatable("exec PRC_AddBanner @qtype='3', " +
                            "@ban_sno='" + id + "'");
            
            if (dt.Rows.Count > 0)
            {
                obj.BannerId = int.Parse(dt.Rows[0]["ban_sno"].ToString());
                obj.BannerTitle = dt.Rows[0]["ban_title"].ToString();
                obj.BannerLinkURL = dt.Rows[0]["ban_linkURL"].ToString();
                obj.ImagePath = dt.Rows[0]["newImg"].ToString();
                obj.BannerTitleRegLang = dt.Rows[0]["ban_titleLang"].ToString();
                obj.BannerTagRegLang = dt.Rows[0]["ban_altTagLang"].ToString();
                obj.BannerAltTag = dt.Rows[0]["ban_altTag"].ToString();
                ViewBag.abc = "Update";
            }
            return View(obj);
        }


        public IActionResult BannerList()
        { 
            List<BannerModel> bannerList = new List<BannerModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_AddBanner @qtype=4");
            foreach(DataRow dr in dt.Rows)
            {
                BannerModel bannerModel = new BannerModel()
                {
                    BannerId = int.Parse(dr["Ban_Sno"].ToString()),
                    BannerTitle = dr["ban_title"].ToString(),
                    ImagePath = dr["newImg"].ToString()
                };
                bannerList.Add(bannerModel);
            }
            return View(bannerList);
        }

        [HttpPost]
        public IActionResult AddBanner(BannerModel bannerModel,IFormFile file)
        {
            var filePath = ""; 
            var filename="";
            if (bannerModel.BannerImg != null)
            {
                var uniqueFileName = GetUniqueFileName(bannerModel.BannerImg.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "BannerImages");
                filePath = Path.Combine(uploads, uniqueFileName);
                bannerModel.BannerImg.CopyTo(new FileStream(filePath, FileMode.Create));
                filename = "/BannerImages/" + uniqueFileName;
            }

                string ret = cmn.AddDelMod("exec PRC_AddBanner @qtype='1'," +
                    "@ban_title='" + bannerModel.BannerTitle + "'," +
                    "@ban_titleLang='" + bannerModel.BannerTitleRegLang + "'," +
                    "@ban_uploadImg='" + filename + "'," +
                    "@ban_linkURL='" + bannerModel.BannerLinkURL + "'," +
                    "@ban_altTag='" + bannerModel.BannerAltTag + "'," +
                    "@ban_altTagLang='" + bannerModel.BannerTagRegLang + "'");
                if (ret == "1")
                {
                    return RedirectToAction("BannerList");
                }
                else
                {
                    return View();
                }
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        public IActionResult Del(int id)
        {
            string ret = cmn.AddDelMod("exec PRC_AddBanner @qtype='5'," +
                            "@ban_sno='" + id + "'");
       
            if (ret == "5")
            {
                
                return RedirectToAction("BannerList");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult UpdateBanner(BannerModel bannerModel)
        {
            var filePath = "";
            var filename = "";
            if (bannerModel.BannerImg != null)
            {
                var uniqueFileName = GetUniqueFileName(bannerModel.BannerImg.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "BannerImages");
                filePath = Path.Combine(uploads, uniqueFileName);
                bannerModel.BannerImg.CopyTo(new FileStream(filePath, FileMode.Create));
                filename = "/BannerImages/" + uniqueFileName;
            }

            if (filePath == "")
                filePath = bannerModel.ImagePath;

            //var filePath = bannerModel.ImagePath; 
            //var filename = bannerModel.ImagePath; 

            //if (bannerModel.BannerImg != null)
            //{
            //    var uniqueFileName = GetUniqueFileName(bannerModel.BannerImg.FileName);
            //    var uploads = Path.Combine(hostingEnvironment.WebRootPath, "BannerImages");
            //    filePath = Path.Combine(uploads, uniqueFileName);


            //    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //    {
            //        bannerModel.BannerImg.CopyTo(fileStream);
            //    }

            //    filename = "/BannerImages/" + uniqueFileName;
            //}


            //if (filePath == bannerModel.ImagePath)
            //{
            //    filePath = bannerModel.ImagePath;
            //}

            string ret = cmn.AddDelMod("exec PRC_AddBanner @qtype='2'," +
                "@ban_sno='" + bannerModel.BannerId + "'," +
                "@ban_title='" + bannerModel.BannerTitle + "'," +
                "@ban_titleLang='" + bannerModel.BannerTitleRegLang + "'," +
                "@ban_uploadImg='" + filename + "'," +
                "@ban_linkURL='" + bannerModel.BannerLinkURL + "'," +
                "@ban_altTag='" + bannerModel.BannerAltTag + "'," +
                "@ban_altTagLang='" + bannerModel.BannerTagRegLang + "'");
            if (ret == "2")
            {
                return RedirectToAction("BannerList");
            }
            else
            {
                return View();
            }
        }
    }
}
