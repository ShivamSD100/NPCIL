using System.Collections.Generic;

namespace NPCIL.Models
{
    public class HomeModel : BaseWebPageModel
    {
        public List<TenderModel> Tenders { get; set; }
        public List<VerticalNewsModel> VerticalNews { get; set; }
        public List<HorizontalNewsModel> HorizontalNews { get; set; }

        public virtual ICollection<MenuModel> SubMenus { get; set; } = new List<MenuModel>();

        public MenuModel Menu { get; set; }
    }
}
