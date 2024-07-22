namespace NPCIL.Helper
{
    public interface IDynamicPageHelper
    {
        public bool CreateControllerAndView(string controllerName, string path);
        public bool DeleteControllerAndView(string controllerNameToDelete, string path);
    }
}
