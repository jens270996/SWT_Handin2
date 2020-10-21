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
            bool eventThrown = false;
            RFIDDetectedEventArgs receivedArgs=null;
            _uut.RFIDDetected += (o, args) =>
            {
                
                receivedArgs = args;
            };

            _uut.SimulateScan(17);

            Assert.That(receivedArgs,Is.Not.Null);
        }
    }
   
}
