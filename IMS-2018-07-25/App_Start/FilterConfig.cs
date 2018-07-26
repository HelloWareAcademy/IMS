using System.Web;
using System.Web.Mvc;

namespace IMS_2018_07_25
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
