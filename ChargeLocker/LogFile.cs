using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ChargeLocker
{
    public class LogFile:ILogFile
    {
        
        private string file = @"\log.txt";

        public LogFile()
        {
            file=Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + file;
        }
        public LogFile(string filePath)
        {
            file = filePath;
        }
        public void LogDoorLocked(int rfid)
        {
            String logmsg = $"Door locked at {DateTime.Now} by RFID {rfid}";
            using (var sw = File.AppendText(file))
            {
                
                sw.WriteLine(logmsg);
            }
        }
        public void LogDoorUnlocked(int rfid)
        {
            String logmsg = $"Door unlocked at {DateTime.Now} by RFID {rfid}";
            using (var sw=File.AppendText(file))
            {
                sw.WriteLine(logmsg);
            }
        }
    }
}
