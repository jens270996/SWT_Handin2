using System;

namespace ChargeLocker
{
    public class RFIDDetectedEventArgs : EventArgs
    {
        public int RFID { get; set; }
    }
    public interface IRfidReader
    {
        public event EventHandler<RFIDDetectedEventArgs> RFIDDetected ;
    }
}