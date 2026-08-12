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
            if (!Directory.Exists(_tempFolder))
            {  
                return; 
            }
            foreach(var file in Directory.GetFiles(_tempFolder))
            {
                try
                {
                    File.Delete(file);
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Could not delete temporary file: {file}. {ex.Message}");
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine($"Access denied when deleting temporary file: {file}. {ex.Message}");
                }
            }
            _openedFiles.Clear();
        }
    }
}
