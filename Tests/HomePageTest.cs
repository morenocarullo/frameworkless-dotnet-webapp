using System;
using FrameworkLessWebApp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class HomePageTest
    {
        private readonly HomePage _module = new HomePage();

        [Test]
        public void Handles()
        {
            Assert.That(_module.Handles(new Application().Url()), Is.True);
            Assert.That(_module.Handles(new Uri(new Application().Url(), "/default.aspx")), Is.True);
            Assert.That(_module.Handles(new Uri(new Application().Url(), "/another")), Is.False);
        }

        [Test]
        public void ProcessRequest()
        {
            var uri = new Application().Url();

            Assert.That(new HttpLessWebSite(_module).Response(uri).Body, Is.EqualTo("Welcome to frameworkless c# web programming"));
        }
    }
}