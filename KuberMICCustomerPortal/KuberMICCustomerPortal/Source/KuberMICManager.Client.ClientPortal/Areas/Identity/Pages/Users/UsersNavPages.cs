using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KuberMICManager.WebUI.Areas.Identity.Pages.Users
{
    public static class UsersNavPages
    {
        public static string Index => "Index";

        public static string NewUser => "NewUser";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string NewUserNavClass(ViewContext viewContext) => PageNavClass(viewContext, NewUser);
    
        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
