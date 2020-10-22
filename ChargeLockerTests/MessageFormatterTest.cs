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
    }
}
