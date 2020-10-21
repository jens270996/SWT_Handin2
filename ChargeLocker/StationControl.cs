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
        private bool occupied;

        public  StationControl(IDoor Door,IRfidReader RFIDReader,IMessageFormatter messageFormatter,IChargeControl chargeControl,ILogFile logFile)
        {
            door = Door;
            rfidReader = RFIDReader;
            this.messageFormatter = messageFormatter;
            this.chargeControl = chargeControl;
            this.logFile = logFile;
            occupied = false;
            //register to events
            this.rfidReader.RFIDDetected += HandleRFIDDetectedEvent;
            this.door.DoorOpenEvent += HandleDoorOpenEvent;
            this.door.DoorCloseEvent += HandleDoorCloseEvent;
        }

        private void HandleDoorCloseEvent(object? sender, DoorCloseEventArgs e)
        {
            throw new NotImplementedException();
        }


        private void HandleDoorOpenEvent(object? sender, DoorOpenEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void HandleRFIDDetectedEvent(object sender, RFIDDetectedEventArgs e)
        {
            
        }
    }
}
