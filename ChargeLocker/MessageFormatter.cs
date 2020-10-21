using System;
using System.Collections.Generic;
using System.Text;

namespace ChargeLocker
{
    public class MessageFormatter:IMessageFormatter

    {
        private IDisplayer displayer;

        public MessageFormatter(IDisplayer disp)
        {
            displayer = disp;
        }
        public void DisplayEnterRFID()
        {
            displayer.PrintMessage("Indlæs RFID");
        }

        public void DisplayConnect()
        {
            displayer.PrintMessage("Tilslut telefon");
        }

        public void DisplayConnectionError()
        {
            displayer.PrintMessage("Tilslutningsfejl");
        }

        public void DisplayRFIDError()
        {
            displayer.PrintMessage("RFID fejl");
        }

        public void DisplayOccupied()
        {
            displayer.PrintMessage("Ladeskab optaget");
        }

        public void DisplayRemovePhone()
        {
            displayer.PrintMessage("Fjern telefon");
        }

        public void DisplayCurrentChange(double current)
        {
            displayer.PrintMessage($"New current: {current}");
        }
    }
}
