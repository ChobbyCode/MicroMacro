// Copyright (c) 2023 ChobbyCode

using System.Linq;
using System;
using MicroMacro;
using MicroMacro.Menu;
using MicroFileWriter.Settings;
using MicroUpdatorClient;
using System.Diagnostics;

namespace MicroMacroConsole
{
    public class Program
    {
        public static Menu Menu = 0;
        public static string BaseDir = AppDomain.CurrentDomain.BaseDirectory;

        public static string Version = "v1.1.2";

        public static async Task Main(string[] args)
        {
            Console.Title = $"MicroMacro {Version} | Copyright (c) 2023 ChobbyCode";

            SettingsManager settingsManager = new SettingsManager();

            Console.WriteLine("Checking for updates...");
            Updator _uD = new Updator();
            bool update = _uD.CheckForUpdates();

            if (!update) MainRenderLoop();
            else
            {
                try
                {
                    string[] UdArgs =
                    {
                        "true",
                        BaseDir,
                    };
                    Process.Start(BaseDir + @"\Updator.exe", UdArgs);
                }
                catch
                {
                    Console.WriteLine("");
                    Console.WriteLine("Failed to start updater..");
                    Console.WriteLine("Please manually download the update from: ");
                    Console.WriteLine("https://github.com/ChobbyCode/MicroMacro/releases/tag/MicroMacro-Installer");
                    Console.ReadLine();
                }
            }
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