using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

        public List<TenderModel> GetTenders()
        {
            DataTable dt = cmn.GetDatatable("exec PRC_Tender @Qtype=2");
            List<TenderModel> Tenders = [];
            foreach (DataRow row in dt.Rows)
            {
                TenderModel tender = new TenderModel()
                {
                    id = int.Parse(row["Tender_id"].ToString()),
                    TendorNo = row["Tendor_no"].ToString(),
                    TendorAuthEng = row["Tendor_IssuingAuth_eng"].ToString(),
                    DateOpening = (DateTime.ParseExact(row["Tender_DateOpening"].ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture)).ToString("d-M-yyyy"),
                    StartDate_Receiving = (DateTime.ParseExact(row["Tender_StartDate_ReceivingTender"].ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture)).ToString("d-M-yyyy"),
                    EndDate_Receiving = (DateTime.ParseExact(row["Tender_EndDate_ReceivingTender"].ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture)).ToString("d-M-yyyy")
                };
                Tenders.Add(tender);
            }
            return Tenders;
        }

        public List<VerticalNewsModel> GetVerticalNews()
        {
            DataTable dt = cmn.GetDatatable("exec PRC_AddVerticalNews @qtype=2");
            List<VerticalNewsModel> VerticalNews = [];
            foreach (DataRow row in dt.Rows)
            {
                VerticalNewsModel verticalNewsModel = new VerticalNewsModel()
                {
                    VN_id = int.Parse(row["VN_Sno"].ToString()),
                    VN_LangName = row["langua"].ToString(),
                    VN_ContentName = row["content"].ToString(),
                    VN_Title = row["VN_Title"].ToString(),
                    VN_Description = row["VN_Description"].ToString(),
                    VN_StartDate = row["startdate"].ToString(),
                    VN_EndDate = row["enddate"].ToString()
                };
                VerticalNews.Add(verticalNewsModel);
            }
            return VerticalNews;
        }

        public List<HorizontalNewsModel> GetHorizontalNews()
        {
            DataTable dt = cmn.GetDatatable("exec PRC_AddHorizontalNews @qtype=2");
            List <HorizontalNewsModel> HorizontalNews = [];
            foreach (DataRow row in dt.Rows)
            {
                HorizontalNewsModel horizontalNewsModel = new HorizontalNewsModel()
                {
                    HN_id = int.Parse(row["HN_Sno"].ToString()),
                    HN_LangName = row["langua"].ToString(),
                    HN_ContentName = row["content"].ToString(),
                    HN_Title = row["HN_Title"].ToString(),
                    HN_Description = row["HN_Description"].ToString(),
                    HN_StartDate = row["startdate"].ToString(),
                    HN_EndDate = row["enddate"].ToString()
                };
                HorizontalNews.Add(horizontalNewsModel);
            }
            return HorizontalNews;
        }

    }
}
