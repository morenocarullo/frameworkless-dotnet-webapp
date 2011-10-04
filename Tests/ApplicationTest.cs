using System;
using System.Net;
using FrameworkLessWebApp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ApplicationTest
    {
        [Test]
        public void CheckAllModulesAreAvailableOnRealServer()
        {
            Check(new Adder(), "/adder?a=5&b=1");
            Check(new Parrot(), "/parrot?integrationtest");
            Check(new HomePage(), "/");
        }

        [Test]
        public void Error404IsHandled()
        {
            var notExistingUrl = new Uri(new Application().Url(), "/thisUrlDoesNotExist");
            var exception = Assert.Throws<WebException>(() => new WebClient().DownloadString(notExistingUrl));
            Assert.That(exception.Message, Is.StringContaining("404"));
        }

        private void Check(IAppModule module, string relativeUri)
        {
            var url = new Uri(new Application().Url(), relativeUri);
            var expectedResponse = new HttpLessWebSite(module).Response(url).Body;
            var responseFromIIS = new WebClient().DownloadString(url);

            Assert.That(responseFromIIS, Is.EqualTo(expectedResponse));
        }
    }
}