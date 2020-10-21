using System;
using System.Collections.Generic;
using System.Text;

namespace ChargeLocker
{
    public class RFIDReaderSimulator:IRfidReader
    {
        public event EventHandler<RFIDDetectedEventArgs> RFIDDetected;

        public void SimulateScan(int RFID)
        {
            var args = new RFIDDetectedEventArgs() {RFID = RFID};
            OnRFIDScan(args);
        }

        private void OnRFIDScan(RFIDDetectedEventArgs e)
        {
            RFIDDetected?.Invoke(this,e);
        }
    }
}
