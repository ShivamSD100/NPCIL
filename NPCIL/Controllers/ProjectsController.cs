
            using Microsoft.AspNetCore.Mvc;

            namespace YourNamespace.Controllers
            {
                public class ProjectsController : Controller
                {
                    public IActionResult Index()
                    {
                        return View();
                    }
                }
            }