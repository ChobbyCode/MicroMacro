using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using MicroFileWriter.Settings.Models;
using Newtonsoft.Json;

namespace MicroFileWriter.Settings
{
    public class SettingsManager
    {
        public static string BaseDir = AppDomain.CurrentDomain.BaseDirectory;

        public SettingsManager()
        {
            if(!File.Exists(BaseDir + @"\Settings\config.json")) SetupSettings();
        }

        private void SetupSettings()
        {
            // Create the settings folder if they don't exist
            CreateFolder(BaseDir + @"\Settings\");
            CreateFile(BaseDir + @"\Settings\config.json");

            Models.Settings settings = new();
            settings.LiteMode = false;
            settings.MacroAutoEnter = true;
            
            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);

            WriteFile(BaseDir + @"\Settings\config.json",
                        json);
        }

        private void WriteFile(string path, string content)
        {
            StreamWriter _sw = new(path);
            try
            {
                _sw.WriteAsync(content);
            }
            catch
            {

            }finally
            {
                _sw.Close();
            }
        }

        private void CreateFolder(string path)
        {
            if (Directory.Exists(path)) return;
            else Directory.CreateDirectory(path);
        }

        private void CreateFile(string path)
        {
            try
            {
                FileStream _fs = new(path, FileMode.CreateNew);
                _fs.Close();
            }
            catch
            {

            }
        }
    }
}
