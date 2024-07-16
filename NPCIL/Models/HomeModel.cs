using System.Collections.Generic;

namespace NPCIL.Models
{
    public class HomeModel : BaseWebPageModel
    {
        public List<TenderModel> Tenders { get; set; }
        public List<VerticalNewsModel> VerticalNews { get; set; }
        public List<HorizontalNewsModel> HorizontalNews { get; set; }
    }
}
