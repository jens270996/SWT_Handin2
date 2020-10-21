using System;
using System.Collections.Generic;
using System.Text;

namespace ChargeLocker
{
    public class DoorSimulator:IDoor
    {
        public event EventHandler<DoorCloseEventArgs> DoorCloseEvent;
        public event EventHandler<DoorOpenEventArgs> DoorOpenEvent;
        public void Lock()
        {
            Console.WriteLine("Door is locked");
        }

        public void Unlock()
        {
            Console.WriteLine("Door is unlocked");
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
