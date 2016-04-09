using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhorshidBare.App_Start
{
    using System.Web.Mvc;

    /// <summary>
    /// Use for whitelisting controllers and actions 
    /// allow annonymous access
    /// </summary>
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
        }
    }
}