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
using NPCIL.Helper;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using NPCIL.DbModels;

namespace NPCIL.Controllers
{
    [CheckSession]
    public class MenuController : Controller
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;
        private readonly INPCILHelper _npcilHelper;
        private readonly IFileHelper _fileHelper;
        private readonly NPCIL_DBContext _dbcontext;
        private readonly IMapper _mapper;
        public MenuController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment,
            INPCILHelper npcilHelper,
            IFileHelper fileHelper, 
            NPCIL_DBContext dbContext, 
            IMapper mapper)
        {
            hostingEnvironment = environment;
            _npcilHelper = npcilHelper;
            _fileHelper = fileHelper;
            _dbcontext = dbContext;
            _mapper = mapper;
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

            List<MenuModel> ParentMenuOptions = _npcilHelper.GetMenus(Request);
            model.MenuOptions.Add(new SelectListItem() { Value = "0", Text = "Select" });
            foreach (var m in _dbcontext.TblAddMenu.ToList())
            {
                model.MenuOptions.Add(new SelectListItem() { Value =m.MenuSno.ToString(), Text = m.MenuNameEng.ToString() });
            }
            List<PageDataBind> datalistbind = _dbcontext.PageDataBinds.ToList();
            model.PageBindingOptions = new List<SelectListItem>();
            model.PageBindingOptions.Add(new SelectListItem() { Value = "0", Text = "" });

            foreach (PageDataBind db in datalistbind)
            {
                model.PageBindingOptions.Add(new SelectListItem() { Value = db.id.ToString(), Text = db.DataBindTag });
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
            ViewBag.ListofPosition = CMSMenuPosition();
            ViewBag.ListofType = CMSMenuType();
            ViewBag.ListofLink = LinkType();
            if (_npcilHelper.GetMenus(Request).Where(m => m.MenuName_eng == menuModel.MenuName_eng).Count() == 0)
            {
                if (menuModel.MenuImg != null)
                {
                    menuModel.ImagePath = _fileHelper.UploadAndGetFileName(menuModel.MenuImg, menuModel.file_MenuImg.FileName);
                }

                if ((menuModel.MenuTypeId == 2 || menuModel.MenuTypeId == 7) && menuModel.file_MenuImg != null)
                {
                    menuModel.Imagepath2 = _fileHelper.UploadAndGetFileName(menuModel.file_MenuImg, menuModel.file_MenuImg.FileName);
                }

                menuModel.file_StartDate = String.Format("{0:MM-dd-yyyy}", menuModel.file_StartDate_Display == null ? "" : menuModel.file_StartDate_Display.Value);
                menuModel.file_EndDate = String.Format("{0:MM-dd-yyyy}", menuModel.file_EndDate_Display == null ? "" : menuModel.file_EndDate_Display.Value);

                try
                {
                    var entity = _mapper.Map<TblAddMenu>(menuModel);
                    _dbcontext.TblAddMenu.Add(entity);
                    _dbcontext.SaveChanges();
                    return RedirectToAction("MenusList");
                }
                catch (Exception ex)
                {
                    _dbcontext.Logs.Add(new Logs()
                    {
                        LogDate = DateTime.Now,
                        LogMessage = "Menu creation failed for Menu ID-"+menuModel.MenuId,
                        ExceptionMessage = ex.Message,
                        StackTrace = ex.StackTrace,
                        UserId = Request.Cookies["NPCIL_username"].ToString()
                    });
                    _dbcontext.SaveChanges();
                    ViewBag.Error = "Something went wrong";
                    return View(menuModel);
                }
            }
            else
            {
                ViewBag.Error = "Menu with same name already present";
                return View(menuModel);
            }

        }



        public IActionResult MenusList(int? id = 0)
        {
            List<MenuHierarchyModel> menuHierarchy = _npcilHelper.GetMenuHierarchy();
             List<MenuModel> menuList = new List<MenuModel>();
            List<TblAddMenu> menuListdt = _dbcontext.TblAddMenu.Where(m => m.ParentId == id).ToList();
            foreach (TblAddMenu menu in menuListdt)
            {
                MenuModel menuModel = _mapper.Map<MenuModel>(menu);
                menuModel.MenuOptions.Add(new SelectListItem() { Value = "0", Text = "" });
                foreach (MenuHierarchyModel heirarchy in menuHierarchy)
                {
                    menuModel.MenuOptions.Add(new SelectListItem (){ Value = heirarchy.MenuSno.ToString(), Text = heirarchy.MenuNameEng.ToString() });
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
            MenuModel obj = _npcilHelper.GetMenuFromId(Request,id);
            obj.MenuOptions.Add(new SelectListItem() { Value = "0", Text = "Salect" });
            obj.TabActiveOptions = new List<SelectListItem>
                                                {
                                                    new SelectListItem { Value = "1", Text = "Yes" },
                                                    new SelectListItem { Value = "0", Text = "No" }
                                                };
            foreach (var m in _dbcontext.TblAddMenu.ToList())
            {
                obj.MenuOptions.Add(new SelectListItem() { Value = m.MenuSno.ToString(), Text = m.MenuNameEng.ToString() });
            }
            List<PageDataBind> datalistbind = _dbcontext.PageDataBinds.ToList();
            obj.PageBindingOptions = new List<SelectListItem>();
            obj.PageBindingOptions.Add(new SelectListItem() { Value = "0", Text = "" });
            foreach (PageDataBind db in datalistbind)
            {
                obj.PageBindingOptions.Add(new SelectListItem() { Value = db.id.ToString(), Text = db.DataBindTag });
            }
            
            ViewBag.abc = "Update";
            return View(obj);
        }

        [HttpPost]
        public IActionResult UpdateMenu(MenuModel menuModel,IFormFile file)
        {      

            if (_npcilHelper.ValidateMenu(Request, menuModel))
            {
                if (menuModel.MenuImg != null)
                {
                    menuModel.ImagePath = _fileHelper.UploadAndGetFileName(menuModel.MenuImg, menuModel.file_MenuImg.FileName);
                }

                if ((menuModel.MenuTypeId == 2 || menuModel.MenuTypeId == 7) && menuModel.file_MenuImg != null)
                {
                    menuModel.Imagepath2 = _fileHelper.UploadAndGetFileName(menuModel.file_MenuImg, menuModel.file_MenuImg.FileName);
                }

                menuModel.file_StartDate = String.Format("{0:MM-dd-yyyy}", menuModel.file_StartDate_Display == null ? "" : menuModel.file_StartDate_Display.Value);
                menuModel.file_EndDate = String.Format("{0:MM-dd-yyyy}", menuModel.file_EndDate_Display == null ? "" : menuModel.file_EndDate_Display.Value);


                try
                {
                    var entity = _mapper.Map<TblAddMenu>(menuModel);
                    _dbcontext.TblAddMenu.Update(entity);
                    _dbcontext.SaveChanges();
                    return RedirectToAction("MenusList");
                }
                catch (Exception ex)
                {
                    _dbcontext.Logs.Add(new Logs()
                    {
                        LogDate = DateTime.Now,
                        LogMessage = "Menu updation failed for Menu ID-"+menuModel.MenuId,
                        ExceptionMessage = ex.Message,
                        StackTrace = ex.StackTrace,
                        UserId = Request.Cookies["NPCIL_username"].ToString()
                    });
                    _dbcontext.SaveChanges();
                    ViewBag.Error = "Something went wrong";
                    return View(menuModel);
                }
            }
            else
            {
                return RedirectToAction("EditMenu", new { id = menuModel.MenuId });
            }
        }

        public IActionResult DeleteMenu(int id)
        {
            var Menu = _dbcontext.TblAddMenu.Where(m => m.MenuSno == id).FirstOrDefault();
            var ParentId = Menu.ParentId;
            if (Menu != null)
            {
                try
                {
                    _dbcontext.TblAddMenu.Remove(Menu);
                    _dbcontext.SaveChanges();
                }
                catch (Exception ex)
                {
                    _dbcontext.Logs.Add(new Logs()
                    {
                        LogDate = DateTime.Now,
                        LogMessage = "Menu deletion failed for Menu ID-"+id,
                        ExceptionMessage = ex.Message,
                        StackTrace = ex.StackTrace,
                        UserId = Request.Cookies["NPCIL_username"].ToString()
                    });
                    ViewBag.Error = "Something went wrong";
                }
            }
            else
            {
                ViewBag.Error = "No menu with particular id to delete";
            }
            return RedirectToAction("MenusList", new { id = ParentId });
        }

        [HttpPost]
        public IActionResult UpdateSeq([FromBody] List<MenuSeqModel> menuData)
        {
            try
            {
                foreach (MenuSeqModel model in menuData)
                {
                    TblAddMenu menuToUpdate = _dbcontext.TblAddMenu.Find(model.MenuId);

                    if (menuToUpdate != null)
                    {
                        menuToUpdate.MenuOrder = model.Sequence;

                        _dbcontext.TblAddMenu.Update(menuToUpdate);
                        _dbcontext.SaveChanges();
                    }

                }

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                _dbcontext.Logs.Add(new Logs()
                {
                    LogDate = DateTime.Now,
                    LogMessage = "Menu Sequence updation failed",
                    ExceptionMessage = ex.Message,
                    StackTrace = ex.StackTrace,
                    UserId = Request.Cookies["NPCIL_username"].ToString()
                });
                _dbcontext.SaveChanges();
                return Json(new { success = false });
            }
            
        }
    }
}

