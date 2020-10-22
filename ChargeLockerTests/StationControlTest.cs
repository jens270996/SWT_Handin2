using System;
using System.Collections.Generic;
using System.Text;
using ChargeLocker;
using NSubstitute;
using NUnit.Framework;

namespace ChargeLockerTests
{
    class StationControlTest
    {
        private IDoor door;
        private IRfidReader rfid;
        private IMessageFormatter msgFormatter;
        private IChargeControl chargeControl;
        private ILogFile logFile;
        private StationControl _uut;

        [SetUp]
        public void Setup()
        {
            door = Substitute.For<IDoor>();
            rfid = Substitute.For<IRfidReader>();
            msgFormatter = Substitute.For<IMessageFormatter>();
            chargeControl = Substitute.For<IChargeControl>();
            logFile = Substitute.For<ILogFile>();
            _uut=new StationControl(door,rfid,msgFormatter,chargeControl,logFile);


        }

        //handle door closed events:
        [Test]
        public void HandleDoorOpenEvent_DoorClosedNotOccupied_MsgFormatterDisplayConnectCalled()
        {
            door.DoorOpenEvent += Raise.EventWith(new DoorOpenEventArgs());

            msgFormatter.Received(1).DisplayConnect();
        }
    }
}
