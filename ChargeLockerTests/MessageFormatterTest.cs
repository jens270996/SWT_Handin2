using System;
using System.Collections.Generic;
using System.Text;
using ChargeLocker;
using NSubstitute;
using NUnit.Framework;

namespace ChargeLockerTests
{
    class MessageFormatterTest
    {
        private IMessageFormatter uut_;
        private IDisplayer displayer;
        [SetUp]
        public void Setup()
        {
            displayer = Substitute.For<IDisplayer>();
            uut_=new MessageFormatter(displayer);
        }


        [Test]
        public void DisplayEnterRFID_CallsDisplayerWithCorrectString()
        {
            uut_.DisplayEnterRFID();
            displayer.Received(1).PrintMessage("Indlæs RFID");
        }
        [Test]
        public void DisplayConnect_CallsDisplayerWithCorrectString()
        {
            uut_.DisplayConnect();
            displayer.Received(1).PrintMessage("Tilslut telefon");
        }
        [Test]
        public void DisplayConnectionError_CallsDisplayerWithCorrectString()
        {
            uut_.DisplayConnectionError();
            displayer.Received(1).PrintMessage("Tilslutningsfejl");
        }
        [Test]
        public void DisplayRFIDError_CallsDisplayerWithCorrectString()
        {
            uut_.DisplayRFIDError();
            displayer.Received(1).PrintMessage("RFID fejl");
        }
        [Test]
        public void DisplayOccupied_CallsDisplayerWithCorrectString()
        {
            uut_.DisplayOccupied();
            displayer.Received(1).PrintMessage("Ladeskab optaget");

        }
        [Test]
        public void DisplayRemovePhone_CallsDisplayerWithCorrectString()
        {
            uut_.DisplayRemovePhone();
            displayer.Received(1).PrintMessage("Fjern telefon");

        }
        [TestCase(0.0)]
        [TestCase(8971.4380)]
        [TestCase(499.41)]
        [TestCase(-23.01)]
        public void DisplayCurrentChange_CallsDisplayerWithCorrectString(double current)
        {
            uut_.DisplayCurrentChange(current);
            displayer.Received(1).PrintMessage($"New current: {current}");

        }
    }
}
