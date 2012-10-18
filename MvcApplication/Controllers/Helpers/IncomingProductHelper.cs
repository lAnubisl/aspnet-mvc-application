using System.Web.Mvc;

namespace MVCApplication.Controllers.Helpers
{
    public static class IncomingProductHelper
    {
        public static MvcHtmlString IncomingProduct(this HtmlHelper htmlHelper, string productName, long productCount)
        {
            return new MvcHtmlString(string.Format(
                "<td><input value = \"{0}\"/></td>" +
                "<td><input value = \"{1}\"/></td>",
                productName,
                productCount));
        }
    }
}