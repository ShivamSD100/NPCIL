using Microsoft.AspNetCore.Mvc;
using NPCIL.Helper;
using NPCIL.Models;

namespace YourNamespace.Controllers
{
    public class MissionandObjectiveController : Controller
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        private readonly INPCILHelper _npcilHelper;

        public MissionandObjectiveController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment, INPCILHelper npcilHelper)
        {
            hostingEnvironment = environment;
            _npcilHelper = npcilHelper;
        }


        public IActionResult Index()
        {
            MissonAndObjectiveModel model = new MissonAndObjectiveModel()
            {
                Menus = _npcilHelper.GetMenus(),
            };

            return View(model);
        }
    }
}