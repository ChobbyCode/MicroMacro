// Copyright (c) 2023 ChobbyCode

using System.Linq;
using System;
using MicroMacro;
using MicroMacro.Menu;

namespace MicroMacroConsole
{
    public class Program
    {
        public static bool RunApplication = true;
        public static Menu Menu = 0;

        public static void Main(string[] args)
        {
            Console.Title = "MicroMacro v1.0.0 | Copyright (c) 2023 ChobbyCode";

            Console.WriteLine("MicroMacro v1.0.0 based on https://github.com/ChobbyCode/MacroCreator");
            Console.WriteLine("Copyright (c) 2023 ChobbyCode");

            MainRenderLoop();
        }

        public static void MainRenderLoop()
        {
            while (RunApplication)
            {
                MenuDrawer.DrawMenu(Menu);
            }
        }
    }
}