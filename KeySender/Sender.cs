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
        SimulatorCaller simulator;

        public Sender()
        {
            // Sets up the Input Simulator for use
            isim = new InputSimulator();
            // We pass the isim into the caller as this does it
            simulator = new SimulatorCaller();
        }

        public void SendKey(char key)
        {
            try
            {
                simulator.SimulateKey(key, isim);
            }
            catch
            {
                Console.WriteLine($"Failed to send key - {key} -");
            }
        }
    }
}
