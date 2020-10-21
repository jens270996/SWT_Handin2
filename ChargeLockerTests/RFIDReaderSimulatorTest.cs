using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ChargeLocker;

namespace ChargeLockerTests
{
    public class RFIDReaderSimulatorTest
    {
        private RFIDReaderSimulator _uut;

        [SetUp]
        public void SetUp()
        {
            _uut=new RFIDReaderSimulator();

        }


        [Test]
        public void SimulateRFIDReceive_ThrowsEvent()
        {
            RFIDDetectedEventArgs receivedArgs=null;
            _uut.RFIDDetected += (o, args) =>
            {
                
                receivedArgs = args;
            };

            _uut.SimulateScan(17);

            Assert.That(receivedArgs,Is.Not.Null);
        }

        [TestCase(37383)]
        [TestCase(0)]
        [TestCase(1)]
        public void SimulateRFIDReceive_EventArgsContainsRFID(int a)
        {
            
            RFIDDetectedEventArgs receivedArgs = null;
            _uut.RFIDDetected += (o, args) =>
            {

                receivedArgs = args;
            };

            _uut.SimulateScan(a);

            Assert.That(receivedArgs.RFID, Is.EqualTo(a));
        }
    }
   
}
