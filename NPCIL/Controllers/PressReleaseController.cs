using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NPCIL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using WebApplication1.Models;

namespace NPCIL.Controllers
{
    [CheckSession]
    public class PressReleaseController : Controller
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public PressReleaseController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPressRelease()
        {
            PressReleaseModel model = new PressReleaseModel();
            ViewBag.Listoflanguage = Planguage();
            ViewBag.Listofcontent = contentType();
            return View(model);
        }

        public List<PressReleaseModel> Planguage()
        {
            List<PressReleaseModel> languageList = new List<PressReleaseModel>();
            languageList.Insert(0, new PressReleaseModel { langId = 0, langName = "Select" });
            DataTable dt = cmn.GetDatatable("exec PRC_Language");
            foreach (DataRow dr in dt.Rows)
            {
                PressReleaseModel pressModel = new PressReleaseModel()
                {
                    langId = int.Parse(dr["lang_sno"].ToString()),
                    langName = dr["lang_name"].ToString()
                };
                languageList.Add(pressModel);
            }
            
            ViewBag.Listoflanguage = languageList;
            return languageList;
        }

        public List<PressReleaseModel> contentType()
        {
            List<PressReleaseModel> ContentList = new List<PressReleaseModel>();
            ContentList.Insert(0, new PressReleaseModel { contentId = 0, contentName = "Select" });
            DataTable dt = cmn.GetDatatable("exec PRC_MenuType @qtype=1");
            foreach (DataRow dr in dt.Rows)
            {
                PressReleaseModel pressModel = new PressReleaseModel()
                {
                    contentId = int.Parse(dr["mt_sno"].ToString()),
                    contentName = dr["mt_name"].ToString()
                };
                ContentList.Add(pressModel);
            }
           
            ViewBag.Listofcontent = ContentList;
            return ContentList;
        }

        [HttpPost]
        public IActionResult AddPressRelease(PressReleaseModel pressReleaseModel, IFormFile file)
        {
            var filePath = "";
            var filename = "";
            if (pressReleaseModel.PressImg != null)
            {
                var uniqueFileName = GetUniqueFileName(pressReleaseModel.PressImg.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "PressImage");
                filePath = Path.Combine(uploads, uniqueFileName);
                pressReleaseModel.PressImg.CopyTo(new FileStream(filePath, FileMode.Create));
                filename = "/PressImage/" + uniqueFileName;
            }
            pressReleaseModel.ImagePath = filename == "" ? pressReleaseModel.ImagePath : filename;
            pressReleaseModel.StartDate = String.Format("{0:MM-dd-yyyy}", pressReleaseModel.StartDate_Display == null ? "" : pressReleaseModel.StartDate_Display.Value);
            pressReleaseModel.EndDate = String.Format("{0:MM-dd-yyyy}", pressReleaseModel.EndDate_Display == null ? "" : pressReleaseModel.EndDate_Display.Value);
            string ret = cmn.AddDelMod("exec PRC_PressRelease @qtype='1'," +
                                "@language='" + pressReleaseModel.langId + "'," +
                                "@content='" + pressReleaseModel.contentId + "'," +
                                "@title='" + pressReleaseModel.title + "'," +
                                "@description=N'" + pressReleaseModel.description + "'," +
                                "@fileupload='" + pressReleaseModel.ImagePath + "'," +
                                "@linkurl='" + pressReleaseModel.link + "'," +
                                "@start='" + pressReleaseModel.StartDate + "'," +
                                "@end='" + pressReleaseModel.EndDate + "'");

            if (ret == "1")
            {
                return RedirectToAction("PressReleaseList");
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

        public IActionResult PressReleaseList()
        {

            List<PressReleaseModel> pressReleaseList = new List<PressReleaseModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_PressRelease @qtype=2");
            foreach (DataRow dr in dt.Rows)
            {
                PressReleaseModel pressReleaseModel = new PressReleaseModel()
                {
                    id = int.Parse(dr["PR_sno"].ToString()),
                    title = dr["PR_Title"].ToString(),
                    StartDate = dr["PR_StartDate"].ToString(),
                    EndDate = dr["PR_EndDate"].ToString()
                };
                pressReleaseList.Add(pressReleaseModel);
            }
            return View(pressReleaseList);
        }

        public IActionResult EditPressRelease(int id = 0)
        {

            ViewBag.Listoflanguage = Planguage();
            ViewBag.Listofcontent = contentType();
            PressReleaseModel obj = new PressReleaseModel();
            DataTable dt = cmn.GetDatatable("exec PRC_PressRelease @qtype=3, " +
                            "@id='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                obj.id = int.Parse(dt.Rows[0]["PR_sno"].ToString());
                obj.langId = int.Parse(dt.Rows[0]["PR_Language"].ToString());
                obj.langName = dt.Rows[0]["PR_Language"].ToString();
                obj.contentId = int.Parse(dt.Rows[0]["PR_Content"].ToString());
                obj.contentName = dt.Rows[0]["PR_Content"].ToString();
                obj.title = dt.Rows[0]["PR_Title"].ToString();
                obj.description = dt.Rows[0]["PR_PageDescription"].ToString();
                obj.ImagePath = dt.Rows[0]["PR_FileUpload"].ToString();
                obj.link = dt.Rows[0]["PR_LinkURL"].ToString();
                if (!String.IsNullOrEmpty(dt.Rows[0]["PR_StartDate"].ToString()))
                {
                    obj.StartDate_Display = Convert.ToDateTime(dt.Rows[0]["PR_StartDate"].ToString());
                }
                if (!String.IsNullOrEmpty(dt.Rows[0]["PR_EndDate"].ToString()))
                {
                    obj.EndDate_Display = Convert.ToDateTime(dt.Rows[0]["PR_EndDate"].ToString());
                }
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult UpdatePressRelease(PressReleaseModel pressReleaseModel, IFormFile file)
        {
            var filePath = "";
            var filename = "";
            if (pressReleaseModel.PressImg != null)
            {
                var uniqueFileName = GetUniqueFileName(pressReleaseModel.PressImg.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "PressImage");
                filePath = Path.Combine(uploads, uniqueFileName);
                pressReleaseModel.PressImg.CopyTo(new FileStream(filePath, FileMode.Create));
                filename = "/PressImage/" + uniqueFileName;
            }
            pressReleaseModel.ImagePath = filename == "" ? pressReleaseModel.ImagePath : filename;
            pressReleaseModel.StartDate = String.Format("{0:MM-dd-yyyy}", pressReleaseModel.StartDate_Display == null ? "" : pressReleaseModel.StartDate_Display.Value);
            pressReleaseModel.EndDate = String.Format("{0:MM-dd-yyyy}", pressReleaseModel.EndDate_Display == null ? "" : pressReleaseModel.EndDate_Display.Value);
            string ret = cmn.AddDelMod("exec PRC_PressRelease @qtype=4," +
                                "@language='" + pressReleaseModel.langId + "'," +
                                "@content='" + pressReleaseModel.contentId + "'," +
                                "@title='" + pressReleaseModel.title + "'," +
                                "@description=N'" + pressReleaseModel.description + "'," +
                                "@fileupload='" + pressReleaseModel.ImagePath + "'," +
                                "@linkurl='" + pressReleaseModel.link + "'," +
                                "@start='" + pressReleaseModel.StartDate + "'," +
                                "@end='" + pressReleaseModel.EndDate + "'");

            if (ret == "4")
            {
                return RedirectToAction("PressReleaseList");
            }
            else
            {
                ViewBag.Error = "Some Error Occurred";
                return View();
            }
        }

        public IActionResult DeletePressRelease(int id)
        {
            string ret = cmn.AddDelMod("exec PRC_PressRelease @qtype='5'," +
                            "@id='" + id + "'");

            if (ret == "5")
            {
                return RedirectToAction("PressReleaseList");
            }
            else
            {
                return View();
            }
        }
    }
}
