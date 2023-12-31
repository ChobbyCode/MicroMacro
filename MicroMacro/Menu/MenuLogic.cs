// Copyright (c) 2023 ChobbyCode

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            switch (menu)
            {
                case Menu.Home:
                    return HomeMenuLogic(input);
                case Menu.SmartMacroHome:
                    return SmartMacroMenuLogic(input);
                default:
                    return Menu.Home;
            }
        }

        private static Menu HomeMenuLogic(string input)
        {
            switch (input.ToLower())
            {
                case "x":
                    return Menu.ExitApplication;
                case "1":
                    return Menu.QuickMacro;
                case "2":
                    return Menu.SmartMacroHome;
                case "5":
                    Process.Start("notepad.exe", $"{MicroFileWriter.Settings.SettingsManager.SettingsLocation}");
                    return Menu.SettingsMSG;
                case "6":
                    return Menu.Changelog;
                default:
                    return Menu.Home;
            }
        }

        private static Menu SmartMacroMenuLogic(string input)
        {
            switch(input.ToLower())
            {
                case "1":
                    MicroFileType.FileType.CreateMacro _cM = new MicroFileType.FileType.CreateMacro();
                    _cM.OpenCreateMacroWindow();
                    return Menu.SmartMacroHome;
                case "2":
                    MicroFileType.FileType.OpenMacro _oM = new MicroFileType.FileType.OpenMacro();
                    _oM.OpenOpenMacroWindow();
                    return Menu.SmartMacroHome;
                default:
                    return Menu.Home;
            }
        }
    }
}
