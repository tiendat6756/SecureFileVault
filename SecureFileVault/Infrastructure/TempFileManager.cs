using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;

namespace SecureFileVault.Infrastructure
{
    public class TempFileManager
    {
        private string _tempFolder;
        private List<string> _openedFiles;

        public TempFileManager(string tempFolder)
        {
            _tempFolder = tempFolder;
            _openedFiles = new List<string>();

            if(!Directory.Exists(_tempFolder))
            {
                Directory.CreateDirectory(_tempFolder);
            }
        }

        public string CreateTempFile(string fileName, byte[] data)
        {
            string uniqueName = Guid.NewGuid().ToString() + "_" +fileName;
            string path = Path.Combine(_tempFolder, uniqueName);
            File.WriteAllBytes(path, data);
            _openedFiles.Add(path);
            return path;
        }

        public void OpenFile(string path)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true,
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot open file: " + ex.Message);
            }
            
        }

        public void Cleanup()
        {
            foreach(var file in _openedFiles)
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
            _openedFiles.Clear();
        }
    }
}
