using System.Collections.Generic;

namespace NPCIL.Models
{
    public class MenuViewModel
    {
        public List<MenuModel> Menus { get; set; }
        public string ParentId { get; set; }
    }
}
