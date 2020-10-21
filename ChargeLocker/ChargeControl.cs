namespace ChargeLocker
{
    public class ChargeControl : IChargeControl
    {
        public void startCharge()
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

        private IUSBCharger USBCharger;
        private IMessageFormatter messageFormatter;

    }
}