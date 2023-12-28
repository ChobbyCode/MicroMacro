// Copyright (c) 2023 ChobbyCode

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

namespace MicroMacroConsole
{
    public class Program
    {
        public static Menu Menu = 0;
        public static string BaseDir = AppDomain.CurrentDomain.BaseDirectory;

        public static string Version = "v1.2.0";
        public static bool isBeta = true;

        public static void Main(string[] args)
        {
            try
            {
                FileInfo _fI = new FileInfo(args[0]);

                if (_fI.Extension == ".macro")
                {
                    string text = File.ReadAllText(_fI.FullName);
                    MacroFileType MFT = JsonConvert.DeserializeObject<MacroFileType>(text);

                    MicroFileType.FileType.CreateMacro _cM = new MicroFileType.FileType.CreateMacro(MFT);
                    _cM.OpenCreateMacroWindow();
                }
                else
                {

                }
                Console.ReadLine();
            }
            catch (Exception ex) 
            {
                Console.Title = $"MicroMacro {Version} | Copyright (c) 2023 ChobbyCode";
                AddAsSuggestedApp();

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
        }

        public static void AddAsSuggestedApp()
        {
            // Adds as a suggested popup for the .macro extension when people click on open with for .macro
            var Key = Registry.ClassesRoot.OpenSubKey(".macro");
            var Type = Key.GetValue("");
            String myExecutable = Assembly.GetEntryAssembly().Location;
            String command = "\"" + myExecutable + "\"" + " \"%1\"";
            String keyName = Type + @"\shell\Open\command";
            using (var key = Registry.ClassesRoot.CreateSubKey(keyName))
            {
                key.SetValue("", command);
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