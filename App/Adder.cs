using System;
using System.Web;

namespace FrameworkLessWebApp
{
    public class Adder : IAppModule
    {
        public void ProcessRequest(HttpContext context)
        {
            var firstAddendum = context.Request.Params["a"];
            var secondAddendum = context.Request.Params["b"];

            if (firstAddendum == null || secondAddendum == null)
            {
                context.Response.Write("error");
            }
            else
            {
                context.Response.Write(int.Parse(firstAddendum) + int.Parse(secondAddendum));   
            }
        }

        public bool Handles(Uri uri)
        {
            return uri.PathAndQuery.StartsWith("/adder");
        }
    }
}