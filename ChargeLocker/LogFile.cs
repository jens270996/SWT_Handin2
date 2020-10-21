using System;
using System.Collections.Generic;
using System.Text;

namespace ChargeLocker
{
    public class LogFile:ILogFile
    {
        private string file;
        public LogFile(string filestring)
        {
            file = filestring;
        }
        public void LogDoorLocked(int rfid)
        {
            String logmsg = $"Door locked at {DateTime.Now} by RFID {rfid}";
            System.IO.File.AppendText(file).WriteLine(logmsg);
        }

        public void LogDoorUnlocked(int rfid)
        {
            String logmsg = $"Door unlocked at {DateTime.Now} by RFID {rfid}";
            System.IO.File.AppendText(file).WriteLine(logmsg);
        }
    }
}
