using MicroFileWriter.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroFileWriter
{
    public class FileManager
    {
        // Will pull from a directory so install where you want
        public string WriteInfoFolder = @"C:\Program Files\MicroMacro";
        FileManager _fm;
        FolderManager _dm;

        public void InitializeApplication()
        {
            _fm = new();
            _dm = new();
            // Create the folder for the application. Will be done in the installer in the future, so never get called.
            if(!_dm.FolderExists(WriteInfoFolder)) _dm.CreateFolder(WriteInfoFolder);
            if(!_dm.FolderExists(WriteInfoFolder+@"\Settings\")) _dm.CreateFolder(WriteInfoFolder+@"\Settings\");
        }
    }
}
