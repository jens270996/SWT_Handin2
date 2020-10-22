using NUnit.Framework;
using ChargeLocker;
using NSubstitute;

namespace ChargeLockerTests
{
    [TestFixture]
    public class DoorTest
    {
        private DoorSimulator _uut;
        private IDoor _door;

        [SetUp]
        public void Setup()
        {
            _door = Substitute.For<IDoor>();
            _uut = new DoorSimulator();
        }

        [Test]
        public void SimulateDoorOpen_OpenDoorEventCalled_CallsEvent()
        {
            DoorOpenEventArgs receivedArgs = null;
            _uut.DoorOpenEvent += (o, args) =>
            {
                receivedArgs = args;
            };
            _uut.SimulateDoorOpen();

            Assert.That(receivedArgs, Is.Not.Null);
        }

        [Test]
        public void SimulateDoorClosed_ClosedDoorEventCalled_CallsEvent()
        {
            DoorCloseEventArgs receivedArgs = null;
            _uut.DoorCloseEvent += (o, args) =>
            {
                receivedArgs = args;
            };
            _uut.SimulateDoorClosed();

            Assert.That(receivedArgs, Is.Not.Null);
        }

    }

}