using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroFileWriter.Files
{
    public class FolderManager
    {
        public bool FolderExists(string path)
        {
            if (Directory.Exists(path)) return true;
            else return false;
        }

        public bool CreateFolder(string path)
        {
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path); 
                return true;
            }
            else return false;
        }
    }
}
