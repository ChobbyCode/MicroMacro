// Copyright (c) 2023 ChobbyCode

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
                // Uses the simulator to send the key
                simulator.SimulateKey(key, isim);
            }
            catch
            {
                Console.WriteLine($"Failed to send key - {key} -");
            }
        }

        public void SendString(string text)
        {
            try
            {
                // Just loops through the text to send key
                foreach(char c in text)
                {
                    SendKey(c);
                    Thread.Sleep(50);
                }
            }catch
            {
                Console.WriteLine($"Failed to send string - {text} -");
            }
        }
        public void SendMultiString(string text, int repeat)
        {
            try
            {
                // Repeats as many times as it needs to
                for(int i = 0; i < repeat; i++)
                {
                    // Just calls the send string function
                    SendString(text);
                    if(MicroFileWriter.Settings.SettingsManager.Settings.MacroAutoEnter) isim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                }
            }
            catch
            {
                Console.WriteLine($"Failed to send string - {text} -");
            }
        }
    }
}
