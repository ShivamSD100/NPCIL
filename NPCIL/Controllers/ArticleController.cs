using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPCIL.Models;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System;

namespace NPCIL.Controllers
{
    [CheckSession]
    public class ArticleController : Controller
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public ArticleController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddArticle()
        {
            ArticleModel model = new ArticleModel();
            ViewBag.Listoflanguage = Planguage();
            ViewBag.Listofcontent = contentType();
            return View(model);
        }

        public List<ArticleModel> Planguage()
        {
            List<ArticleModel> languageList = new List<ArticleModel>();
            languageList.Insert(0, new ArticleModel { langId = 0, langName = "Select" });
            DataTable dt = cmn.GetDatatable("exec PRC_Language");
            foreach (DataRow dr in dt.Rows)
            {
                ArticleModel articleModel = new ArticleModel()
                {
                    langId = int.Parse(dr["lang_sno"].ToString()),
                    langName = dr["lang_name"].ToString()
                };
                languageList.Add(articleModel);
            }

            ViewBag.Listoflanguage = languageList;
            return languageList;
        }

        public List<ArticleModel> contentType()
        {
            List<ArticleModel> ContentList = new List<ArticleModel>();
            ContentList.Insert(0, new ArticleModel { contentId = 0, contentName = "Select" });
            DataTable dt = cmn.GetDatatable("exec PRC_MenuType @qtype=1");
            foreach (DataRow dr in dt.Rows)
            {
                ArticleModel articleModel = new ArticleModel()
                {
                    contentId = int.Parse(dr["mt_sno"].ToString()),
                    contentName = dr["mt_name"].ToString()
                };
                ContentList.Add(articleModel);
            }

            ViewBag.Listofcontent = ContentList;
            return ContentList;
        }

        [HttpPost]
        public IActionResult AddArticle(ArticleModel articleModel, IFormFile file)
        {
            var filePath = "";
            var filename = "";
            if (articleModel.ArticleImg != null)
            {
                var uniqueFileName = GetUniqueFileName(articleModel.ArticleImg.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "ArticleImage");
                filePath = Path.Combine(uploads, uniqueFileName);
                articleModel.ArticleImg.CopyTo(new FileStream(filePath, FileMode.Create));
                filename = "/ArticleImage/" + uniqueFileName;
            }
            articleModel.ImagePath = filename == "" ? articleModel.ImagePath : filename;
            articleModel.StartDate = String.Format("{0:MM-dd-yyyy}", articleModel.StartDate_Display == null ? "" : articleModel.StartDate_Display.Value);
            articleModel.EndDate = String.Format("{0:MM-dd-yyyy}", articleModel.EndDate_Display == null ? "" : articleModel.EndDate_Display.Value);
            string ret = cmn.AddDelMod("exec PRC_Articles @qtype='1'," +
                                "@language='" + articleModel.langId + "'," +
                                "@content='" + articleModel.contentId + "'," +
                                "@title='" + articleModel.title + "'," +
                                "@description=N'" + articleModel.description + "'," +
                                "@fileupload='" + articleModel.ImagePath + "'," +
                                "@linkurl='" + articleModel.link + "'," +
                                "@start='" + articleModel.StartDate + "'," +
                                "@end='" + articleModel.EndDate + "'");

            if (ret == "1")
            {
                return RedirectToAction("ArticleList");
            }
            else
            {
                ViewBag.Error = "Some Error Occurred";
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

        public IActionResult ArticleList()
        {
            List<ArticleModel> articleList = new List<ArticleModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_Articles @qtype=2");
            foreach (DataRow dr in dt.Rows)
            {
                ArticleModel articleModel = new ArticleModel()
                {
                    id = int.Parse(dr["A_sno"].ToString()),
                    title = dr["A_Title"].ToString(),
                    StartDate = dr["A_StartDate"].ToString(),
                    EndDate = dr["A_EndDate"].ToString()
                };
                articleList.Add(articleModel);
            }
            return View(articleList);
        }

        public IActionResult EditArticle(int id = 0)
        {

            ViewBag.Listoflanguage = Planguage();
            ViewBag.Listofcontent = contentType();
            ArticleModel obj = new ArticleModel();
            DataTable dt = cmn.GetDatatable("exec PRC_Articles @qtype=3, " +
                            "@id='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                obj.id = int.Parse(dt.Rows[0]["A_sno"].ToString());
                obj.langId = int.Parse(dt.Rows[0]["A_Language"].ToString());
                obj.langName = dt.Rows[0]["A_Language"].ToString();
                obj.contentId = int.Parse(dt.Rows[0]["A_Content"].ToString());
                obj.contentName = dt.Rows[0]["A_Content"].ToString();
                obj.title = dt.Rows[0]["A_Title"].ToString();
                obj.description = dt.Rows[0]["A_PageDescription"].ToString();
                obj.ImagePath = dt.Rows[0]["A_FileUpload"].ToString();
                obj.link = dt.Rows[0]["A_LinkURL"].ToString();
                if (!String.IsNullOrEmpty(dt.Rows[0]["A_StartDate"].ToString()))
                {
                    obj.StartDate_Display = Convert.ToDateTime(dt.Rows[0]["A_StartDate"].ToString());
                }
                if (!String.IsNullOrEmpty(dt.Rows[0]["A_EndDate"].ToString()))
                {
                    obj.EndDate_Display = Convert.ToDateTime(dt.Rows[0]["A_EndDate"].ToString());
                }
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult UpdateArticle(ArticleModel articleModel, IFormFile file)
        {
            var filePath = "";
            var filename = "";
            if (articleModel.ArticleImg != null)
            {
                var uniqueFileName = GetUniqueFileName(articleModel.ArticleImg.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "ArticleImage");
                filePath = Path.Combine(uploads, uniqueFileName);
                articleModel.ArticleImg.CopyTo(new FileStream(filePath, FileMode.Create));
                filename = "/ArticleImage/" + uniqueFileName;
            }
            articleModel.ImagePath = filename == "" ? articleModel.ImagePath : filename;
            articleModel.StartDate = String.Format("{0:MM-dd-yyyy}", articleModel.StartDate_Display == null ? "" : articleModel.StartDate_Display.Value);
            articleModel.EndDate = String.Format("{0:MM-dd-yyyy}", articleModel.EndDate_Display == null ? "" : articleModel.EndDate_Display.Value);
            string ret = cmn.AddDelMod("exec PRC_Articles @qtype=4," +
                                "@language='" + articleModel.langId + "'," +
                                "@content='" + articleModel.contentId + "'," +
                                "@title='" + articleModel.title + "'," +
                                "@description=N'" + articleModel.description + "'," +
                                "@fileupload='" + articleModel.ImagePath + "'," +
                                "@linkurl='" + articleModel.link + "'," +
                                "@start='" + articleModel.StartDate + "'," +
                                "@end='" + articleModel.EndDate + "'");

            if (ret == "4")
            {
                return RedirectToAction("ArticleList");
            }
            else
            {
                ViewBag.Error = "Some Error Occurred";
                return View();
            }
        }

        public IActionResult DeleteArticle(int id)
        {
            string ret = cmn.AddDelMod("exec PRC_Articles @qtype='5'," +
                            "@id='" + id + "'");

            if (ret == "5")
            {
                return RedirectToAction("ArticleList");
            }
            else
            {
                return View();
            }
        }
    }
}
