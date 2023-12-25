using KeySender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroMacro.Menu
{
    public class MenuDrawer
    {
        public static void DrawMenu(Menu Menu)
        {
            switch(Menu)
            {
                case 0:
                    Console.WriteLine("MicroMacro v1.1.0 based on https://github.com/ChobbyCode/MacroCreator");
                    Console.WriteLine("Copyright (c) 2023 ChobbyCode");
                    Console.WriteLine();
                    Console.WriteLine("---Macros---");
                    Console.WriteLine();
                    Console.WriteLine("(1) - Quick Macro");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[Legacy Feature] (2) - Run a .mc File");
                    Console.WriteLine("[Legacy Feature] (3) - Create a .mc File");
                    Console.WriteLine("[Legacy Feature] (4) - Supported Application Settings & Supported Application Presets(.mc) ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine("---Settings & Other---");
                    Console.WriteLine();
                    Console.WriteLine("(5) - Settings");
                    Console.WriteLine("(6) - Changelog");
                    Console.WriteLine("(x) - Exit");
                    Console.WriteLine();
                    break;
                case Menu.QuickMacro:
                    Console.WriteLine("Please Note v1.1.0 MicroMacro is a port of v1.0.0 MacroCreator, they don't have the same features.");
                    Console.WriteLine();
                    Console.Write("Macro Text: ");
                    var text = Console.ReadLine();
                    Console.Write("Repeat: ");
                    var repeat = 0;
                    try
                    {
                        repeat = Convert.ToInt32(Console.ReadLine());
                    } catch
                    {
                        Console.WriteLine("Please enter a valid number");
                        return;
                    }
                    Console.WriteLine("Please Wait 5 Seconds, for the string '{text}' to be repeated {repeat} times.");
                    Thread.Sleep(5000);
                    Sender Sender = new Sender();
                    Sender.SendMultiString(text, repeat);
                    break;
            }
        }
    }
}
