namespace ChargeLocker
{
    public interface IChargeControl
    {
        void startCharge();
        void StopCharge();
        bool IsConnected();
    }
}