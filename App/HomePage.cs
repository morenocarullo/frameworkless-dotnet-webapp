using System;
using System.Web;

namespace FrameworkLessWebApp
{
    public class HomePage
        : IAppModule
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("Welcome to frameworkless c# web programming");
        }

        public bool Handles(Uri uri)
        {
            return uri.PathAndQuery.Equals("/") || uri.PathAndQuery.Equals("/default.aspx");
        }
    }
}