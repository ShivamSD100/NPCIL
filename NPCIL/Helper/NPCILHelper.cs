using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using NPCIL.Models;
using WebApplication1.Models;

namespace NPCIL.Helper
{
    public class NPCILHelper : INPCILHelper
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public NPCILHelper(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public List<BannerModel> GetBanners()
        {

            DataTable dt = cmn.GetDatatable("exec PRC_AddBanner @qtype=4");

             List<BannerModel> Banners = [];

            foreach (DataRow row in dt.Rows)
            {
                BannerModel menu = new BannerModel
                {
                    BannerId = Convert.ToInt32(row["Ban_Sno"]),
                    ImagePath = row["newImg"].ToString(),
                    BannerTitle = row["ban_title"].ToString(),
                };
                Banners.Add(menu);
            }

            return Banners;

        }
        public List<MenuModel> GetMenus()
        {

            DataTable dt = cmn.GetDatatable("exec PRC_AddMenu @qtype=2");

             List<MenuModel> Menus = [];

            foreach (DataRow row in dt.Rows)
            {
                MenuModel menu = new MenuModel()
                {
                    MenuId = int.Parse(row["menu_sno"].ToString()),
                    MenuName_eng = row["menu_name_eng"].ToString(),
                    MenuName_hind = row["menu_name_hind"].ToString(),
                    MenuPosition_Name = row["position"].ToString(),
                    MenuType_Name = row["mtype"].ToString(),
                    ImagePath = row["menu_img"].ToString(),
                    ParentId = row["ParentId"].ToString(),
                    tabActive = row["tab_Active"].ToString(),
                };
                Menus.Add(menu);
            }

            return Menus;

        }

        public List<MenuModel> GetSubMenus(int id)
        {

            DataTable dt = cmn.GetDatatable("exec PRC_AddMenu @qtype=5 , @parentid='\" + id + \"'");

            List<MenuModel> Menus = [];

            foreach (DataRow row in dt.Rows)
            {
                MenuModel menu = new MenuModel()
                {
                    MenuId = int.Parse(row["menu_sno"].ToString()),
                    MenuName_eng = row["menu_name_eng"].ToString(),
                    MenuName_hind = row["menu_name_hind"].ToString(),
                    MenuPosition_Name = row["position"].ToString(),
                    MenuType_Name = row["mtype"].ToString(),
                    ImagePath = row["menu_img"].ToString(),
                    ParentId = row["ParentId"].ToString(),
                    tabActive = row["tab_Active"].ToString(),
                };
                Menus.Add(menu);
            }

            return Menus;

        }

        List<TenderModel> INPCILHelper.GetTenders()
        {
            return new List<TenderModel>();
        }

        List<VerticalNewsModel> INPCILHelper.GetVerticalNews()
        {
            return new List<VerticalNewsModel>();
        }

        List<HorizontalNewsModel> INPCILHelper.GetHorizontalNews()
        {
            return new List<HorizontalNewsModel>();
        }

        List<MenuModel> INPCILHelper.GetSubMenus(string id)
        {
            return new List<MenuModel>();
        }
    }
}
