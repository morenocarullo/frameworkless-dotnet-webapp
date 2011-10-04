using System;
using System.Web;

namespace FrameworkLessWebApp
{
    public class Parrot : IAppModule
    {
        public void ProcessRequest(HttpContext context)
        {
            var response = context.Request.Url.GetComponents(UriComponents.Query, UriFormat.UriEscaped);
            context.Response.Write(response);
        }

        public bool Handles(Uri uri)
        {
            return uri.PathAndQuery.StartsWith("/parrot");
        }
    }
}