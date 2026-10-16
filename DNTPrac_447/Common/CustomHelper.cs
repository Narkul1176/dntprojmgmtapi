using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Security;

namespace DNTPrac_447.Common
{
    public static class CustomHelper
    {
        public static IHtmlContent MyButton(this IHtmlHelper htmlHelper, string value)
        {
            string str = $"<input type='submit' value='{value}' class='btn btn-primary' />";
            return new HtmlString(str);
        }
        public static string FormatString(this string str)
        {
            return "Hello " + str;
        }
    }
}
