
using Newtonsoft.Json;
using System.Security.Principal;

namespace MicroUpdatorClient
{
    public class Updator
    {
        public static int AppVersion = 1;

        public bool CheckForUpdates()
        {
            FileDownloader _fd = new FileDownloader();
            _fd.DownloadFiles();

            string DownloadLocation = Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory + @"\tmp\dez\")[0];

            DirectoryInfo _dI = new DirectoryInfo(DownloadLocation);
            FileInfo _VersionInfoLoc = new FileInfo(_dI.FullName + @"\version.json");

            string VersionInfo = File.ReadAllText(_VersionInfoLoc.FullName);
            VersionInfo info = JsonConvert.DeserializeObject<VersionInfo>(VersionInfo);

            if (info.Version > AppVersion)
            {
                return true;
            }
            return false;
        }
    }
}
