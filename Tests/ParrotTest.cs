using System;
using FrameworkLessWebApp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ParrotTest
    {
        private readonly Parrot _parrot = new Parrot();

        [Test]
        public void RepeatsQueryInResponse()
        {
            var uri = new Uri(new Application().Url(), "/parrot?hello");
            var expectedResponse = uri.GetComponents(UriComponents.Query,UriFormat.UriEscaped);

            Assert.That(new HttpLessWebSite(_parrot).Response(uri).Body, Is.EqualTo(expectedResponse));
        }

        [Test]
        public void HandlesHisUrls()
        {
            Assert.That(_parrot.Handles(new Uri(new Application().Url(), "/parrot?hello")), Is.True);
            Assert.That(_parrot.Handles(new Uri(new Application().Url(), "/another")), Is.False);
        }
    }
}