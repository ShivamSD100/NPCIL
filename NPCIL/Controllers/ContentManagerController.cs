using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPCIL.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [CheckSession]
    public class ContentManagerController : Controller
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public ContentManagerController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddContent(int id = 0)
        {
            ViewBag.ListofPosition = CM_MenuPosition();
            ViewBag.ListofType = CM_MenuType();
            ViewBag.abc = "Submit";
            ContentManagerModel obj = new ContentManagerModel();
            DataTable dt = cmn.GetDatatable("exec [PRC_Update_ContentManager] @qtype='1', " +
                            "@Menu_Id='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                obj.CM_Id = int.Parse(dt.Rows[0]["CM_Sno"].ToString());
                obj.Menu_Id = int.Parse(dt.Rows[0]["Menu_Id"].ToString());
                obj.CM_Name_eng = dt.Rows[0]["CM_name_eng"].ToString();
                obj.CM_Name_hind = dt.Rows[0]["CM_name_hind"].ToString();
                obj.ImagePath = dt.Rows[0]["newImg"].ToString().Replace("C:\\Users\\jabit\\source\\repos\\WebApplication1\\WebApplication1\\wwwroot", "");
                obj.CM_MenuPositionId = int.Parse(dt.Rows[0]["CM_position"].ToString());
                obj.CM_MenuPosition_Name = dt.Rows[0]["CM_position"].ToString();
                obj.CM_MenuTypeId = int.Parse(dt.Rows[0]["CM_type"].ToString());
                obj.CM_MenuType_Name = dt.Rows[0]["CM_type"].ToString();
                obj.CM_PageContent_eng = dt.Rows[0]["CM_PageContent_eng"].ToString();
                obj.CM_PageContent_hind = dt.Rows[0]["CM_PageContent_hind"].ToString();
                //obj.CM_StartDate_Display = Convert.ToDateTime(dt.Rows[0]["startdate"].ToString());
                obj.CM_EndDate_Display = Convert.ToDateTime(dt.Rows[0]["enddate"].ToString());
                obj.CM_Desc_eng = dt.Rows[0]["CM_shortDescEng"].ToString();
                obj.CM_Desc_hind = dt.Rows[0]["CM_shortDescHind"].ToString();
                ViewBag.abc = "Update";
            }
            else
            {
                obj.CM_Id = 0;
                obj.Menu_Id = id;
                obj.CM_Name_eng = "";
                obj.CM_Name_hind = "";
                obj.ImagePath = "";
                obj.CM_MenuPositionId = 0;
                obj.CM_MenuPosition_Name = "";
                obj.CM_MenuTypeId = 0;
                obj.CM_MenuType_Name = "";
                obj.CM_PageContent_eng = "";
                obj.CM_PageContent_hind = "";
                obj.CM_StartDate = "";
                obj.CM_EndDate = "";
                obj.CM_Desc_eng = "";
                obj.CM_Desc_hind = "";
            }
            //ModelState.Clear();
            return View(obj);
        }


            public List<ContentManagerModel> CM_MenuPosition()
        {
            List<ContentManagerModel> CMPositionList = new List<ContentManagerModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_MenuPosition");
            foreach(DataRow dr in dt.Rows)
            {
                ContentManagerModel contentManagerModel = new ContentManagerModel()
                {
                    CM_MenuPositionId = int.Parse(dr["mp_sno"].ToString()),
                    CM_MenuPosition_Name = dr["mp_name"].ToString()
                };
                CMPositionList.Add(contentManagerModel);
            }
            CMPositionList.Insert(0, new ContentManagerModel { CM_MenuPositionId = 0, CM_MenuPosition_Name = "Select" });
            ViewBag.ListofPosition = CMPositionList;
            return CMPositionList;
        }

        public List<ContentManagerModel> CM_MenuType()
        {
            List<ContentManagerModel> CMTypeList = new List<ContentManagerModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_MenuType");
            foreach(DataRow dr in dt.Rows)
            {
                ContentManagerModel contentManagerModel = new ContentManagerModel()
                {
                    CM_MenuTypeId = int.Parse(dr["mt_sno"].ToString()),
                    CM_MenuType_Name = dr["mt_name"].ToString()
                };
                CMTypeList.Add(contentManagerModel);
            }
            CMTypeList.Insert(0, new ContentManagerModel { CM_MenuTypeId = 0, CM_MenuType_Name = "Select" });
            ViewBag.ListofType = CMTypeList;
            return CMTypeList;
        }

        [HttpPost]
        public IActionResult AddContent(ContentManagerModel contentManagerModel, IFormFile file)
        {
            var filePath = "";
            if (contentManagerModel.CM_Img != null)
            {
                var uniqueFileName = GetUniqueFileName(contentManagerModel.CM_Img.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "ContentManagerImage");
                filePath = Path.Combine(uploads, uniqueFileName);
                contentManagerModel.CM_Img.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            contentManagerModel.CM_StartDate = contentManagerModel.CM_StartDate_Display.ToString("MM/dd/yyyy");
            contentManagerModel.CM_EndDate = contentManagerModel.CM_EndDate_Display.ToString("MM/dd/yyyy");

            string ret = cmn.AddDelMod("exec PRC_Add_Update_ContentManager @qtype='1'," +
                "@Menu_Id='" + contentManagerModel.Menu_Id + "'," +
                "@CM_name_eng='" + contentManagerModel.CM_Name_eng + "'," +
                "@CM_name_hind='" + contentManagerModel.CM_Name_hind + "'," +
                "@CM_image='" + filePath + "'," +
                "@CM_position='" + contentManagerModel.CM_MenuPositionId + "'," +
                "@CM_type='" + contentManagerModel.CM_MenuTypeId + "'," +
                "@CM_PageContent_eng='" + contentManagerModel.CM_PageContent_eng + "'," +
                "@CM_PageContent_hind='" + contentManagerModel.CM_PageContent_hind + "'," +
                "@CM_startdate='" + contentManagerModel.CM_StartDate + "'," +
                "@CM_enddate='" + contentManagerModel.CM_EndDate + "'," +
                "@CM_shortDescEng='" + contentManagerModel.CM_Desc_eng + "'," +
                "@CM_shortDescHind='" + contentManagerModel.CM_Desc_hind + "'");
            if (ret == "1")
            {
                //ModelState.Clear();
                return RedirectToAction("MenusList","Menu");
            }
            else
            {
                //ModelState.Clear();
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
    }
}
