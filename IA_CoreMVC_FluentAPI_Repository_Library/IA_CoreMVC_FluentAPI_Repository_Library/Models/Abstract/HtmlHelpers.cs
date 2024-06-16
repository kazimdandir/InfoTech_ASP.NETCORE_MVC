using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace IA_CoreMVC_FluentAPI_Repository_Library.Models.Abstract
{
    public static class HtmlHelpers
    {
        public static string IsActive(this IHtmlHelper html, string control, string action)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = routeData.Values["action"]?.ToString();
            var routeController = routeData.Values["controller"]?.ToString();

            // Null-safe string karşılaştırması yap
            var returnActive = string.Equals(routeAction, action, StringComparison.OrdinalIgnoreCase)
                            && string.Equals(routeController, control, StringComparison.OrdinalIgnoreCase);

            return returnActive ? "active" : "";
        }
    }
}
