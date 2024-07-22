using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace NPCIL.Helper
{
    public class DynamicPageHelper : IDynamicPageHelper
    {
        public bool CreateControllerAndView(string controllerName, string path)
        {
            try
            {
                string controllersPath = Path.Combine(path, "Controllers");
                string viewsPath = Path.Combine(path, "Views", controllerName);
                string pagesFilePath = Path.Combine(path, "pages.txt");
                // Create controller file
                string controllerContent = $@"
            using Microsoft.AspNetCore.Mvc;

            namespace YourNamespace.Controllers
            {{
                public class {controllerName}Controller : Controller
                {{
                    public IActionResult Index()
                    {{
                        return View();
                    }}
                }}
            }}";
                System.IO.File.WriteAllText(Path.Combine(controllersPath, $"{controllerName}Controller.cs"), controllerContent);

                // Create view directory and file
                Directory.CreateDirectory(viewsPath);
                string viewContent = $@"
@{{ 
    Layout = ""_LayoutWebPage"";
}}

            <h2>Hello, this is the Index view of {controllerName}Controller!</h2>";
                System.IO.File.WriteAllText(Path.Combine(viewsPath, "Index.cshtml"), viewContent);

                // Update pages file
                if (System.IO.File.Exists(pagesFilePath))
                {
                    var pages = new HashSet<string>(System.IO.File.ReadAllLines(pagesFilePath));
                    pages.Add(controllerName);
                    System.IO.File.WriteAllLines(pagesFilePath, pages);
                }
                else
                {
                    System.IO.File.WriteAllLines(pagesFilePath, new[] { controllerName });
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool DeleteControllerAndView(string controllerNameToDelete, string path)
        {
            try
            {
                string controllerFilePath = Path.Combine(path, "Controllers", $"{controllerNameToDelete}Controller.cs");
                string viewsPath = Path.Combine(path, "Views", controllerNameToDelete);
                string pagesFilePath = Path.Combine(path, "pages.txt");

                if (System.IO.File.Exists(controllerFilePath))
                {
                    System.IO.File.Delete(controllerFilePath);
                }
                if (Directory.Exists(viewsPath))
                {
                    Directory.Delete(viewsPath, true);
                }

                // Update pages file
                if (System.IO.File.Exists(pagesFilePath))
                {
                    var pages = new HashSet<string>(System.IO.File.ReadAllLines(pagesFilePath));
                    pages.Remove(controllerNameToDelete);
                    System.IO.File.WriteAllLines(pagesFilePath, pages);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
