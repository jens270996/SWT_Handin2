using System;
using System.Collections.Generic;
using System.Text;

namespace ChargeLocker
{
    

    public class StationControl
    {
        private IDoor door;
        private IRfidReader rfidReader;
        private IMessageFormatter messageFormatter;
        private IChargeControl chargeControl;
        private ILogFile logFile;
        private int rfid;

        public  StationControl(IDoor Door,IRfidReader RFIDReader,)
    }
}
