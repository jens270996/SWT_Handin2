using System;

namespace ChargeLocker
{
    public class ChargeControl : IChargeControl
    {
        public ChargeControl(IUsbCharger usbCharger)
        {
            USBCharger = usbCharger;
        }
        public void StartCharge()
        {
            USBCharger.StartCharge();
        }

        public void StopCharge()
        {
            USBCharger.StopCharge();
        }

        public bool IsConnected()
        {
            return USBCharger.Connected;
        }

        private IUsbCharger USBCharger;
        private IMessageFormatter messageFormatter;

    }
}