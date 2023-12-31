﻿// Copyright (c) 2023 ChobbyCode

using IWshRuntimeLibrary;
using MicroMacroInstaller;
using System.Diagnostics;

namespace MicroMacro.Installer
{
    public class Program
    {

        public static bool isBeta = false;

        public static void Main(string[] args)
        {
            Console.Clear();
            Console.Title = "MicroMacro Updater";

            try
            {
                if (args[0] == "true") AutoUpdate(args[1]);
            }
            catch (Exception ex)
            {
                UserInstall();
            }
            Console.ReadLine();
        }

        public static void AutoUpdate(string installDrive)
        {
            Console.WriteLine("Installing");
            FileDownloader fd = new FileDownloader();
            fd.DownloadFiles();

            InstallApp(installDrive);
            Console.ReadLine();
        }

        public static void UserInstall()
        {
            try
            {
                string installDrive = GetInstallDrive();
                if (!Directory.Exists(installDrive + @"\Program Files\"))
                    Directory.CreateDirectory(installDrive + @"\Program Files\");
                if (!Directory.Exists(installDrive + @"\Program Files\MicroMacro\"))
                    Directory.CreateDirectory(installDrive + @"\Program Files\MicroMacro\");
                bool _dS = AskDesktopShortcut();
                bool _sS = AskStartMenuShortcut();

                // Download Latest Versions
                FileDownloader fd = new FileDownloader();
                fd.DownloadFiles();

                InstallApp(installDrive + @"\Program Files\MicroMacro\");

                if (_dS)
                {
                    CreateDesktopShortcut(installDrive + @"\Program Files\MicroMacro\MicroMacro.exe");
                }
                if (_sS)
                {
                    CreateShortcut(installDrive + @"\Program Files\MicroMacro\MicroMacro.exe",
                     installDrive + @"\Program Files\MicroMacro\MicroMacro.lnk");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Installation Failed!");
                Console.WriteLine(ex);
            }
            Console.ReadLine();
        }

        public static bool AskDesktopShortcut()
        {
            bool correct = false;
            string answer = "";
            while (!correct)
            {
                Console.WriteLine();
                Console.Write("Would you like to add a desktop shortcut to the application? (y/n): ");
                answer = Console.ReadLine();
                if (answer.ToLower() == "n" || answer.ToLower() == "y") correct = true;
                else Console.WriteLine("Please Enter A Valid Answer");
            }
            if (answer.ToLower() == "y") return true;
            else  return false;
        }

        public static bool AskStartMenuShortcut()
        {
            bool correct = false;
            string answer = "";
            while (!correct)
            {
                Console.WriteLine();
                Console.Write("Would you like to add MicroMacro to your start menu? (y/n): ");
                answer = Console.ReadLine();
                if (answer.ToLower() == "n" || answer.ToLower() == "y") correct = true;
                else Console.WriteLine("Please Enter A Valid Answer");
            }
            if (answer.ToLower() == "y") return true;
            else return false;
        }

        public static void CreateDesktopShortcut(string ApplicationPath)
        {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\MicroMacro.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "MicroMacro is a free, opensource, text-macro creating software - created by ChobbyCode.";
            shortcut.TargetPath = ApplicationPath;
            shortcut.Save();
        }

        private static void CreateStartMenuShortcut(string ApplicationPath, string installDrive)
        {
            WshShell shell = new WshShell();
            string shortcutAddress = installDrive + @"\MicroMacro.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "MicroMacro is a free, opensource, text-macro creating software - created by ChobbyCode.";
            shortcut.TargetPath = ApplicationPath + @"\MicroMacro.exe";
            shortcut.Save();
        }

        public static string GetInstallDrive()
        {
            Console.WriteLine("Please Select An Install Drive From Below:");
            Console.WriteLine(@"The Application Will Be Installed On '[Drive]:\Program Files\MicroMacro\'");
            Console.WriteLine();

            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("Drive {0}", d.Name);
                Console.WriteLine("  Drive type: {0}", d.DriveType);
                if (d.IsReady == true)
                {
                    Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                    Console.WriteLine("  File system: {0}", d.DriveFormat);
                    Console.WriteLine(
                        "  Available space to current user:{0, 15} bytes",
                        d.AvailableFreeSpace);

                    Console.WriteLine(
                        "  Total available space:          {0, 15} bytes",
                        d.TotalFreeSpace);

                    Console.WriteLine(
                        "  Total size of drive:            {0, 15} bytes ",
                        d.TotalSize);
                }
            }

            bool correct = false;
            string drive = "";

            while (!correct) { 
                Console.WriteLine();
                Console.Write("Drive (Enter The Letter, i.e. 'A', 'D', 'C'): ");
                drive = Console.ReadLine();
                Console.Write($@"Is '{drive.ToUpper()}:\' correct? (y/n): ");
                var res = Console.ReadLine();
                if(res.ToLower() == "y")
                {
                    correct = true;
                }
            }
            return @$"{drive.ToUpper()}:\";
        }

        public static void InstallApp(string loc)
        {
            Console.Clear();
            Console.WriteLine("Copying Files...");
            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\Files\");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"Status            | File");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (string file in files)
            {
                FileInfo fI = new FileInfo(file);
                try
                {
                    System.IO.File.Copy(file, loc + @"\" + fI.Name, true);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Copy Item Success | {fI.Name}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Copy Item Failed  | {fI.Name}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine("Installation Complete.");
            Console.WriteLine("You can now either, click enter to automatically open the application, or close this window.");
            Console.ReadLine();
            Process.Start(loc + @"\MicroMacro.exe");
        }

        /// <summary>
        /// Create Windows Shorcut
        /// </summary>
        /// <param name="SourceFile">A file you want to make shortcut to</param>
        /// <param name="ShortcutFile">Path and shorcut file name including file extension (.lnk)</param>
        public static void CreateShortcut(string SourceFile, string ShortcutFile)
        {
            CreateShortcut(SourceFile, ShortcutFile, null, null, null, null);
        }

        /// <summary>
        /// Create Windows Shorcut
        /// </summary>
        /// <param name="SourceFile">A file you want to make shortcut to</param>
        /// <param name="ShortcutFile">Path and shorcut file name including file extension (.lnk)</param>
        /// <param name="Description">Shortcut description</param>
        /// <param name="Arguments">Command line arguments</param>
        /// <param name="HotKey">Shortcut hot key as a string, for example "Ctrl+F"</param>
        /// <param name="WorkingDirectory">"Start in" shorcut parameter</param>
        public static void CreateShortcut(string TargetPath, string ShortcutFile, string Description,
           string Arguments, string HotKey, string WorkingDirectory)
        {
            // Check necessary parameters first:
            if (String.IsNullOrEmpty(TargetPath))
                throw new ArgumentNullException("TargetPath");
            if (String.IsNullOrEmpty(ShortcutFile))
                throw new ArgumentNullException("ShortcutFile");

            // Create WshShellClass instance:
            var wshShell = new WshShellClass();

            // Create shortcut object:
            IWshRuntimeLibrary.IWshShortcut shorcut = (IWshRuntimeLibrary.IWshShortcut)wshShell.CreateShortcut(ShortcutFile);

            // Assign shortcut properties:
            shorcut.TargetPath = TargetPath;
            shorcut.Description = Description;
            if (!String.IsNullOrEmpty(Arguments))
                shorcut.Arguments = Arguments;
            if (!String.IsNullOrEmpty(HotKey))
                shorcut.Hotkey = HotKey;
            if (!String.IsNullOrEmpty(WorkingDirectory))
                shorcut.WorkingDirectory = WorkingDirectory;

            // Save the shortcut:
            shorcut.Save();
        }
    }
}