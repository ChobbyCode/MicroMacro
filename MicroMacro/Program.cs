// Copyright (c) 2023 ChobbyCode

using System.Linq;
using System;
using MicroMacro;
using MicroMacro.Menu;

namespace MicroMacroConsole
{
    public class Program
    {
        public static Menu Menu = 0;

        public static void Main(string[] args)
        {
            Console.Title = "MicroMacro v1.1.0 | Copyright (c) 2023 ChobbyCode";

            MainRenderLoop();
        }

        public static void MainRenderLoop()
        {
            while (Menu != Menu.ExitApplication)
            {
                Console.Clear();
                MenuDrawer.DrawMenu(Menu);

                var input = Console.ReadLine();
                Menu = MenuLogic.GetNewMenu(Menu, input);
            }
        }
    }
}