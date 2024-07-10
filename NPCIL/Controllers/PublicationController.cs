using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPCIL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using WebApplication1.Models;

namespace NPCIL.Controllers
{
    public class PublicationController : Controller
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public PublicationController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPublication()
        {
            ViewBag.ListofLanguage = Pub_LanguageList();
            ViewBag.ListofPublicationType = Pub_PublicationTypeList();
            return View();
        }

        public List<PublicationModel> Pub_LanguageList()
        {
            List<PublicationModel> PubLanguageList = new List<PublicationModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_Language");
            foreach (DataRow dr in dt.Rows)
            {
                PublicationModel publicationModel = new PublicationModel()
                {
                    PUB_LangId = int.Parse(dr["lang_sno"].ToString()),
                    PUB_LangName = dr["lang_name"].ToString()
                };
                PubLanguageList.Add(publicationModel);
            }
            PubLanguageList.Insert(0, new PublicationModel { PUB_LangId = 0, PUB_LangName = "Select" });
            ViewBag.ListofLanguage = PubLanguageList;
            return PubLanguageList;
        }

        public List<PublicationModel> Pub_PublicationTypeList()
        {
            List<PublicationModel> publicationTypeList = new List<PublicationModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_PublicationType");
            foreach (DataRow dr in dt.Rows)
            {
                PublicationModel publicationModel = new PublicationModel()
                {
                    PUB_PubTypeId = int.Parse(dr["pt_sno"].ToString()),
                    PUB_PubTypeName = dr["pt_name"].ToString()
                };
                publicationTypeList.Add(publicationModel);
            }
            publicationTypeList.Insert(0, new PublicationModel { PUB_PubTypeId = 0, PUB_PubTypeName = "Select" });
            ViewBag.ListofPublicationType = publicationTypeList;
            return publicationTypeList;
        }

        [HttpPost]
        public IActionResult AddPublication(PublicationModel publicationModel, IFormFile file)
        {
            var filePath = "";
            var filename = "";
            if (publicationModel.PUB_FileUpload != null)
            {
                var uniqueFileName = GetUniqueFileName(publicationModel.PUB_FileUpload.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "PublicationPDF");
                filePath = Path.Combine(uploads, uniqueFileName);
                publicationModel.PUB_FileUpload.CopyTo(new FileStream(filePath, FileMode.Create));
                filename = "/PublicationPDF/" + uniqueFileName;
            }
            string ret = cmn.AddDelMod("exec PRC_AddPublication @qtype='1'," +
                "@Pub_Language='" + publicationModel.PUB_LangId + "'," +
                "@Pub_Type='" + publicationModel.PUB_PubTypeId + "'," +
                "@Pub_Title='" + publicationModel.PUB_Title + "'," +
                "@Pub_AuthorName='" + publicationModel.PUB_AutherName + "'," +
                "@Pub_FileUpload='" + filename + "'," +
                "@Pub_Others='" + publicationModel.PUB_Others + "'");
            if (ret == "1")
            {
                return RedirectToAction("PublicationList");
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

        public IActionResult PublicationList()
        {
            List<PublicationModel> pubList = new List<PublicationModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_AddPublication @qtype=4");
            foreach (DataRow dr in dt.Rows)
            {
                PublicationModel publicationModel = new PublicationModel()
                {
                    PUB_id = int.Parse(dr["Pub_id"].ToString()),
                    PUB_Title = dr["Pub_Title"].ToString(),
                    PUB_AutherName = dr["Pub_AuthorName"].ToString(),
                    ImagePath = dr["Pub_FileUpload"].ToString()
                };
                pubList.Add(publicationModel);
            }
            return View(pubList);
        }

        public IActionResult EditPublication(int id = 0)
        {
            ViewBag.ListofLanguage = Pub_LanguageList();
            ViewBag.ListofPublicationType = Pub_PublicationTypeList();
            PublicationModel obj = new PublicationModel();
            DataTable dt = cmn.GetDatatable("exec PRC_AddPublication @qtype='3', " +
                            "@Pub_id='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                obj.PUB_id = int.Parse(dt.Rows[0]["PUB_id"].ToString());
                obj.PUB_LangId = int.Parse(dt.Rows[0]["Pub_Language"].ToString());
                obj.PUB_LangName = dt.Rows[0]["Pub_Language"].ToString();
                obj.PUB_PubTypeId = int.Parse(dt.Rows[0]["Pub_Type"].ToString());
                obj.PUB_PubTypeName = dt.Rows[0]["Pub_Type"].ToString();
                obj.PUB_Title = dt.Rows[0]["Pub_Title"].ToString();
                obj.PUB_AutherName = dt.Rows[0]["Pub_AuthorName"].ToString();
                obj.ImagePath = dt.Rows[0]["Pub_FileUpload"].ToString();
                obj.PUB_Others = dt.Rows[0]["Pub_Others"].ToString();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult UpdatePublication(PublicationModel publicationModel)
        {
            var filePath = "";
            var filename = "";
            if (publicationModel.PUB_FileUpload != null)
            {
                var uniqueFileName = GetUniqueFileName(publicationModel.PUB_FileUpload.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "PublicationPDF");
                filePath = Path.Combine(uploads, uniqueFileName);
                publicationModel.PUB_FileUpload.CopyTo(new FileStream(filePath, FileMode.Create));
                filename = "/PublicationPDF/" + uniqueFileName;
            }

            if (filePath == "")
                filePath = publicationModel.ImagePath;

            string ret = cmn.AddDelMod("exec PRC_AddPublication @qtype='2'," +
                "@Pub_id='" + publicationModel.PUB_id + "'," +
                "@Pub_Language='" + publicationModel.PUB_LangId + "'," +
                "@Pub_Type='" + publicationModel.PUB_PubTypeId + "'," +
                "@Pub_Title='" + publicationModel.PUB_Title + "'," +
                "@Pub_AuthorName='" + publicationModel.PUB_AutherName + "'," +
                "@Pub_FileUpload='" + filename + "'," +
                "@Pub_Others='" + publicationModel.PUB_Others + "'");
            if (ret == "2")
            {
                return RedirectToAction("PublicationList");
            }
            else
            {
                return RedirectToAction("PublicationList"); ;
            }
        }

        public IActionResult DeletePublication(int id)
        {
            string ret = cmn.AddDelMod("exec PRC_AddPublication @qtype='5'," +
                            "@Pub_id='" + id + "'");
            if (ret == "5")
            {
                return RedirectToAction("PublicationList");
            }
            else
            {
                return View();
            }
        }
    }
}
