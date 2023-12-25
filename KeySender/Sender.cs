using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

namespace KeySender
{
    public class Sender
    {
        InputSimulator isim;

        public Sender()
        {
            // Sets up the Input Simulator for use
            isim = new InputSimulator();
        }

        public void SendKey(string key)
        {
            try
            {

            }
            catch
            {
                Console.WriteLine($"Failed to send key - {key} -");
            }
        }
    }
}
