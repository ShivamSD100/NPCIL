using System.Collections.Generic;
using WebApplication1.Models;

namespace NPCIL.Models
{
    public class BaseWebPageModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<MenuModel> Menus { get; set; }

        public List<BannerModel>  Banners {get; set;}
    }

}
