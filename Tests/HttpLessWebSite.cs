using System;
using System.IO;
using System.Net;
using System.Web;
using FrameworkLessWebApp;

namespace Tests
{
    public class HttpLessWebSite
    {
        private readonly IAppModule _handler;

        public HttpLessWebSite(IAppModule module)
        {
            _handler = module;
        }

        public HttpStatusCode ResponseStatusCodeFor(Uri requestedUri)
        {
            return (HttpStatusCode)Response(requestedUri).Response.StatusCode;
        }

        public WebResponse Response(Uri requestedUri)
        {
            var request = new HttpRequest("", requestedUri.ToString(), requestedUri.GetComponents(UriComponents.Query, UriFormat.UriEscaped));
            var writer = new StringWriter();
            var response = new HttpResponse(writer);
            var context = new HttpContext(request, response);

            _handler.ProcessRequest(context);
            return new WebResponse(response, writer.GetStringBuilder().ToString());
        }
    }
}