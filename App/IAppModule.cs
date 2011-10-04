using System;
using System.Web;

namespace FrameworkLessWebApp
{
    public interface IAppModule
    {
        void ProcessRequest(HttpContext context);
        bool Handles(Uri uri);
    }
}