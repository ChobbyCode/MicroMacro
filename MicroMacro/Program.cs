// Copyright (c) 2024 ChobbyCode

using System.Linq;
using System;
using MicroMacro;
using MicroMacro.Menu;
using MicroFileWriter.Settings;
using MicroUpdatorClient;
using System.Diagnostics;
using Microsoft.Win32;
using System.Reflection;
using MicroFileType.FileType;
using Newtonsoft.Json;
using MicroMacro.Sdk;
using Windows.Foundation.Collections;

namespace MicroMacroConsole
{
    public class Program
    {
        public static Menu Menu = 0;
        public static string BaseDir = AppDomain.CurrentDomain.BaseDirectory;

        public static string Version = "v1.3.0";
        public static bool isBeta = false;

        // plugins -- Disabled on start by default due to security reasons
        public static void Main(string[] args)
        {
            // Load Settings Stuff
            SettingsManager settingsManager = new SettingsManager();

            // Begin To Load Plugins. Plugins Should Only Be Loaded If Experimental Features & Plugins Are Enabled In The Settings
            // And The Version Is Set To Being A Beta
            if(SettingsManager.Settings.UseExperimentalFeatures == true && SettingsManager.Settings.UsePlugins == true && isBeta == true) PluginManager.InitPlugins();

            Console.Title = $"MicroMacro {Version} | Copyright (c) 2023-2025 ChobbyCode";

            UpdateCheck();
        }

        // Checks For Update, If Not Push To Main Render Loop
        private static void UpdateCheck() {
            bool update = false;
            if (!isBeta) {
                Console.WriteLine("Checking for updates...");
                Updator _uD = new Updator();
                update = _uD.CheckForUpdates();
            }

            if (!update) MainRenderLoop();
            else {
                try {
                    string[] UdArgs =
                    {
                    "true",
                    BaseDir,
                };
                    Process.Start(BaseDir + @"\Updator.exe", UdArgs);
                }
                catch {
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

                var input = Console.ReadKey();
                Menu = MenuLogic.GetNewMenu(Menu, input);
            }
        }

    }
}
