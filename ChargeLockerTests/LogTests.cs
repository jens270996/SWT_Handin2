using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ChargeLocker;
using NUnit.Framework;

namespace ChargeLockerTests
{
    public class LogTests
    {
        private string file = @"\logTest.txt";
        private LogFile _uut;

        public LogTests()
        {
            file = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + file;
        }

        [SetUp]
        public void SetUp()
        {
            
            _uut = new LogFile(file);
            if (File.Exists(file))
                File.Delete(file);
        }

        [TestCase(17)]
        [TestCase(-17)]
        [TestCase(0)]

        public void LogDoorLocked_CorrectRFID(int a)
        {
            _uut.LogDoorLocked(a);
            string res;
            using (var sw=File.OpenRead(file))
            {
                byte[] reBytes = new byte[256];
                sw.Read(reBytes, 0, 256);
                res= Encoding.Default.GetString(reBytes);

            }

            Assert.That(res.Contains($"{a}"));
        }

        [Test]
        public void LogDoorLocked_MultipleEntriesWithCorrectRFIDS()
        {
            _uut.LogDoorLocked(17);
            _uut.LogDoorLocked(16);
            string res;
            using (var sw = File.OpenRead(file))
            {
                byte[] reBytes = new byte[256];
                sw.Read(reBytes, 0, 256);
                res = Encoding.Default.GetString(reBytes);

            }

            string[] lines=res.Split(Environment.NewLine);
            Assert.That(lines[0].Contains($"{17}"));
            Assert.That(lines[1].Contains($"{16}"));
        }


        [TestCase(17)]
        [TestCase(-17)]
        [TestCase(0)]

        public void LogDoorUnLocked_CorrectRFID(int a)
        {
            _uut.LogDoorUnlocked(a);
            string res;
            using (var sw = File.OpenRead(file))
            {
                byte[] reBytes = new byte[256];
                sw.Read(reBytes, 0, 256);
                res = Encoding.Default.GetString(reBytes);

            }

            Assert.That(res.Contains($"{a}"));
        }

        [Test]
        public void LogDoorUnLocked_MultipleEntriesWithCorrectRFIDS()
        {
            _uut.LogDoorUnlocked(17);
            _uut.LogDoorUnlocked(16);
            string res;
            using (var sw = File.OpenRead(file))
            {
                byte[] reBytes = new byte[256];
                sw.Read(reBytes, 0, 256);
                res = Encoding.Default.GetString(reBytes);

            }

            string[] lines = res.Split(Environment.NewLine);
            Assert.That(lines[0].Contains($"{17}"));
            Assert.That(lines[1].Contains($"{16}"));
        }

        [Test]
        public void Log_MultipleLogWrites_ContainsCorrectNoOfEntries()
        {
            _uut.LogDoorUnlocked(17);
            _uut.LogDoorUnlocked(17);
            _uut.LogDoorUnlocked(17);
            _uut.LogDoorLocked(16);
            _uut.LogDoorLocked(16);
            _uut.LogDoorLocked(16);
            string res;
            using (var sw = File.OpenRead(file))
            {
                byte[] reBytes = new byte[256];
                sw.Read(reBytes, 0, 256);
                res = Encoding.Default.GetString(reBytes);

            }
            string[] lines = res.Split(Environment.NewLine);
            Assert.That(lines.Length, Is.EqualTo(6));
        }

    }
}
