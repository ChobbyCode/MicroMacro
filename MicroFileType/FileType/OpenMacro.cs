using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroFileType.FileType
{
    public class OpenMacro
    {
        public void OpenOpenMacroWindow()
        {
            bool valid = false;
            while (!valid)
            {
                RenderWindow();
                Console.ReadLine();
            }
        }

        public void RenderWindow()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            string[] Recent = Directory.GetFiles(baseDir + @"\Macros\");
            string[] Recovery = Directory.GetFiles(baseDir + @"\Macros\tmp\");

            Console.Clear();

            if (Recent.Length == 0 && Recovery.Length == 0)
            {
                Console.WriteLine("Please create a macro before opening one.");
            }

            if (Recent.Length >= 1)
            {
                Console.WriteLine();
                Console.WriteLine("---Recent---");
                Console.WriteLine();

                for (int i = 0; i < Recent.Length; i++)
                {
                    FileInfo _fI = new FileInfo(Recent[i]);
                    Console.WriteLine($"({i}) - {_fI.Name}");
                }
            }

            if (Recovery.Length >= 1)
            {
                Console.WriteLine();
                Console.WriteLine("---Recovery---");
                Console.WriteLine();

                for (int i = 0; i < Recovery.Length; i++)
                {
                    FileInfo _fI = new FileInfo(Recovery[i]);
                    Console.WriteLine($"({i}) - {_fI.Name}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("(x) - Return");
            Console.WriteLine();
        }
    }
}
