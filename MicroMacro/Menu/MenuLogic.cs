// Copyright (c) 2023 ChobbyCode

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroMacro.Menu
{
    public class MenuLogic
    {
        public static Menu GetNewMenu(Menu menu, string? input)
        {
            if (input == null) return Menu.Home;
            switch(menu)
            {
                case Menu.Home:
                    return HomeMenuLogic(input);
                default:
                    return Menu.Home;
            }
        }

        private static Menu HomeMenuLogic(string input)
        {
            switch(input.ToLower())
            {
                case "x":
                    return Menu.ExitApplication;
                case "1":
                    return Menu.QuickMacro;
                case "6":
                    return Menu.Changelog; 
                default:
                    return Menu.Home;
            }
        }
    }
}
