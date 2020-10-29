using NUnit.Framework;
using ChargeLocker;
using NSubstitute;

namespace ChargeLockerTests
{
    [TestFixture]
    public class DoorTest
    {
        private DoorSimulator _uut;

        [SetUp]
        public void Setup()
        {
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

        [Test]
        public void Lock_FunctionCalled_LockedBoolIsTrue()
        {
            _uut.Unlock();                                   
            _uut.Lock();
            Assert.That(_uut.locked, Is.EqualTo(true));
        }

        [Test]
        public void Unlock_FunctionCalled_LockedBoolIsFalse()
        {
            _uut.Lock();                                    
            _uut.Unlock();
            Assert.That(_uut.locked, Is.EqualTo(false));
        }

    }

}