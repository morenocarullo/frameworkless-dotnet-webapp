using System;
using System.Net;
using FrameworkLessWebApp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AdderTest
    {
        private readonly Adder _adder = new Adder();

        [Test]
        public void Add()
        {
            const int firstAddendum = 1;
            const int secondAddendum = 2;

            var additionUri = new Uri(new Application().Url(), "/adder?a=" + firstAddendum + "&b=" + secondAddendum);

            Assert.That(new HttpLessWebSite(_adder).Response(additionUri).Body, Is.EqualTo((firstAddendum + secondAddendum).ToString()));
            Assert.That(new HttpLessWebSite(_adder).ResponseStatusCodeFor(additionUri), Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void AddWithIncorrectParams()
        {
            var additionUri = new Uri(new Application().Url(), "/adder?a=2&x=bb");

            Assert.That(new HttpLessWebSite(_adder).Response(additionUri).Body, Is.EqualTo("error"));
        }

        [Test]
        public void HandlesHisUrls()
        {
            Assert.That(_adder.Handles(new Uri(new Application().Url(), "/adder?hello")), Is.True);
            Assert.That(_adder.Handles(new Uri(new Application().Url(), "/another")), Is.False);
        }
    }
}