using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc;
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
        public List<BannerModel> GetActiveBanners()
        {
            return GetBanners();

        }
        public MenuModel BindMenuFromDt(DataRow row)
        {
            return new MenuModel()
            {
                MenuId = int.Parse(row["menu_sno"].ToString()),
                MenuName_eng = row["menu_name_eng"].ToString(),
                MenuName_hind = row["menu_name_hind"].ToString(),
                MenuPosition_Name = row["position"].ToString(),
                MenuType_Name = row["mtype"].ToString(),
                //ImagePath = _urlService.GetVideoUrl(row["menu_img"].ToString()),
                //Imagepath2 = _urlService.GetVideoUrl(row["file_image"].ToString()),
                ImagePath = "~/wwwroot"+row["menu_img"].ToString(),
                Imagepath2 = "~/wwwroot"+row["file_image"].ToString(),
                ParentId = row["ParentId"].ToString(),
                tabActive = row["tab_Active"].ToString(),
                Controller = row["controller"].ToString(),
                link_urlname = row["link_urlname"].ToString(),
                Content_MenuName_hindi = row["Content_hind"].ToString(),
                Content_MenuName_eng = row["content_eng"].ToString(),
                linkTypeId = int.Parse(row["linkTypeId"].ToString()),
                LinkTypeName = GetLinkTypeFromID(int.Parse(row["linkTypeId"].ToString())),
                Sequence = row["menuOrder"].ToString()
            };
        }
        public List<MenuModel> GetMenus()
        {
            DataTable dt = cmn.GetDatatable("exec PRC_AddMenu @qtype=2");
            List<MenuModel> Menus = [];
            foreach (DataRow row in dt.Rows)
                Menus.Add(BindMenuFromDt(row));
            return Menus;
        }

        public List<MenuModel> GetActiveMenus()
        {
            return GetMenus().Where(m => m.tabActive == "1").ToList();
        }

        public MenuModel GetMenuFromId(int id)
        {
            DataTable dt = cmn.GetDatatable("exec PRC_AddMenu @qtype=7, @sno="+id);
            return BindMenuFromDt(dt.Rows[0]);
        }
        public List<MenuModel> GetSubMenus(int id)
        {
            DataTable dt = cmn.GetDatatable("exec PRC_AddMenu @qtype=5 , @parentid="+id);
            List<MenuModel> Menus = [];
            foreach (DataRow row in dt.Rows)
            {
                Menus.Add(BindMenuFromDt(row));
            }
            return Menus;
        }

        public List<MenuModel> GetActiveSubMenus(int id)
        {
            return GetSubMenus(id).Where(sm => sm.tabActive == "1").ToList();
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
                    DateOpening = row["Tender_DateOpening"].ToString(),
                    StartDate_Receiving = row["Tender_StartDate_ReceivingTender"].ToString(),
                    EndDate_Receiving = row["Tender_EndDate_ReceivingTender"].ToString(),
                    IsArchived = Boolean.Parse(row["Tender_IsArchived"].ToString())

                };
                Tenders.Add(tender);
            }
            return Tenders;
        }

        public List<TenderModel> GetActiveTenders()
        {
            return GetTenders().Where(t => t.IsArchived == false).ToList();
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
                    VN_EndDate = row["enddate"].ToString(),
                    VN_IsArchived = Boolean.Parse(row["VN_IsArchived"].ToString())
                };
                VerticalNews.Add(verticalNewsModel);
            }
            return VerticalNews;
        }

        public List<VerticalNewsModel> GetActiveVerticalNews()
        {
            return GetVerticalNews().Where(t => t.VN_IsArchived == false).ToList();
        }
        public List<HorizontalNewsModel> GetHorizontalNews()
        {
            DataTable dt = cmn.GetDatatable("exec PRC_AddHorizontalNews @qtype=2");
            List<HorizontalNewsModel> HorizontalNews = [];
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

        public List<HorizontalNewsModel> GetActiveHorizontalNews()
        {
            return GetHorizontalNews().Where(t => t.HN_IsArchived == false).ToList();
        }


        public List<LinkTypeModel> GetLinkTypes()
        {
            List<LinkTypeModel> linkTypeList = new List<LinkTypeModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_linkList @qtype = 1");
            foreach (DataRow dr in dt.Rows)
            {
                LinkTypeModel menuModel = new LinkTypeModel()
                {
                    LinkTypeId = int.Parse(dr["link_id"].ToString()),
                    LinkType = dr["link_name"].ToString()
                };
                linkTypeList.Add(menuModel);
            }
            return linkTypeList;
        }
        public string GetLinkTypeFromID(int id)
        {
            DataTable dt = cmn.GetDatatable("exec PRC_linkList @qtype=2, @id=" + id);

            if (dt.Rows.Count > 0)
                return String.IsNullOrEmpty(dt.Rows[0][1].ToString()) ? "" : dt.Rows[0][1].ToString();
            else
                return "";
        }
    }
}
