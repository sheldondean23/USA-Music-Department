using System.Web;
using System.Web.Mvc;

namespace USA_Music_Department
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new System.Web.Mvc.AuthorizeAttribute());
            //filters.Add(new RequireHttpsAttribute());
        }
    }
}
