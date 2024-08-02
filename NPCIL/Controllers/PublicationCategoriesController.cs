using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System;
using WebApplication1.Models;
using NPCIL.Models;

namespace NPCIL.Controllers
{
    public class PublicationCategoriesController : Controller
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public PublicationCategoriesController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPublicationCategories()
        {
            return View();
        }

        public IActionResult EditPublicationCategories(int id = 0)
        {
            ViewBag.abc = "Submit";
            PublicationCategoriesModel obj = new PublicationCategoriesModel();
            DataTable dt = cmn.GetDatatable("exec PRC_AddPublicationCategories @qtype='3', " +
                            "@PC_sno='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                obj.CategoriesId = int.Parse(dt.Rows[0]["PC_sno"].ToString());
                obj.CategoriesTitle = dt.Rows[0]["PC_title"].ToString();
                obj.CategoriesLinkURL = dt.Rows[0]["PC_linkURL"].ToString();
                obj.ImagePath = dt.Rows[0]["PC_uploadImg"].ToString();
                obj.CategoriesTitleRegLang = dt.Rows[0]["PC_titleLang"].ToString();
                obj.CategoriesTagRegLang = dt.Rows[0]["PC_altTagLang"].ToString();
                obj.CategoriesAltTag = dt.Rows[0]["PC_altTag"].ToString();
                ViewBag.abc = "Update";
            }
            return View(obj);
        }


        public IActionResult PublicationCategoriesList()
        {
            List<PublicationCategoriesModel> publicationCategoriesList = new List<PublicationCategoriesModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_AddPublicationCategories @qtype=4");
            foreach (DataRow dr in dt.Rows)
            {
                PublicationCategoriesModel publicationCategoriesModel = new PublicationCategoriesModel()
                {
                    CategoriesId = int.Parse(dr["PC_sno"].ToString()),
                    CategoriesTitle = dr["PC_title"].ToString(),
                    ImagePath = dr["PC_uploadImg"].ToString()
                };
                publicationCategoriesList.Add(publicationCategoriesModel);
            }
            return View(publicationCategoriesList);
        }

        [HttpPost]
        public IActionResult AddPublicationCategories(PublicationCategoriesModel publicationCategoriesModel, IFormFile file)
        {
            var filePath = "";
            var filename = "";
            if (publicationCategoriesModel.CategoriesImg != null)
            {
                var uniqueFileName = GetUniqueFileName(publicationCategoriesModel.CategoriesImg.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "PubCatImages");
                filePath = Path.Combine(uploads, uniqueFileName);
                publicationCategoriesModel.CategoriesImg.CopyTo(new FileStream(filePath, FileMode.Create));
                filename = "/PubCatImages/" + uniqueFileName;
            }
            publicationCategoriesModel.ImagePath = filename == "" ? publicationCategoriesModel.ImagePath : filename;

            string ret = cmn.AddDelMod("exec PRC_AddPublicationCategories @qtype='1'," +
                "@PC_title='" + publicationCategoriesModel.CategoriesTitle + "'," +
                "@PC_titleLang=N'" + publicationCategoriesModel.CategoriesTitleRegLang + "'," +
                "@PC_uploadImg='" + publicationCategoriesModel.ImagePath + "'," +
                "@PC_linkURL='" + publicationCategoriesModel.CategoriesLinkURL + "'," +
                "@PC_altTag='" + publicationCategoriesModel.CategoriesAltTag + "'," +
                "@PC_altTagLang=N'" + publicationCategoriesModel.CategoriesTagRegLang + "'");
            if (ret == "1")
            {
                return RedirectToAction("publicationCategoriesList");
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

        public IActionResult DeletePublicationCategories(int id)
        {
            string ret = cmn.AddDelMod("exec PRC_AddPublicationCategories @qtype='5'," +
                            "@PC_sno='" + id + "'");
            if (ret == "5")
            {
                return RedirectToAction("publicationCategoriesList");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult UpdatePublicationCategories(PublicationCategoriesModel publicationCategoriesModel, IFormFile file)
        {
            var filePath = "";
            var filename = "";
            if (publicationCategoriesModel.CategoriesImg != null)
            {
                var uniqueFileName = GetUniqueFileName(publicationCategoriesModel.CategoriesImg.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "PubCatImages");
                filePath = Path.Combine(uploads, uniqueFileName);
                publicationCategoriesModel.CategoriesImg.CopyTo(new FileStream(filePath, FileMode.Create));
                filename = "/PubCatImages/" + uniqueFileName;
            }

            //if (filePath == "")
            //{
            //    filePath = publicationCategoriesModel.ImagePath;
            //    filename = Path.GetFileName(filePath);
            //}
            publicationCategoriesModel.ImagePath = filename == "" ? publicationCategoriesModel.ImagePath : filename;
            string ret = cmn.AddDelMod("exec PRC_AddPublicationCategories @qtype='2'," +
                "@pc_sno='" + publicationCategoriesModel.CategoriesId + "'," +
                 "@PC_title='" + publicationCategoriesModel.CategoriesTitle + "'," +
                "@PC_titleLang=N'" + publicationCategoriesModel.CategoriesTitleRegLang + "'," +
                "@PC_uploadImg='" + publicationCategoriesModel.ImagePath + "'," +
                "@PC_linkURL='" + publicationCategoriesModel.CategoriesLinkURL + "'," +
                "@PC_altTag='" + publicationCategoriesModel.CategoriesAltTag + "'," +
                "@PC_altTagLang=N'" + publicationCategoriesModel.CategoriesTagRegLang + "'");
            if (ret == "2")
            {
                return RedirectToAction("publicationCategoriesList");
            }
            else
            {
                return RedirectToAction("publicationCategoriesList");
            }
        }
    }
}
