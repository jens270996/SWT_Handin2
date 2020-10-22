using System;

namespace ChargeLocker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Assemble your system here from all the classes
            var door=new DoorSimulator();
            var rfidReader= new RFIDReaderSimulator();
            var displayer = new ConsoleDisplayer();
            var msgFormatter = new MessageFormatter(displayer);
            var usbCharger = new UsbChargerSimulator();
            var chargeControl = new ChargeControl(usbCharger,msgFormatter);
            var log= new LogFile();
            var stationControl = new StationControl(door,rfidReader,msgFormatter,chargeControl,log);

            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E, O, C, R: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        door.SimulateDoorOpen();
                        break;

                    case 'C':
                        door.SimulateDoorClosed();
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        rfidReader.SimulateScan(id);
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }
    }
}


