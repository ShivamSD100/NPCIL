using NPCIL.Models;
using System.Collections.Generic;
using WebApplication1.Models;

namespace NPCIL.Helper
{
    public interface INPCILHelper
    {
        public List<BannerModel> GetBanners();
        public List<MenuModel> GetMenus();
        public MenuModel GetMenuFromId(int id);
        public List<MenuModel> GetSubMenus(int id);
        public List<TenderModel> GetTenders();
        public List<VerticalNewsModel> GetVerticalNews();
        public List<HorizontalNewsModel> GetHorizontalNews();
        public List<BannerModel> GetActiveBanners();
        public List<MenuModel> GetActiveMenus();
        public List<MenuModel> GetActiveSubMenus(int id);
        public List<TenderModel> GetActiveTenders();
        public List<VerticalNewsModel> GetActiveVerticalNews();
        public List<HorizontalNewsModel> GetActiveHorizontalNews();

    }
}
