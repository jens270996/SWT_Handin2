namespace ChargeLocker
{
    public interface IMessageFormatter
    {
        public void DisplayEnterRFID();
        public void DisplayConnect();
        public void DisplayConnectionError();
        public void DisplayRFIDError();
        public void DisplayOccupied();
        public void DisplayRemovePhone();

        public void DisplayCurrentChange(double current);
    }
}