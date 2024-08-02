using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPCIL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace NPCIL.Controllers
{
    [CheckSession]
    public class GeneralController : Controller
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public GeneralController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddGeneral()
        {
            GeneralModel model = new GeneralModel();
            ViewBag.Listoflanguage = Planguage();
            ViewBag.Listofcontent = contentType();
            return View(model);
        }

        public List<GeneralModel> Planguage()
        {
            List<GeneralModel> languageList = new List<GeneralModel>();
            languageList.Insert(0, new GeneralModel { langId = 0, langName = "Select" });
            DataTable dt = cmn.GetDatatable("exec PRC_Language");
            foreach (DataRow dr in dt.Rows)
            {
                GeneralModel generalModel = new GeneralModel()
                {
                    langId = int.Parse(dr["lang_sno"].ToString()),
                    langName = dr["lang_name"].ToString()
                };
                languageList.Add(generalModel);
            }

            ViewBag.Listoflanguage = languageList;
            return languageList;
        }

        public List<GeneralModel> contentType()
        {
            List<GeneralModel> ContentList = new List<GeneralModel>();
            ContentList.Insert(0, new GeneralModel { contentId = 0, contentName = "Select" });
            DataTable dt = cmn.GetDatatable("exec PRC_MenuType @qtype=1");
            foreach (DataRow dr in dt.Rows)
            {
                GeneralModel generalModel = new GeneralModel()
                {
                    contentId = int.Parse(dr["mt_sno"].ToString()),
                    contentName = dr["mt_name"].ToString()
                };
                ContentList.Add(generalModel);
            }

            ViewBag.Listofcontent = ContentList;
            return ContentList;
        }

        [HttpPost]
        public IActionResult AddGeneral(GeneralModel generalModel, IFormFile file)
        {
            var filePath = "";
            var filename = "";
            if (generalModel.GenImg != null)
            {
                var uniqueFileName = GetUniqueFileName(generalModel.GenImg.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "GeneralImage");
                filePath = Path.Combine(uploads, uniqueFileName);
                generalModel.GenImg.CopyTo(new FileStream(filePath, FileMode.Create));
                filename = "/GeneralImage/" + uniqueFileName;
            }
            generalModel.ImagePath = filename == "" ? generalModel.ImagePath : filename;
            generalModel.StartDate = String.Format("{0:MM-dd-yyyy}", generalModel.StartDate_Display == null ? "" : generalModel.StartDate_Display.Value);
            generalModel.EndDate = String.Format("{0:MM-dd-yyyy}", generalModel.EndDate_Display == null ? "" : generalModel.EndDate_Display.Value);
            string ret = cmn.AddDelMod("exec PRC_General @qtype='1'," +
                                "@language='" + generalModel.langId + "'," +
                                "@content='" + generalModel.contentId + "'," +
                                "@title='" + generalModel.title + "'," +
                                "@description=N'" + generalModel.description + "'," +
                                "@fileupload='" + generalModel.ImagePath + "'," +
                                "@linkurl='" + generalModel.link + "'," +
                                "@start='" + generalModel.StartDate + "'," +
                                "@end='" + generalModel.EndDate + "'");

            if (ret == "1")
            {
                return RedirectToAction("GeneralList");
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

        public IActionResult GeneralList()
        {
            List<GeneralModel> genaralList = new List<GeneralModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_General @qtype=2");
            foreach (DataRow dr in dt.Rows)
            {
                GeneralModel generalModel = new GeneralModel()
                {
                    id = int.Parse(dr["Gen_sno"].ToString()),
                    title = dr["Gen_Title"].ToString(),
                    StartDate = dr["Gen_StartDate"].ToString(),
                    EndDate = dr["Gen_EndDate"].ToString()
                };
                genaralList.Add(generalModel);
            }
            return View(genaralList);
        }

        public IActionResult EditGeneral(int id = 0)
        {

            ViewBag.Listoflanguage = Planguage();
            ViewBag.Listofcontent = contentType();
            GeneralModel obj = new GeneralModel();
            DataTable dt = cmn.GetDatatable("exec PRC_General @qtype=3, " +
                            "@id='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                obj.id = int.Parse(dt.Rows[0]["Gen_sno"].ToString());
                obj.langId = int.Parse(dt.Rows[0]["Gen_Language"].ToString());
                obj.langName = dt.Rows[0]["Gen_Language"].ToString();
                obj.contentId = int.Parse(dt.Rows[0]["Gen_Content"].ToString());
                obj.contentName = dt.Rows[0]["Gen_Content"].ToString();
                obj.title = dt.Rows[0]["Gen_Title"].ToString();
                obj.description = dt.Rows[0]["Gen_PageDescription"].ToString();
                obj.ImagePath = dt.Rows[0]["Gen_FileUpload"].ToString();
                obj.link = dt.Rows[0]["Gen_LinkURL"].ToString();
                if (!String.IsNullOrEmpty(dt.Rows[0]["Gen_StartDate"].ToString()))
                {
                    obj.StartDate_Display = Convert.ToDateTime(dt.Rows[0]["Gen_StartDate"].ToString());
                }
                if (!String.IsNullOrEmpty(dt.Rows[0]["Gen_EndDate"].ToString()))
                {
                    obj.EndDate_Display = Convert.ToDateTime(dt.Rows[0]["Gen_EndDate"].ToString());
                }
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult UpdateGeneral(GeneralModel generalModel, IFormFile file)
        {
            var filePath = "";
            var filename = "";
            if (generalModel.GenImg != null)
            {
                var uniqueFileName = GetUniqueFileName(generalModel.GenImg.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "GeneralImage");
                filePath = Path.Combine(uploads, uniqueFileName);
                generalModel.GenImg.CopyTo(new FileStream(filePath, FileMode.Create));
                filename = "/GeneralImage/" + uniqueFileName;
            }
            generalModel.ImagePath = filename == "" ? generalModel.ImagePath : filename;
            generalModel.StartDate = String.Format("{0:MM-dd-yyyy}", generalModel.StartDate_Display == null ? "" : generalModel.StartDate_Display.Value);
            generalModel.EndDate = String.Format("{0:MM-dd-yyyy}", generalModel.EndDate_Display == null ? "" : generalModel.EndDate_Display.Value);
            string ret = cmn.AddDelMod("exec PRC_General @qtype=4," +
                                "@language='" + generalModel.langId + "'," +
                                "@content='" + generalModel.contentId + "'," +
                                "@title='" + generalModel.title + "'," +
                                "@description=N'" + generalModel.description + "'," +
                                "@fileupload='" + generalModel.ImagePath + "'," +
                                "@linkurl='" + generalModel.link + "'," +
                                "@start='" + generalModel.StartDate + "'," +
                                "@end='" + generalModel.EndDate + "'");

            if (ret == "4")
            {
                return RedirectToAction("GeneralList");
            }
            else
            {
                ViewBag.Error = "Some Error Occurred";
                return View();
            }
        }

        public IActionResult DeleteGeneral(int id)
        {
            string ret = cmn.AddDelMod("exec PRC_General @qtype='5'," +
                            "@id='" + id + "'");

            if (ret == "5")
            {
                return RedirectToAction("GeneralList");
            }
            else
            {
                return View();
            }
        }
    }
}
