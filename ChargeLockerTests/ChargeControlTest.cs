using System;
using System.Collections.Generic;
using System.Text;
using ChargeLocker;
using NSubstitute;
using NSubstitute.Extensions;
using NUnit;
using NUnit.Framework;

namespace ChargeLockerTests
{
    [TestFixture]
    class ChargeControlTest
    {
        private ChargeControl _uut;
        
        private IMessageFormatter _messageFormatter;
        private IUsbCharger _usbChargerSimulator;

        [SetUp]
        public void setup()
        {
            _messageFormatter = Substitute.For<IMessageFormatter>();
            
            _usbChargerSimulator = Substitute.For<UsbChargerSimulator>();
            _uut = new ChargeControl(_usbChargerSimulator, _messageFormatter);

        }

        [Test]
        public void CurrentChanged_EventFired_CurrentChanged()
        {
            var args = new CurrentEventArgs();
            args.Current = Arg.Any<double>();
            _usbChargerSimulator.CurrentValueEvent += Raise.EventWith(args);
            _messageFormatter.Received(1).DisplayCurrentChange(Arg.Any<double>());
        }

        [TestCase(750)]
        [TestCase(500)]
        [TestCase(2.5)]
        [TestCase(0)]
        [TestCase(6)]
        public void CurrentChanged_EventFired_CurrentChanged(double value)
        {
            var args = new CurrentEventArgs();
            args.Current = value;
            _usbChargerSimulator.CurrentValueEvent += Raise.EventWith(args);
            _messageFormatter.Received(1).DisplayCurrentChange(value);
        }

        [Test]
        public void StartCharge_FunctionCalled_UsbStartChargeCalled()
        {
            _uut.StartCharge();
            _usbChargerSimulator.Received(1).StartCharge();
        }

        [Test]
        public void StopCharge_FunctionCalled_UsbStopChargeCalled()
        {
            _uut.StopCharge();
            _usbChargerSimulator.Received(1).StopCharge();
        }

        [Test]
        public void IsConnected_FunctionCalled_ReturnsTrue()
        {
            _usbChargerSimulator.Connected.Returns(true);
            Assert.That(_uut.IsConnected(), Is.EqualTo(true));
        }
    }
}
