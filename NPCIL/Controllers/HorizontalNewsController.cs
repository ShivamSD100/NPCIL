using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPCIL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using WebApplication1.Models;

namespace NPCIL.Controllers
{
    [CheckSession]
    public class HorizontalNewsController : Controller
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public HorizontalNewsController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddHorizontalNews()
        {
            ViewBag.ListofLanguage = HN_Language();
            ViewBag.ListofContentType = HN_ContentType();
            return View();
        }

        public List<HorizontalNewsModel> HN_Language()
        {
            List<HorizontalNewsModel> HNLanguageList = new List<HorizontalNewsModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_Language");
            foreach (DataRow dr in dt.Rows)
            {
                HorizontalNewsModel horizontalNewsModel = new HorizontalNewsModel()
                {
                    HN_LangId = int.Parse(dr["lang_sno"].ToString()),
                    HN_LangName = dr["lang_name"].ToString()
                };
                HNLanguageList.Add(horizontalNewsModel);
            }
            HNLanguageList.Insert(0, new HorizontalNewsModel { HN_LangId = 0, HN_LangName = "Select" });
            ViewBag.ListofLanguage = HNLanguageList;
            return HNLanguageList;
        }

        public List<HorizontalNewsModel> HN_ContentType()
        {
            List<HorizontalNewsModel> HMContentList = new List<HorizontalNewsModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_Content");
            foreach (DataRow dr in dt.Rows)
            {
                HorizontalNewsModel horizontalNewsModel = new HorizontalNewsModel()
                {
                    HN_ContentId = int.Parse(dr["con_sno"].ToString()),
                    HN_ContentName = dr["con_name"].ToString()
                };
                HMContentList.Add(horizontalNewsModel);
            }
            HMContentList.Insert(0, new HorizontalNewsModel { HN_ContentId = 0, HN_ContentName = "Select" });
            ViewBag.ListofContentType = HMContentList;
            return HMContentList;
        }

        [HttpPost]
        public IActionResult AddHorizontalNews(HorizontalNewsModel horizontalNewsModel)
        {
            horizontalNewsModel.HN_StartDate = horizontalNewsModel.HN_StartDate_Display.ToString("MM/dd/yyyy");
            horizontalNewsModel.HN_EndDate = horizontalNewsModel.HN_EndDate_Display.ToString("MM/dd/yyyy");
            string ret = cmn.AddDelMod("exec PRC_AddHorizontalNews @qtype='1'," +
                "@HN_Lang='" + horizontalNewsModel.HN_LangId + "'," +
                "@HN_Content='" + horizontalNewsModel.HN_ContentId + "'," +
                "@HN_Title='" + horizontalNewsModel.HN_Title + "'," +
                "@HN_Description='" + horizontalNewsModel.HN_Description + "'," +
                "@HN_StartDate='" + horizontalNewsModel.HN_StartDate + "'," +
                "@HN_EndDate='" + horizontalNewsModel.HN_EndDate + "'");
            if (ret == "1")
            {
                return RedirectToAction("HorizontalNewsList");
            }
            else
            {
                return View();
            }
        }

        public IActionResult HorizontalNewsList()
        {
            List<HorizontalNewsModel> horizontalList = new List<HorizontalNewsModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_AddHorizontalNews @qtype=2");
            foreach (DataRow dr in dt.Rows)
            {
                HorizontalNewsModel horizontalNewsModel = new HorizontalNewsModel()
                {
                    HN_id = int.Parse(dr["HN_Sno"].ToString()),
                    HN_LangName = dr["langua"].ToString(),
                    HN_ContentName = dr["content"].ToString(),
                    HN_Title = dr["HN_Title"].ToString(),
                    HN_Description = dr["HN_Description"].ToString(),
                    HN_StartDate = dr["startdate"].ToString(),
                    HN_EndDate = dr["enddate"].ToString()
                };
                horizontalList.Add(horizontalNewsModel);
            }
            return View(horizontalList);
        }

        public IActionResult DeleteHorizontalNews(int id)
        {
            string ret = cmn.AddDelMod("exec PRC_AddHorizontalNews @qtype='5'," +
                            "@hn_sno='" + id + "'");
            if (ret == "5")
            {
                return RedirectToAction("HorizontalNewsList");
            }
            else
            {
                return View();
            }
        }

        public IActionResult EditHorizontalNews(int id = 0)
        {
            ViewBag.ListofLanguage = HN_Language();
            ViewBag.ListofContentType = HN_ContentType();
            ViewBag.abc = "Submit";
            HorizontalNewsModel obj = new HorizontalNewsModel();
            DataTable dt = cmn.GetDatatable("exec PRC_AddHorizontalNews @qtype='3', " +
                            "@hn_sno='" + id + "'");
            if (dt.Rows.Count > 0)
            {
                obj.HN_id = int.Parse(dt.Rows[0]["HN_Sno"].ToString());
                obj.HN_LangId = int.Parse(dt.Rows[0]["HN_Lang"].ToString());
                obj.HN_ContentId = int.Parse(dt.Rows[0]["HN_Content"].ToString());
                obj.HN_Title = dt.Rows[0]["HN_Title"].ToString();
                obj.HN_Description = dt.Rows[0]["HN_Description"].ToString();
                obj.HN_StartDate_Display = Convert.ToDateTime(dt.Rows[0]["HN_StartDate"].ToString());
                obj.HN_EndDate_Display = Convert.ToDateTime(dt.Rows[0]["HN_EndDate"].ToString());
                ViewBag.abc = "Update";
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult UpdateHorizontalNews(HorizontalNewsModel horizontalNewsModel)
        {
            horizontalNewsModel.HN_StartDate = horizontalNewsModel.HN_StartDate_Display.ToString("MM/dd/yyyy");
            horizontalNewsModel.HN_EndDate = horizontalNewsModel.HN_EndDate_Display.ToString("MM/dd/yyyy");
            string ret = cmn.AddDelMod("exec PRC_AddHorizontalNews @qtype='4'," +
                "@hn_sno='" + horizontalNewsModel.HN_id + "'," +
                 "@HN_Lang='" + horizontalNewsModel.HN_LangId + "'," +
                "@HN_Content='" + horizontalNewsModel.HN_ContentId + "'," +
                "@HN_Title='" + horizontalNewsModel.HN_Title + "'," +
                "@HN_Description='" + horizontalNewsModel.HN_Description + "'," +
                "@HN_StartDate='" + horizontalNewsModel.HN_StartDate + "'," +
                "@HN_EndDate='" + horizontalNewsModel.HN_EndDate + "'");
            if (ret == "4") 
            {
                return RedirectToAction("HorizontalNewsList");
            }
            else
            {
                return RedirectToAction("HorizontalNewsList");
            }
        }
    }
}
