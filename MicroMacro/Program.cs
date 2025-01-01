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

        public static string Version = "v1.2.0";
        public static bool isBeta = false;

        public static void Main(string[] args)
        {
            Console.WriteLine("Reading Plugins...");
            _plugins = ReadExtensions();

            // Print
            foreach (var plugin in _plugins)
            {
                Console.WriteLine($"{plugin.Title} | {plugin.Description}");
            }
            foreach (var plugin in _plugins)
            {
                plugin.OnStart(new string[0]);
            }

            Plugins.InitPlugins();

            Console.Title = $"MicroMacro {Version} | Copyright (c) 2023-2025 ChobbyCode";

            SettingsManager settingsManager = new SettingsManager();

            bool update = false;
            if (!isBeta)
            {
                Console.WriteLine("Checking for updates...");
                Updator _uD = new Updator();
                update = _uD.CheckForUpdates();
            }

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

        static List<IPlugin> _plugins = null;

        static List<IPlugin> ReadExtensions()
        {
            var pluginsList = new List<IPlugin>();

            // i- read dll files from the extension folder
            var files = Directory.GetFiles("Plugins", "*.dll");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

            // ii- read assemblies from those files
            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), file));

                // iii- extract classes types that implement iplugin
                var pluginTypes = assembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t)).ToArray();

                foreach (var pluginType in pluginTypes)
                {
                    // iv - create instance from the extracted type
                    var pluginInstance = Activator.CreateInstance(pluginType) as IPlugin;
                    pluginsList.Add(pluginInstance);
                }
            }

            return pluginsList;
        }
    }
}
