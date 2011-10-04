using System;
using System.Net;
using FrameworkLessWebApp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Error404Test
    {
        [Test]
        public void Error()
        {
            var additionUri = new Uri(new Application().Url(), "/anUrlThatDoesNotExist");

            Assert.That(new HttpLessWebSite(new Error404()).Response(additionUri).Body, Is.EqualTo("<html><body>404 not found</body></html>"));
            Assert.That(new HttpLessWebSite(new Error404()).ResponseStatusCodeFor(additionUri), Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}