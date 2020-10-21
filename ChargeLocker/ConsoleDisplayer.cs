using System;
using System.Collections.Generic;
using System.Text;

namespace ChargeLocker
{
    public class ConsoleDisplayer:IDisplayer
    {
        public void PrintMessage(string s)
        {
            Console.WriteLine(s);
        }
    }
}
