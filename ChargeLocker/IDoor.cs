using System;

namespace ChargeLocker
{
    public class DoorOpenEventArgs : EventArgs
    {
        
    }
    public class DoorCloseEventArgs : EventArgs
    {

    }
    public interface IDoor
    {
        public event EventHandler<DoorCloseEventArgs> DoorCloseEvent;
        public event EventHandler<DoorOpenEventArgs> DoorOpenEvent;
        public void Lock();
        public void Unlock();
    }
}