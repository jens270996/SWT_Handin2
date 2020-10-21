namespace ChargeLocker
{
    public interface ILogFile
    {
        public void LogDoorLocked(int rfid);
        public void LogDoorUnlocked(int rfid);

    }
}