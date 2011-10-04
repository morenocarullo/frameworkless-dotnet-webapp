using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrameworkLessWebApp
{
    public class Application : IHttpHandler, IAppModule
    {
        private readonly IEnumerable<IAppModule> _modules;

        public Application()
        {
            _modules = new IAppModule[] {new HomePage(), new Adder(), new Parrot(), new Error404()};
        }

        public bool Handles(Uri uri)
        {
            return true;
        }

        public void ProcessRequest(HttpContext context)
        {
            _modules.Where(m => m.Handles(context.Request.Url)).First().ProcessRequest(context);
        }

        public bool IsReusable
        {
            get { return true; }
        }

        public Uri Url()
        {
            return new Uri("http://localhost:51111/");
        }
    }
}