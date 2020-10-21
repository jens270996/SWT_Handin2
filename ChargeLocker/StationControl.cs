using System;
using System.Collections.Generic;
using System.Text;

namespace ChargeLocker
{
    

    public class StationControl
    {
        private IDoor door;
        
        private IMessageFormatter messageFormatter;
        private IChargeControl chargeControl;
        private ILogFile logFile;
        private int rfid;
        private bool occupied;
        private bool doorClosed;

        public  StationControl(IDoor Door,IRfidReader RFIDReader,IMessageFormatter messageFormatter,IChargeControl chargeControl,ILogFile logFile)
        {
            door = Door;
            
            this.messageFormatter = messageFormatter;
            this.chargeControl = chargeControl;
            this.logFile = logFile;
            occupied = false;
            doorClosed = true;
            //register to events
            RFIDReader.RFIDDetected += HandleRFIDDetectedEvent;
            this.door.DoorOpenEvent += HandleDoorOpenEvent;
            this.door.DoorCloseEvent += HandleDoorCloseEvent;
        }

        private void HandleDoorCloseEvent(object sender, DoorCloseEventArgs e)
        {
            if (!doorClosed)
            {
                doorClosed = true;
                messageFormatter.DisplayEnterRFID();
            }

        }


        private void HandleDoorOpenEvent(object sender, DoorOpenEventArgs e)
        {
            if (!occupied && doorClosed)
            {
                doorClosed = false;
                messageFormatter.DisplayConnect();
            }
        }

        private void HandleRFIDDetectedEvent(object sender, RFIDDetectedEventArgs e)
        {
            if (occupied)//optaget
            {
                if (CheckId(e.RFID))//korrekt RFID
                {
                    chargeControl.StopCharge();
                    door.Unlock();
                    occupied = false;
                    messageFormatter.DisplayRemovePhone();
                }
                else //forkert RFID
                {
                    messageFormatter.DisplayRFIDError();
                }
            }
            else if (doorClosed)//hvis ikke optaget og dør er lukket
            {
                if (!chargeControl.IsConnected())
                {
                    messageFormatter.DisplayConnectionError();
                }
                else
                {
                    rfid = e.RFID;
                    chargeControl.StartCharge();
                    occupied = true;
                    door.Lock();
                    //log dør låst
                    messageFormatter.DisplayOccupied();
                }
            }
        }

        private bool CheckId(int rfid)
        {
            return this.rfid == rfid;
        }
    }
}
