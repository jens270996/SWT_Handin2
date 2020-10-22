using System;
using System.Collections.Generic;
using System.Text;

namespace ChargeLocker
{
    public class DoorSimulator:IDoor
    {
        public event EventHandler<DoorCloseEventArgs> DoorCloseEvent;
        public event EventHandler<DoorOpenEventArgs> DoorOpenEvent;
        public bool locked { get; private set; }
        public void Lock()
        {
            if (locked == false)
                locked = true;
        }

        public void Unlock()
        {
            if (locked == true)
                locked = false;
        }

        public void SimulateDoorOpen()
        {
            OnDoorOpen();
        }

        public void SimulateDoorClosed()
        {
            OnDoorClose();
        }

        private void OnDoorOpen()
        {
            DoorOpenEvent?.Invoke(this,new DoorOpenEventArgs());
        }

        private void OnDoorClose()
        {
            DoorCloseEvent?.Invoke(this,new DoorCloseEventArgs());
        }


    }
}
