using System;
using System.Collections.Generic;
using System.Text;
using ChargeLocker;
using NSubstitute;
using NSubstitute.Extensions;
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

        //handle door open/closed events:
        [Test]
        public void HandleDoorOpenEvent_DoorClosedNotOccupied_MsgFormatterDisplayConnectCalled()
        {
            door.DoorOpenEvent += Raise.EventWith(new DoorOpenEventArgs());

            msgFormatter.Received(1).DisplayConnect();
        }


        [Test]
        public void HandleDoorCloseEvent_DoorOpenNotOccupied_MsgFormatterDisplayEnterRFIDCalled()
        {
            door.DoorOpenEvent += Raise.EventWith(new DoorOpenEventArgs());
            door.DoorCloseEvent += Raise.EventWith(new DoorCloseEventArgs());
            msgFormatter.Received(1).DisplayEnterRFID();
        }

        [Test]
        public void HandleDoorCloseEvent_DoorClosedNotOccupied_MsgFormatterDisplayEnterRFIDNOTCalled()
        {
           
            door.DoorCloseEvent += Raise.EventWith(new DoorCloseEventArgs());
            msgFormatter.Received(0).DisplayEnterRFID();
        }

        //RFID event test

        [Test]
        public void HandleRFIDDetectedEvent_NotOccupiedDoorNotClosed_NoAction()
        {
            door.DoorOpenEvent += Raise.EventWith(new DoorOpenEventArgs());
            var args = new RFIDDetectedEventArgs();
            args.RFID = Arg.Any<int>();
            rfid.RFIDDetected += Raise.EventWith(args);

            chargeControl.DidNotReceive().StartCharge();
            chargeControl.DidNotReceive().StopCharge();
            msgFormatter.DidNotReceive().DisplayRFIDError();
            msgFormatter.DidNotReceive().DisplayConnectionError();
        }

        [Test]

        public void HandleRFIDDetectedEvent_NotOccupiedDoorClosedPhoneConnected_startChargeCalled()
        {
            //default initering giver denne opsætning
            chargeControl.Configure().IsConnected().Returns(true);
            var args = new RFIDDetectedEventArgs();


            args.RFID = Arg.Any<int>();
            rfid.RFIDDetected += Raise.EventWith(args);

            chargeControl.Received(1).StartCharge();
        }

        [Test]
        public void HandleRFIDDetectedEvent_NotOccupiedDoorClosedPhoneConnected_LockCalled()
        {
            //default initering giver denne opsætning
            chargeControl.Configure().IsConnected().Returns(true);
            var args = new RFIDDetectedEventArgs();


            args.RFID = Arg.Any<int>();
            rfid.RFIDDetected += Raise.EventWith(args);
            door.Received(1).Lock();
        }
        [Test]
        public void HandleRFIDDetectedEvent_NotOccupiedDoorClosedPhoneConnected_LogDoorLockedCalled()
        {
            //default initering giver denne opsætning
            chargeControl.Configure().IsConnected().Returns(true);
            var args = new RFIDDetectedEventArgs();


            args.RFID = 17;
            rfid.RFIDDetected += Raise.EventWith(args);

            logFile.Received(1).LogDoorLocked(17);
        }

        [Test]
        public void HandleRFIDDetectedEvent_NotOccupiedDoorClosedPhoneNotConnected_DisplayConnectionErrorCalled()
        {
            //default initering giver denne opsætning
            chargeControl.Configure().IsConnected().Returns(false);
            var args = new RFIDDetectedEventArgs();


            args.RFID = Arg.Any<int>();
            rfid.RFIDDetected += Raise.EventWith(args);

            msgFormatter.Received(1).DisplayConnectionError();
        }


        [Test]
        public void HandleRFIDDetectedEvent_OccupiedCorrectRFID_StopChargeCalled()
        {
            //default initering giver denne opsætning
            chargeControl.Configure().IsConnected().Returns(true);

            var args = new RFIDDetectedEventArgs();

            args.RFID = 17;
            rfid.RFIDDetected += Raise.EventWith(args);

            rfid.RFIDDetected += Raise.EventWith(args);

            chargeControl.Received(1).StopCharge();

        }
        [Test]
        public void HandleRFIDDetectedEvent_OccupiedCorrectRFID_LogDoorOpenCalled()
        {
            //default initering giver denne opsætning
            chargeControl.Configure().IsConnected().Returns(true);

            var args = new RFIDDetectedEventArgs();

            args.RFID = 17;
            rfid.RFIDDetected += Raise.EventWith(args);

            rfid.RFIDDetected += Raise.EventWith(args);

            logFile.Received(1).LogDoorUnlocked(17);

        }
        [Test]
        public void HandleRFIDDetectedEvent_OccupiedCorrectRFID_UnlockCalled()
        {
            //default initering giver denne opsætning
            chargeControl.Configure().IsConnected().Returns(true);

            var args = new RFIDDetectedEventArgs();

            args.RFID = 17;
            rfid.RFIDDetected += Raise.EventWith(args);

            rfid.RFIDDetected += Raise.EventWith(args);

            door.Received(1).Unlock();

        }
        [Test]
        public void HandleRFIDDetectedEvent_OccupiedCorrectRFID_DisplayRemovePhoneCalled()
        {
            //default initering giver denne opsætning
            chargeControl.Configure().IsConnected().Returns(true);

            var args = new RFIDDetectedEventArgs();

            args.RFID = 17;
            rfid.RFIDDetected += Raise.EventWith(args);

            rfid.RFIDDetected += Raise.EventWith(args);

            msgFormatter.Received(1).DisplayRemovePhone();

        }

        [Test]
        public void HandleRFIDDetectedEvent_OccupiedWrongRFID_DisplayRFIDErrorCalled()
        {
            //default initering giver denne opsætning
            chargeControl.Configure().IsConnected().Returns(true);

            var args = new RFIDDetectedEventArgs();

            args.RFID = 17;
            rfid.RFIDDetected += Raise.EventWith(args);

            args = new RFIDDetectedEventArgs();

            args.RFID = 16;
            rfid.RFIDDetected += Raise.EventWith(args);

            msgFormatter.Received(1).DisplayRFIDError();
            door.DidNotReceive().Unlock();

        }
    }
}
