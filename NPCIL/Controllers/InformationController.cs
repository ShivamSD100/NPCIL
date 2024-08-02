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
    public class InformationController : Controller
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public InformationController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddInformation()
        {
            InformationModel model = new InformationModel();
            ViewBag.Listoflanguage = Planguage();
            ViewBag.Listofcontent = contentType();
            return View(model);
        }

        public List<InformationModel> Planguage()
        {
            List<InformationModel> languageList = new List<InformationModel>();
            languageList.Insert(0, new InformationModel { langId = 0, langName = "Select" });
            DataTable dt = cmn.GetDatatable("exec PRC_Language");
            foreach (DataRow dr in dt.Rows)
            {
                InformationModel informationModel = new InformationModel()
                {
                    langId = int.Parse(dr["lang_sno"].ToString()),
                    langName = dr["lang_name"].ToString()
                };
                languageList.Add(informationModel);
            }

            ViewBag.Listoflanguage = languageList;
            return languageList;
        }

        public List<InformationModel> contentType()
        {
            List<InformationModel> ContentList = new List<InformationModel>();
            ContentList.Insert(0, new InformationModel { contentId = 0, contentName = "Select" });
            DataTable dt = cmn.GetDatatable("exec PRC_MenuType @qtype=1");
            foreach (DataRow dr in dt.Rows)
            {
                InformationModel informationModel = new InformationModel()
                {
                    contentId = int.Parse(dr["mt_sno"].ToString()),
                    contentName = dr["mt_name"].ToString()
                };
                ContentList.Add(informationModel);
            }

            ViewBag.Listofcontent = ContentList;
            return ContentList;
        }

        [HttpPost]
        public IActionResult AddInformation(InformationModel informationModel, IFormFile file)
        {
            var filePath = "";
            var filename = "";
            if (informationModel.InfoImg != null)
            {
                var uniqueFileName = GetUniqueFileName(informationModel.InfoImg.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "InfoImage");
                filePath = Path.Combine(uploads, uniqueFileName);
                informationModel.InfoImg.CopyTo(new FileStream(filePath, FileMode.Create));
                filename = "/InfoImage/" + uniqueFileName;
            }
            informationModel.ImagePath = filename == "" ? informationModel.ImagePath : filename;
            informationModel.StartDate = String.Format("{0:MM-dd-yyyy}", informationModel.StartDate_Display == null ? "" : informationModel.StartDate_Display.Value);
            informationModel.EndDate = String.Format("{0:MM-dd-yyyy}", informationModel.EndDate_Display == null ? "" : informationModel.EndDate_Display.Value);
            string ret = cmn.AddDelMod("exec PRC_Information @qtype='1'," +
                                "@language='" + informationModel.langId + "'," +
                                "@content='" + informationModel.contentId + "'," +
                                "@title='" + informationModel.title + "'," +
                                "@description=N'" + informationModel.description + "'," +
                                "@fileupload='" + informationModel.ImagePath + "'," +
                                "@linkurl='" + informationModel.link + "'," +
                                "@start='" + informationModel.StartDate + "'," +
                                "@end='" + informationModel.EndDate + "'");

            if (ret == "1")
            {
                return RedirectToAction("InformationList");
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

        public IActionResult InformationList()
        {
            List<InformationModel> informationList = new List<InformationModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_Information @qtype=2");
            foreach (DataRow dr in dt.Rows)
            {
                InformationModel informationModel = new InformationModel()
                {
                    id = int.Parse(dr["I_sno"].ToString()),
                    title = dr["I_Title"].ToString(),
                    StartDate = dr["I_StartDate"].ToString(),
                    EndDate = dr["I_EndDate"].ToString()
                };
                informationList.Add(informationModel);
            }
            return View(informationList);
        }

        public IActionResult EditInformation(int id = 0)
        {

            ViewBag.Listoflanguage = Planguage();
            ViewBag.Listofcontent = contentType();
            InformationModel obj = new InformationModel();
            DataTable dt = cmn.GetDatatable("exec PRC_Information @qtype=3, " +
                            "@id='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                obj.id = int.Parse(dt.Rows[0]["I_sno"].ToString());
                obj.langId = int.Parse(dt.Rows[0]["I_Language"].ToString());
                obj.langName = dt.Rows[0]["I_Language"].ToString();
                obj.contentId = int.Parse(dt.Rows[0]["I_Content"].ToString());
                obj.contentName = dt.Rows[0]["I_Content"].ToString();
                obj.title = dt.Rows[0]["I_Title"].ToString();
                obj.description = dt.Rows[0]["I_PageDescription"].ToString();
                obj.ImagePath = dt.Rows[0]["I_FileUpload"].ToString();
                obj.link = dt.Rows[0]["I_LinkURL"].ToString();
                if (!String.IsNullOrEmpty(dt.Rows[0]["I_StartDate"].ToString()))
                {
                    obj.StartDate_Display = Convert.ToDateTime(dt.Rows[0]["I_StartDate"].ToString());
                }
                if (!String.IsNullOrEmpty(dt.Rows[0]["I_EndDate"].ToString()))
                {
                    obj.EndDate_Display = Convert.ToDateTime(dt.Rows[0]["I_EndDate"].ToString());
                }
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult UpdateInformation(InformationModel informationModel, IFormFile file)
        {
            var filePath = "";
            var filename = "";
            if (informationModel.InfoImg != null)
            {
                var uniqueFileName = GetUniqueFileName(informationModel.InfoImg.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "InfoImage");
                filePath = Path.Combine(uploads, uniqueFileName);
                informationModel.InfoImg.CopyTo(new FileStream(filePath, FileMode.Create));
                filename = "/InfoImage/" + uniqueFileName;
            }
            informationModel.ImagePath = filename == "" ? informationModel.ImagePath : filename;
            informationModel.StartDate = String.Format("{0:MM-dd-yyyy}", informationModel.StartDate_Display == null ? "" : informationModel.StartDate_Display.Value);
            informationModel.EndDate = String.Format("{0:MM-dd-yyyy}", informationModel.EndDate_Display == null ? "" : informationModel.EndDate_Display.Value);
            string ret = cmn.AddDelMod("exec PRC_Information @qtype=4," +
                                "@language='" + informationModel.langId + "'," +
                                "@content='" + informationModel.contentId + "'," +
                                "@title='" + informationModel.title + "'," +
                                "@description=N'" + informationModel.description + "'," +
                                "@fileupload='" + informationModel.ImagePath + "'," +
                                "@linkurl='" + informationModel.link + "'," +
                                "@start='" + informationModel.StartDate + "'," +
                                "@end='" + informationModel.EndDate + "'");

            if (ret == "4")
            {
                return RedirectToAction("InformationList");
            }
            else
            {
                ViewBag.Error = "Some Error Occurred";
                return View();
            }
        }

        public IActionResult DeleteInformation(int id)
        {
            string ret = cmn.AddDelMod("exec PRC_Information @qtype='5'," +
                            "@id='" + id + "'");

            if (ret == "5")
            {
                return RedirectToAction("InformationList");
            }
            else
            {
                return View();
            }
        }
    }
}
