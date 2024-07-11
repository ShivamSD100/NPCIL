using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPCIL.Models;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace NPCIL.Controllers
{
    [CheckSession]
    public class MenuController : Controller
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public MenuController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CMSMenuAdd(int? id=0)
        {

            MenuModel model = new MenuModel()
            {
                MenuOptions = new List<SelectListItem>()
            };
            DataTable dtMenuOptions = cmn.GetDatatable("exec PRC_AddMenu @qtype=6");
            model.MenuOptions.Add(new SelectListItem() { Value = "0", Text = "" });
            foreach (DataRow dr1 in dtMenuOptions.Rows)
            {
                model.MenuOptions.Add(new SelectListItem() { Value = dr1["menu_sno"].ToString(), Text = dr1["menu_name_eng"].ToString() });
            }

            model.ParentId = id > 0 ? id.ToString() : "";

            ViewBag.ListofPosition = CMSMenuPosition();
            ViewBag.ListofType = CMSMenuType();
            ViewBag.ListofLink = LinkType();
            return View(model);
        }
        public List<MenuModel> CMSMenuPosition()
        {
            List<MenuModel> MenuPositionList = new List<MenuModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_MenuPosition");
            foreach (DataRow dr in dt.Rows)
            {
                MenuModel menuModel = new MenuModel()
                {
                    MenuPositionId = int.Parse(dr["mp_sno"].ToString()),
                    MenuPosition_Name = dr["mp_name"].ToString()
                };
                MenuPositionList.Add(menuModel);
            }
            MenuPositionList.Insert(0, new MenuModel { MenuPositionId = 0, MenuPosition_Name = "Select" });
            ViewBag.ListofPosition = MenuPositionList;
            return MenuPositionList;
        }

        public List<MenuModel> CMSMenuType()
        {
            List<MenuModel> MenuTypeList = new List<MenuModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_MenuType");
            foreach (DataRow dr in dt.Rows)
            {
                MenuModel menuModel = new MenuModel()
                {
                    MenuTypeId = int.Parse(dr["mt_sno"].ToString()),
                    MenuType_Name = dr["mt_name"].ToString()
                };
                MenuTypeList.Add(menuModel);
            }
            MenuTypeList.Insert(0, new MenuModel { MenuTypeId = 0, MenuType_Name = "Select" });
            ViewBag.ListofType = MenuTypeList;
            return MenuTypeList;
        }

        public List<MenuModel> LinkType()
        {
            List<MenuModel> linkTypeList = new List<MenuModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_linkList");
            foreach (DataRow dr in dt.Rows)
            {
                MenuModel menuModel = new MenuModel()
                {
                    linkTypeId = int.Parse(dr["link_id"].ToString()),
                    LinkTypeName = dr["link_name"].ToString()
                };
                linkTypeList.Add(menuModel);
            }
            linkTypeList.Insert(0, new MenuModel { linkTypeId = 0, LinkTypeName = "Select" });
            ViewBag.ListofLink = linkTypeList;
            return linkTypeList;
        }

        public List<MenuModel> CMSMenu()
        {
            List<MenuModel> MenuList = new List<MenuModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_MenuList");
            foreach (DataRow dr in dt.Rows)
            {
                MenuModel menuModel = new MenuModel()
                {
                    MenuListId = int.Parse(dr["Menu_sno"].ToString()),
                    MenuList_Name = dr["Menu_Name_eng"].ToString()
                };
                MenuList.Add(menuModel);
            }
            MenuList.Insert(0, new MenuModel { MenuListId = 0, MenuList_Name = "Select" });

            return MenuList;
        }

        [HttpPost]
        public IActionResult CMSMenuAdd(MenuModel menuModel, IFormFile file)
        {
            var filePath = "";
            var filename = "";
            var filename2 = "";
            if (menuModel.MenuImg != null)
            {
                var uniqueFileName = GetUniqueFileName(menuModel.MenuImg.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "MenuImages");
                filePath = Path.Combine(uploads, uniqueFileName);
                menuModel.MenuImg.CopyTo(new FileStream(filePath, FileMode.Create));
                filename = "/MenuImages/" + uniqueFileName;
            }

            if ((menuModel.MenuTypeId == 2 || menuModel.MenuTypeId == 7) && menuModel.file_MenuImg != null)
            {
                var uniqueFileName = GetUniqueFileName(menuModel.file_MenuImg.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "MenuImages");
                filePath = Path.Combine(uploads, uniqueFileName);
                menuModel.file_MenuImg.CopyTo(new FileStream(filePath, FileMode.Create));
                filename2 = "/MenuImages/" + uniqueFileName;
            }
            menuModel.file_StartDate = menuModel.file_StartDate_Display == null ? "": menuModel.file_StartDate_Display.Value.ToString();
            menuModel.file_EndDate =  menuModel.file_EndDate_Display == null ? "" : menuModel.file_EndDate_Display.Value.ToString();
            //var parentId = String.IsNullOrEmpty(ViewData["ParentId"].ToString()) ? "" : ViewData["ParentId"];
            string ret = cmn.AddDelMod("exec PRC_AddMenu @qtype='1'," +
                "@nameEng='" + menuModel.MenuName_eng + "'," +
                "@nameHindi='" + menuModel.MenuName_hind + "'," +
                "@img='" + filename + "'," +
                "@position='" + menuModel.MenuPositionId + "'," +
                "@menutype='" + menuModel.MenuTypeId + "'," +
                "@descEng='" + menuModel.MenuDesc_eng + "'," +
                "@descHindi='" + menuModel.MenuDesc_hind + "'," +
                "@content_eng='" + menuModel.Content_MenuName_eng + "'," +
                "@Content_hind='" + menuModel.Content_MenuName_hindi + "'," +
                "@file_image='" + filename2 + "'," +
                "@file_Startdate='" + menuModel.file_StartDate + "'," +
                "@file_Enddate='" + menuModel.file_EndDate + "'," +
                "@link_urlname='" + menuModel.link_urlname + "'," +
                "@linkType='" + menuModel.linkTypeId + "'," +
                "@eventyear='" + menuModel.event_year + "'," +
                "@tabActive='" + menuModel.tabActive + "'," +
                "@parentid='" + menuModel.ParentId + "'");

            if (ret == "1")
            {
                return RedirectToAction("MenusList");
            }
            else
            {
                ViewBag.ListofPosition = CMSMenuPosition();
                ViewBag.ListofType = CMSMenuType();
                ViewBag.ListofLink = LinkType();
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

        public IActionResult MenusList(int? id = 0)
        {

            List<MenuModel> menuList = new List<MenuModel>();
            DataTable dt = new DataTable();
            DataTable dtMenuOptions  = cmn.GetDatatable("exec PRC_AddMenu @qtype=6");

            if (id == 0)
            {
                dt = cmn.GetDatatable("exec PRC_AddMenu @qtype=2");
            }
            else if (id > 0)
            {
                ViewData["ParentId"] = id;
                dt = cmn.GetDatatable("exec PRC_AddMenu @qtype=5 , @parentid='" + id + "'");
            }
            foreach (DataRow dr in dt.Rows)
            {
                MenuModel menuModel = new MenuModel()
                {
                    MenuId = int.Parse(dr["menu_sno"].ToString()),
                    MenuName_eng = dr["menu_name_eng"].ToString(),
                    MenuName_hind = dr["menu_name_hind"].ToString(),
                    MenuPosition_Name = dr["position"].ToString(),
                    MenuType_Name = dr["mtype"].ToString(),
                    ImagePath = dr["newImg"].ToString(),
                    ParentId = dr["ParentId"].ToString(),
                    tabActive = dr["tab_Active"].ToString(),
                    MenuOptions = new List<SelectListItem>()

                };

                menuModel.MenuOptions.Add(new SelectListItem() { Value = "0", Text = "" });
                foreach (DataRow dr1 in dtMenuOptions.Rows)
                {
                    menuModel.MenuOptions.Add(new SelectListItem (){ Value = dr1["menu_sno"].ToString(), Text = dr1["menu_name_eng"].ToString() });
                }

                menuList.Add(menuModel);
            };

                
            

            ViewBag.ListofLink = LinkType();
            ViewBag.ListofMenu = CMSMenu();
            return View(menuList);
        }

        public IActionResult EditMenu(int id = 0)
        {
            ViewBag.ListofPosition = CMSMenuPosition();
            ViewBag.ListofType = CMSMenuType();
            ViewBag.ListofLink = LinkType();
            ViewBag.abc = "Submit";
            MenuModel obj = new MenuModel()
            {
                MenuOptions = new List<SelectListItem>()
            };
            DataTable dtMenuOptions = cmn.GetDatatable("exec PRC_AddMenu @qtype=6");
            obj.MenuOptions.Add(new SelectListItem() { Value = "0", Text = "" });
            foreach (DataRow dr1 in dtMenuOptions.Rows)
            {
                obj.MenuOptions.Add(new SelectListItem() { Value = dr1["menu_sno"].ToString(), Text = dr1["menu_name_eng"].ToString() });
            }

            DataTable dt = cmn.GetDatatable("exec PRC_AddMenu @qtype='3', " +
                            "@sno='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                obj.MenuId = int.Parse(dt.Rows[0]["menu_sno"].ToString());
                obj.MenuName_eng = dt.Rows[0]["menu_name_eng"].ToString();
                obj.MenuName_hind = dt.Rows[0]["menu_name_hind"].ToString();
                obj.ImagePath = dt.Rows[0]["newImg"].ToString();
                obj.MenuPositionId = int.Parse(dt.Rows[0]["menu_position"].ToString());
                obj.MenuPosition_Name = dt.Rows[0]["menu_position"].ToString();
                obj.MenuTypeId = int.Parse(dt.Rows[0]["menu_type"].ToString());
                obj.MenuType_Name = dt.Rows[0]["menu_type"].ToString();
                obj.MenuDesc_eng = dt.Rows[0]["menu_desc_eng"].ToString();
                obj.MenuDesc_hind = dt.Rows[0]["menu_desc_hind"].ToString();
                obj.Content_MenuName_eng = dt.Rows[0]["content_eng"].ToString();
                obj.Content_MenuName_hindi = dt.Rows[0]["Content_hind"].ToString();
                obj.Imagepath2 = dt.Rows[0]["file_image"].ToString();

                if (!String.IsNullOrEmpty(dt.Rows[0]["file_Startdate"].ToString()))
                {
                    obj.file_StartDate_Display = Convert.ToDateTime(dt.Rows[0]["file_Startdate"].ToString());
                }
                if (!String.IsNullOrEmpty(dt.Rows[0]["file_Enddate"].ToString()))
                {
                    obj.file_EndDate_Display = Convert.ToDateTime(dt.Rows[0]["file_Enddate"].ToString());
                }

                obj.link_urlname = dt.Rows[0]["link_urlname"].ToString();
                obj.linkTypeId = int.Parse(dt.Rows[0]["linkType"].ToString());
                obj.event_year = dt.Rows[0]["eventyear"].ToString();

                obj.tabActive = dt.Rows[0]["tab_active"].ToString();
                obj.ParentId = dt.Rows[0]["ParentId"].ToString();
                obj.TabActiveOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Yes" },
                new SelectListItem { Value = "0", Text = "No" }
            };


                ViewBag.abc = "Update";
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult UpdateMenu(MenuModel menuModel)
        {
            var filePath = "";
            var filename = "";
            var filename2 = "";
            if (menuModel.MenuImg != null)
            {
                var uniqueFileName = GetUniqueFileName(menuModel.MenuImg.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "MenuImages");
                filePath = Path.Combine(uploads, uniqueFileName);
                menuModel.MenuImg.CopyTo(new FileStream(filePath, FileMode.Create));
                filename = "/MenuImages/" + uniqueFileName;
            }

            if ((menuModel.MenuTypeId == 2 || menuModel.MenuTypeId == 7) && menuModel.file_MenuImg != null)
            {
                var uniqueFileName = GetUniqueFileName(menuModel.file_MenuImg.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "MenuImages");
                filePath = Path.Combine(uploads, uniqueFileName);
                menuModel.file_MenuImg.CopyTo(new FileStream(filePath, FileMode.Create));
                filename2 = "/MenuImages/" + uniqueFileName;
            }

            if (filePath == "")
                filePath = menuModel.ImagePath;
            menuModel.file_StartDate = menuModel.file_StartDate_Display == null ? "" : menuModel.file_StartDate_Display.Value.ToString();
            menuModel.file_EndDate = menuModel.file_EndDate_Display == null ? "" : menuModel.file_EndDate_Display.Value.ToString();

            string ret = cmn.AddDelMod("exec PRC_AddMenu @qtype='4'," +
                "@sno='" + menuModel.MenuId + "'," +
                "@nameEng='" + menuModel.MenuName_eng + "'," +
                "@nameHindi='" + menuModel.MenuName_hind + "'," +
                "@img='" + filename + "'," +
                "@position='" + menuModel.MenuPositionId + "'," +
                "@menutype='" + menuModel.MenuTypeId + "'," +
                "@descEng='" + menuModel.MenuDesc_eng + "'," +
                "@descHindi='" + menuModel.MenuDesc_hind + "'," +
                "@content_eng='" + menuModel.Content_MenuName_eng + "'," +
               "@Content_hind='" + menuModel.Content_MenuName_hindi + "'," +
               "@file_image='" + filename2 + "'," +
               "@file_Startdate='" + menuModel.file_StartDate + "'," +
               "@file_Enddate='" + menuModel.file_EndDate + "'," +
               "@link_urlname='" + menuModel.link_urlname + "'," +
               "@linkType='" + menuModel.linkTypeId + "'," +
               "@tabActive='" + menuModel.tabActive+ "',"+
               "@parentid='" + menuModel.ParentId + "',"+
               "@eventyear='" + menuModel.event_year + "'");
            if (ret == "4")
            {
                return RedirectToAction("MenusList");
            }
            else
            {
                return View();
            }
        }
    }
}

