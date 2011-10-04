using System;
using System.Web;

namespace FrameworkLessWebApp
{
    public class Error404 : IAppModule
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.StatusCode = 404;
            context.Response.Write("<html><body>404 not found</body></html>");
        }

        public bool Handles(Uri uri)
        {
            return true;
        }
    }
}