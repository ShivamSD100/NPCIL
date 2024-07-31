using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using NPCIL.Models;
using System.Collections.Generic;
using WebApplication1.Models;

namespace NPCIL.Helper
{
    public interface INPCILHelper
    {
        public List<BannerModel> GetBanners(HttpRequest req);
        public List<MenuModel> GetMenus(HttpRequest req);
        public MenuModel GetMenuFromId(HttpRequest req,int id);
        public List<MenuModel> GetSubMenus(HttpRequest req,int id);
        public List<TenderModel> GetTenders(HttpRequest req);
        public List<VerticalNewsModel> GetVerticalNews();
        public List<HorizontalNewsModel> GetHorizontalNews();
        public List<BannerModel> GetActiveBanners(HttpRequest req);
        public List<MenuModel> GetActiveMenus(HttpRequest req);
        public List<MenuModel> GetActiveSubMenus(HttpRequest req,int id);
        public List<TenderModel> GetActiveTenders(HttpRequest req);
        public List<VerticalNewsModel> GetActiveVerticalNews();
        public List<HorizontalNewsModel> GetActiveHorizontalNews();
        public bool ValidateMenu(HttpRequest req,MenuModel model);

    }
}
