using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroFileType.FileType
{
    public class OpenMacro
    {
        public bool ShowRecoveryFile = false;

        public void OpenOpenMacroWindow()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            if (!Directory.Exists(baseDir + @"\Macros\")) Directory.CreateDirectory(baseDir + @"\Macros\");
            if (!Directory.Exists(baseDir + @"\Macros\tmp\")) Directory.CreateDirectory(baseDir + @"\Macros\tmp\");

            bool valid = false;
            while (!valid)
            {
                RenderWindow();
                string? input = Console.ReadLine();
                if (input == "x") valid = true;
                if (input == "y")
                {
                    if (ShowRecoveryFile) ShowRecoveryFile = false;
                    else ShowRecoveryFile = true;
                }
                ProcessInput(input);
            }
        }

        private bool ProcessInput(string? input)
        {
            if (input == null) return false;
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string[] Recent = Directory.GetFiles(baseDir + @"\Macros\");
                string[] Recovery = Directory.GetFiles(baseDir + @"\Macros\tmp\");

                int inputI = Convert.ToInt32(input);
                if (inputI > Recent.Length + Recovery.Length) return false;
                if (inputI > Recent.Length) RecoverySelect(inputI - Recent.Length + 1);
                if (inputI < Recent.Length + 1) RecentSelect(inputI - Recovery.Length + 1);

                return false;
            }catch (Exception ex)
            {
                Console.WriteLine("Invalid Input:");
                Console.WriteLine(ex);
                return false;
            }
        }

        private void RecentSelect(int input)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] Recent = Directory.GetFiles(baseDir + @"\Macros\");
            string[] Recovery = Directory.GetFiles(baseDir + @"\Macros\tmp\");

            // Read File
            FileInfo _fI = new FileInfo(Recent[input]);
            String file = File.ReadAllText(_fI.FullName);

            // Deserialize Object
            MacroFileType MFT = JsonConvert.DeserializeObject<MacroFileType>(file);

            bool valid = false;
            string option = String.Empty;

            while (!valid)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("(1) - Run Macro");
                Console.WriteLine("(2) - Edit Macro");
                Console.WriteLine("");
                Console.WriteLine("(x) - Return");

                option = Console.ReadLine();
                if(option == "1" || option == "2" || option == "x") valid = true;
            }
            if (option == "x") return;
            if(option == "1")
            {
                RunMacro _rM = new RunMacro(MFT);
            }
            if (option == "2")
            {
                CreateMacro _cM = new CreateMacro(MFT, _fI);
                _cM.OpenCreateMacroWindow();
            }
        }

        private void RecoverySelect(int input)
        {

        }

        private void RenderWindow()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            string[] Recent = Directory.GetFiles(baseDir + @"\Macros\");
            string[] Recovery = Directory.GetFiles(baseDir + @"\Macros\tmp\");

            Console.Clear();

            if (Recent.Length == 0 && Recovery.Length == 0)
            {
                Console.WriteLine("Please create a macro before opening one.");
            }

            int h = 0; // loop plus recent

            if (Recent.Length >= 1)
            {
                Console.WriteLine();
                Console.WriteLine("---Recent---");
                Console.WriteLine();

                for (int i = 0; i < Recent.Length; i++)
                {
                    FileInfo _fI = new FileInfo(Recent[i]);
                    Console.WriteLine($"({i + 1}) - {_fI.Name}");
                    h = i + 1;
                }
            }

            if (Recovery.Length >= 1)
            {
                Console.WriteLine();
                Console.WriteLine("---Recovery---");
                Console.WriteLine();

                if (ShowRecoveryFile == true) 
                {
                    for (int i = 0; i < Recovery.Length; i++)
                    {
                        FileInfo _fI = new FileInfo(Recovery[i]);
                        Console.WriteLine($"({i + h + 1}) - {_fI.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("There are recovery files available...");
                }
            }

            Console.WriteLine();
            Console.WriteLine("(x) - Return");
            if (Recovery.Length >= 1) Console.WriteLine("(y) - Toggle ShowRecoveryFiles");
            Console.WriteLine();
        }
    }
}
