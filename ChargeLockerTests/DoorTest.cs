using NUnit.Framework;

namespace ChargeLockerTests
{
    public class DoorTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            Assert.That(5, Is.EqualTo(5));
            Assert.Pass();
        }

    }
}