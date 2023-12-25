using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroFileWriter.Files
{
    public class FileManager
    {
        public bool FileExists(string path)
        {
            if (File.Exists(path)) return true;
            else return false;
        }

        public bool CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
                return true;
            }
            else return false;
        }
    }
}
