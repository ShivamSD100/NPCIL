using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPCIL.Helper;
using NPCIL.Models;

namespace NPCIL.Controllers
{
    public class PageController : Controller
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        private readonly INPCILHelper _npcilHelper;

        public PageController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment, INPCILHelper npcilHelper)
        {
            hostingEnvironment = environment;
            _npcilHelper = npcilHelper;
        }
        public IActionResult Index(int id)
        {
            HomeModel model = new HomeModel()
            {
                Menus = _npcilHelper.GetActiveMenus(Request),
                Menu = _npcilHelper.GetMenuFromId(Request,id)
            };
            return View(model);
        }
    }
}
