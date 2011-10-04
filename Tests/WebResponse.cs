using System;
using System.Web;

namespace Tests
{
    public class WebResponse
    {
        public HttpResponse Response { get; private set; }
        public string Body { get; private set; }

        public WebResponse(HttpResponse response, String responseBody)
        {
            Response = response;
            Body = responseBody;
        }
    }
}