using Microsoft.AspNetCore.Mvc;
using NPCIL.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace NPCIL.Controllers
{
    public class VerticalNewsController : Controller
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public VerticalNewsController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddVerticalNews()
        {
            ViewBag.ListofLanguage = VN_Language();
            ViewBag.ListofContentType = VN_ContentType();
            return View();
        }

        public List<VerticalNewsModel> VN_Language()
        {
            List<VerticalNewsModel> VNLanguageList = new List<VerticalNewsModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_Language");
            foreach (DataRow dr in dt.Rows)
            {
                VerticalNewsModel verticalNewsModel = new VerticalNewsModel()
                {
                    VN_LangId = int.Parse(dr["lang_sno"].ToString()),
                    VN_LangName = dr["lang_name"].ToString()
                };
                VNLanguageList.Add(verticalNewsModel);
            }
            VNLanguageList.Insert(0, new VerticalNewsModel { VN_LangId = 0, VN_LangName = "Select" });
            ViewBag.ListofLanguage = VNLanguageList;
            return VNLanguageList;
        }

        public List<VerticalNewsModel> VN_ContentType()
        {
            List<VerticalNewsModel> VNContentList = new List<VerticalNewsModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_Content");
            foreach (DataRow dr in dt.Rows)
            {
                VerticalNewsModel verticalNewsModel = new VerticalNewsModel()
                {
                    VN_ContentId = int.Parse(dr["con_sno"].ToString()),
                    VN_ContentName = dr["con_name"].ToString()
                };
                VNContentList.Add(verticalNewsModel);
            }
            VNContentList.Insert(0, new VerticalNewsModel { VN_ContentId = 0, VN_ContentName = "Select" });
            ViewBag.ListofContentType = VNContentList;
            return VNContentList;
        }

        [HttpPost]
        public IActionResult AddVerticalNews(VerticalNewsModel verticalNewsModel)
        {
            verticalNewsModel.VN_StartDate = verticalNewsModel.VN_StartDate_Display.ToString("MM/dd/yyyy");
            verticalNewsModel.VN_EndDate = verticalNewsModel.VN_EndDate_Display.ToString("MM/dd/yyyy");
            string ret = cmn.AddDelMod("exec PRC_AddVerticalNews @qtype='1'," +
                "@VN_Lang='" + verticalNewsModel.VN_LangId + "'," +
                "@VN_Content='" + verticalNewsModel.VN_ContentId + "'," +
                "@VN_Title='" + verticalNewsModel.VN_Title + "'," +
                "@VN_Description='" + verticalNewsModel.VN_Description + "'," +
                "@VN_StartDate='" + verticalNewsModel.VN_StartDate + "'," +
                "@VN_EndDate='" + verticalNewsModel.VN_EndDate + "'");
            if (ret == "1")
            {
                return RedirectToAction("VerticalNewsList");
            }
            else
            {
                return View();
            }
        }

        public IActionResult VerticalNewsList()
        {
            List<VerticalNewsModel> verticalList = new List<VerticalNewsModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_AddVerticalNews @qtype=2");
            foreach (DataRow dr in dt.Rows)
            {
                VerticalNewsModel verticalNewsModel = new VerticalNewsModel()
                {
                    VN_id = int.Parse(dr["VN_Sno"].ToString()),
                    VN_LangName = dr["langua"].ToString(),
                    VN_ContentName = dr["content"].ToString(),
                    VN_Title = dr["VN_Title"].ToString(),
                    VN_Description = dr["VN_Description"].ToString(),
                    VN_StartDate = dr["startdate"].ToString(),
                    VN_EndDate = dr["enddate"].ToString()
                };
                verticalList.Add(verticalNewsModel);
            }
            return View(verticalList);
        }

        public IActionResult DeleteVerticalNews(int id)
        {
            string ret = cmn.AddDelMod("exec PRC_AddVerticalNews @qtype='5'," +
                            "@VN_sno='" + id + "'");
            if (ret == "5")
            {
                return RedirectToAction("VerticalNewsList");
            }
            else
            {
                return View();
            }
        }

        public IActionResult EditVerticalNews(int id = 0)
        {
            ViewBag.ListofLanguage = VN_Language();
            ViewBag.ListofContentType = VN_ContentType();
            ViewBag.abc = "Submit";
            VerticalNewsModel obj = new VerticalNewsModel();
            DataTable dt = cmn.GetDatatable("exec PRC_AddVerticalNews @qtype='3', " +
                            "@VN_sno='" + id + "'");
            if (dt.Rows.Count > 0)
            {
                obj.VN_id = int.Parse(dt.Rows[0]["VN_Sno"].ToString());
                obj.VN_LangId = int.Parse(dt.Rows[0]["VN_Lang"].ToString());
                obj.VN_ContentId = int.Parse(dt.Rows[0]["VN_Content"].ToString());
                obj.VN_Title = dt.Rows[0]["VN_Title"].ToString();
                obj.VN_Description = dt.Rows[0]["VN_Description"].ToString();
                obj.VN_StartDate_Display = Convert.ToDateTime(dt.Rows[0]["VN_StartDate"].ToString());
                obj.VN_EndDate_Display = Convert.ToDateTime(dt.Rows[0]["VN_EndDate"].ToString());
                ViewBag.abc = "Update";
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult UpdateVerticalNews(VerticalNewsModel verticalNewsModel)
        {
            verticalNewsModel.VN_StartDate = verticalNewsModel.VN_StartDate_Display.ToString("MM/dd/yyyy");
            verticalNewsModel.VN_EndDate = verticalNewsModel.VN_EndDate_Display.ToString("MM/dd/yyyy");
            string ret = cmn.AddDelMod("exec PRC_AddVerticalNews @qtype='4'," +
                "@VN_sno='" + verticalNewsModel.VN_id + "'," +
                 "@VN_Lang='" + verticalNewsModel.VN_LangId + "'," +
                "@VN_Content='" + verticalNewsModel.VN_ContentId + "'," +
                "@VN_Title='" + verticalNewsModel.VN_Title + "'," +
                "@VN_Description='" + verticalNewsModel.VN_Description + "'," +
                "@VN_StartDate='" + verticalNewsModel.VN_StartDate + "'," +
                "@VN_EndDate='" + verticalNewsModel.VN_EndDate + "'");
            if (ret == "4") 
            {
                return RedirectToAction("VerticalNewsList");
            }
            else
            {
                return RedirectToAction("VerticalNewsList");
            }
        }
    }
}
