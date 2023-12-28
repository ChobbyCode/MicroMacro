
using System.IO.Compression;
using System.Net;

namespace MicroUpdatorClient
{
    public class FileDownloader
    {
        public bool DownloadFiles()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            if (Directory.Exists(baseDir + @"\tmp\")) Directory.Delete(baseDir + @"\tmp\", true);
            if (!Directory.Exists(baseDir + @"\tmp\")) Directory.CreateDirectory(baseDir + @"\tmp\");
            if (!Directory.Exists(baseDir + @"\tmp\zip")) Directory.CreateDirectory(baseDir + @"\tmp\zip");
            if (!Directory.Exists(baseDir + @"\tmp\dez")) Directory.CreateDirectory(baseDir + @"\tmp\dez");

            string path = "https://github.com/ChobbyCode/MicroMacro" + @"/zipball/VersionInformation";

            using (var client = new WebClient())
            {
                client.DownloadFile(path, baseDir + @"\tmp\zip\download.zip");
            }

            ZipFile.ExtractToDirectory(baseDir + @"\tmp\zip\download.zip", baseDir + @"\tmp\dez\");

            return true;
        }
    }
}
