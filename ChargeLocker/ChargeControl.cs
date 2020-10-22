using System;

namespace ChargeLocker
{
    public class ChargeControl : IChargeControl
    {
        private IUsbCharger USBCharger;
        private IMessageFormatter messageFormatter;

        public ChargeControl(IUsbCharger usbCharger, IMessageFormatter formatter)
        {
            USBCharger = usbCharger;
            USBCharger.CurrentValueEvent += HandleCurrentEvent;
            messageFormatter = formatter;
        }

        private void HandleCurrentEvent(object sender, CurrentEventArgs e)
        {
            messageFormatter.DisplayCurrentChange(e.Current);
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
    }
}