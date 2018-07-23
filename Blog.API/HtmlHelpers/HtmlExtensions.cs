using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.API.HtmlHelpers
{
    public static class HtmlExtensions
    {
        public static bool IsDebugMode(this IHtmlHelper html)
        {
            #if DEBUG
                return true;
            #else
                return false;
            #endif
        }
    }
}
