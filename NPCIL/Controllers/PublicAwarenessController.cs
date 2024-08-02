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
    public class PublicAwarenessController : Controller
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public PublicAwarenessController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPublicAwareness()
        {
            PublicAwarenessModel model = new PublicAwarenessModel();
            ViewBag.Listoflanguage = Planguage();
            ViewBag.Listofcontent = contentType();
            return View(model);
        }

        public List<PublicAwarenessModel> Planguage()
        {
            List<PublicAwarenessModel> languageList = new List<PublicAwarenessModel>();
            languageList.Insert(0, new PublicAwarenessModel { langId = 0, langName = "Select" });
            DataTable dt = cmn.GetDatatable("exec PRC_Language");
            foreach (DataRow dr in dt.Rows)
            {
                PublicAwarenessModel publicModel = new PublicAwarenessModel()
                {
                    langId = int.Parse(dr["lang_sno"].ToString()),
                    langName = dr["lang_name"].ToString()
                };
                languageList.Add(publicModel);
            }

            ViewBag.Listoflanguage = languageList;
            return languageList;
        }

        public List<PublicAwarenessModel> contentType()
        {
            List<PublicAwarenessModel> ContentList = new List<PublicAwarenessModel>();
            ContentList.Insert(0, new PublicAwarenessModel { contentId = 0, contentName = "Select" });
            DataTable dt = cmn.GetDatatable("exec PRC_MenuType @qtype=1");
            foreach (DataRow dr in dt.Rows)
            {
                PublicAwarenessModel publicModel = new PublicAwarenessModel()
                {
                    contentId = int.Parse(dr["mt_sno"].ToString()),
                    contentName = dr["mt_name"].ToString()
                };
                ContentList.Add(publicModel);
            }

            ViewBag.Listofcontent = ContentList;
            return ContentList;
        }

        [HttpPost]
        public IActionResult AddPublicAwareness(PublicAwarenessModel publicAwarenessModel, IFormFile file)
        {
            var filePath = "";
            var filename = "";
            if (publicAwarenessModel.PublicImg != null)
            {
                var uniqueFileName = GetUniqueFileName(publicAwarenessModel.PublicImg.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "PublicImage");
                filePath = Path.Combine(uploads, uniqueFileName);
                publicAwarenessModel.PublicImg.CopyTo(new FileStream(filePath, FileMode.Create));
                filename = "/PublicImage/" + uniqueFileName;
            }
            publicAwarenessModel.ImagePath = filename == "" ? publicAwarenessModel.ImagePath : filename;
            publicAwarenessModel.StartDate = String.Format("{0:MM-dd-yyyy}", publicAwarenessModel.StartDate_Display == null ? "" : publicAwarenessModel.StartDate_Display.Value);
            publicAwarenessModel.EndDate = String.Format("{0:MM-dd-yyyy}", publicAwarenessModel.EndDate_Display == null ? "" : publicAwarenessModel.EndDate_Display.Value);
            string ret = cmn.AddDelMod("exec PRC_PublicAwareness @qtype='1'," +
                                "@language='" + publicAwarenessModel.langId + "'," +
                                "@content='" + publicAwarenessModel.contentId + "'," +
                                "@title='" + publicAwarenessModel.title + "'," +
                                "@description=N'" + publicAwarenessModel.description + "'," +
                                "@fileupload='" + publicAwarenessModel.ImagePath + "'," +
                                "@linkurl='" + publicAwarenessModel.link + "'," +
                                "@start='" + publicAwarenessModel.StartDate + "'," +
                                "@end='" + publicAwarenessModel.EndDate + "'");

            if (ret == "1")
            {
                return RedirectToAction("PublicAwarenessList");
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

        public IActionResult PublicAwarenessList()
        {
            List<PublicAwarenessModel> publicAwarenessList = new List<PublicAwarenessModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_PublicAwareness @qtype=2");
            foreach (DataRow dr in dt.Rows)
            {
                PublicAwarenessModel publicAwarenessModel = new PublicAwarenessModel()
                {
                    id = int.Parse(dr["PA_sno"].ToString()),
                    title = dr["PA_Title"].ToString(),
                    StartDate = dr["PA_StartDate"].ToString(),
                    EndDate = dr["PA_EndDate"].ToString()
                };
                publicAwarenessList.Add(publicAwarenessModel);
            }
            return View(publicAwarenessList);
        }

        public IActionResult EditPublicAwareness(int id = 0)
        {

            ViewBag.Listoflanguage = Planguage();
            ViewBag.Listofcontent = contentType();
            PublicAwarenessModel obj = new PublicAwarenessModel();
            DataTable dt = cmn.GetDatatable("exec PRC_PublicAwareness @qtype=3, " +
                            "@id='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                obj.id = int.Parse(dt.Rows[0]["PA_sno"].ToString());
                obj.langId = int.Parse(dt.Rows[0]["PA_Language"].ToString());
                obj.langName = dt.Rows[0]["PA_Language"].ToString();
                obj.contentId = int.Parse(dt.Rows[0]["PA_Content"].ToString());
                obj.contentName = dt.Rows[0]["PA_Content"].ToString();
                obj.title = dt.Rows[0]["PA_Title"].ToString();
                obj.description = dt.Rows[0]["PA_PageDescription"].ToString();
                obj.ImagePath = dt.Rows[0]["PA_FileUpload"].ToString();
                obj.link = dt.Rows[0]["PA_LinkURL"].ToString();
                if (!String.IsNullOrEmpty(dt.Rows[0]["PA_StartDate"].ToString()))
                {
                    obj.StartDate_Display = Convert.ToDateTime(dt.Rows[0]["PA_StartDate"].ToString());
                }
                if (!String.IsNullOrEmpty(dt.Rows[0]["PA_EndDate"].ToString()))
                {
                    obj.EndDate_Display = Convert.ToDateTime(dt.Rows[0]["PA_EndDate"].ToString());
                }
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult UpdatePublicAwareness(PublicAwarenessModel publicAwarenessModel, IFormFile file)
        {
            var filePath = "";
            var filename = "";
            if (publicAwarenessModel.PublicImg != null)
            {
                var uniqueFileName = GetUniqueFileName(publicAwarenessModel.PublicImg.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "PressImage");
                filePath = Path.Combine(uploads, uniqueFileName);
                publicAwarenessModel.PublicImg.CopyTo(new FileStream(filePath, FileMode.Create));
                filename = "/PublicImage/" + uniqueFileName;
            }
            publicAwarenessModel.ImagePath = filename == "" ? publicAwarenessModel.ImagePath : filename;
            publicAwarenessModel.StartDate = String.Format("{0:MM-dd-yyyy}", publicAwarenessModel.StartDate_Display == null ? "" : publicAwarenessModel.StartDate_Display.Value);
            publicAwarenessModel.EndDate = String.Format("{0:MM-dd-yyyy}", publicAwarenessModel.EndDate_Display == null ? "" : publicAwarenessModel.EndDate_Display.Value);
            string ret = cmn.AddDelMod("exec PRC_PublicAwareness @qtype=4," +
                                "@language='" + publicAwarenessModel.langId + "'," +
                                "@content='" + publicAwarenessModel.contentId + "'," +
                                "@title='" + publicAwarenessModel.title + "'," +
                                "@description=N'" + publicAwarenessModel.description + "'," +
                                "@fileupload='" + publicAwarenessModel.ImagePath + "'," +
                                "@linkurl='" + publicAwarenessModel.link + "'," +
                                "@start='" + publicAwarenessModel.StartDate + "'," +
                                "@end='" + publicAwarenessModel.EndDate + "'");

            if (ret == "4")
            {
                return RedirectToAction("PublicAwarenessList");
            }
            else
            {
                ViewBag.Error = "Some Error Occurred";
                return View();
            }
        }

        public IActionResult DeletePressRelease(int id)
        {
            string ret = cmn.AddDelMod("exec PRC_PublicAwareness @qtype='5'," +
                            "@id='" + id + "'");

            if (ret == "5")
            {
                return RedirectToAction("PublicAwarenessList");
            }
            else
            {
                return View();
            }
        }
    }
}
