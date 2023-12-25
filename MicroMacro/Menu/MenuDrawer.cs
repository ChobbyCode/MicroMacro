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
                    Console.WriteLine();
                    Console.WriteLine("---Macros---");
                    Console.WriteLine();
                    Console.WriteLine("(1) - Quick Macro");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("(2) - Run a .mc File");
                    Console.WriteLine("(3) - Create a .mc File");
                    Console.WriteLine("(4) - Supported Application Settings & Supported Application Presets(.mc) ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine("---Settings & Other---");
                    Console.WriteLine();
                    Console.WriteLine("(5) - Settings");
                    Console.WriteLine("(6) - Changelog");
                    Console.WriteLine("(x) - Exit");
                    Console.WriteLine();
                    break;
            }
        }
    }
}
