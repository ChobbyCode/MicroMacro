using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MicroMacroInstaller
{
    public class FileDownloader
    {
        public void DownloadFiles()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            string path = "https://github.com/ChobbyCode/Update-Checker" + @"/zipball/Download";
            Console.Write("Fetching Data From: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(path);
            Console.ForegroundColor = ConsoleColor.White;
            using (var client = new WebClient())
            {
                client.DownloadFile(path, baseDir + @"\Files\download.zip");
            }
        }
    }
}
