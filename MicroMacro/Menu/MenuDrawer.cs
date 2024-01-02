// Copyright (c) 2023 ChobbyCode

using KeySender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroMacro;
using MicroMacroConsole;
using MicroFileType.FileType;

namespace MicroMacro.Menu
{
    public class MenuDrawer
    {
        public static void DrawMenu(Menu Menu)
        {
            switch(Menu)
            {
                case 0:
                    Console.WriteLine($"MicroMacro {Program.Version} based on https://github.com/ChobbyCode/MacroCreator");
                    Console.WriteLine("Copyright (c) 2023-2024 ChobbyCode");
                    Console.WriteLine();
                    Console.WriteLine("---Macros---");
                    Console.WriteLine();
                    Console.WriteLine("(1) - Quick Macro");
                    Console.WriteLine("(2) - Smart Macro");
                    Console.WriteLine();
                    Console.WriteLine("---Settings & Other---");
                    Console.WriteLine();
                    Console.WriteLine("(5) - Settings");
                    Console.WriteLine("(6) - Changelog");
                    Console.WriteLine("(x) - Exit");
                    Console.WriteLine();
                    break;
                case Menu.QuickMacro:
                    Console.WriteLine($"Please Note {Program.Version} MicroMacro is a port of v1.0.0 MacroCreator, they don't have the same features.");
                    Console.WriteLine();
                    Console.Write("Macro Text: ");
                    var text = Console.ReadLine();
                    Console.Write("Repeat: ");
                    var repeat = 0;
                    try
                    {
                        repeat = Convert.ToInt32(Console.ReadLine());
                    } catch
                    {
                        Console.WriteLine("Please enter a valid number");
                        return;
                    }
                    Console.WriteLine($"Please Wait 5 Seconds, for the string '{text}' to be repeated {repeat} times.");
                    Thread.Sleep(5000);
                    Sender Sender = new Sender();
                    Sender.SendMultiString(text, repeat);
                    break;
                case Menu.Changelog:
                    string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                    try
                    {
                        string[] Changelog = File.ReadAllLines($@"{baseDir}\CHANGELOG.txt");
                        foreach(string l in Changelog)
                        {
                            Console.WriteLine($"{l}");
                        }
                    }
                    catch
                    {
                        Console.WriteLine();
                        Console.WriteLine("Failed to open changelog. You can open it here -> 'https://github.com/ChobbyCode/MicroMacro/blob/master/MicroMacro/CHANGELOG.txt'");
                        Console.WriteLine();
                    }
                    break;
                case Menu.SettingsMSG:
                    Console.WriteLine("Please Restart The Application After Modifying The Settings File, For Changes To Take Place.");
                    break;
                case Menu.SmartMacroHome:
                    Console.WriteLine();
                    Console.WriteLine("---Smart Macro---");
                    Console.WriteLine();
                    Console.WriteLine("(1) - Create New Smart Macro");
                    Console.WriteLine("(2) - Run Smart Macro");
                    Console.WriteLine();
                    Console.WriteLine("(x) - Return");
                    break;
            }
        }
    }
}
