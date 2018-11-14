using System;
using System.IO;

namespace WindowsTestService.Services
{
    public class ConverterService
    {
        private FileSystemWatcher _systemWatcher;

        public bool Start()
        {
            _systemWatcher = new FileSystemWatcher($"{AppDomain.CurrentDomain.BaseDirectory}/Files", "*_in.txt")
            {
                IncludeSubdirectories = false, EnableRaisingEvents = true
            };

            _systemWatcher.Created += _systemWatcher_Created;

            return true;
        }



        public bool Stop()
        {
           _systemWatcher.Dispose();
            return true;
        }

        private void _systemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            var content = File.ReadAllText(e.FullPath);
            var upperContent = content.ToUpperInvariant();

            var dir = Path.GetFileName(e.FullPath);

            var convertedFileName = Path.GetFileName(e.FullPath) + "CONVERTED";
          var  convertedPath = Path.Combine(dir, convertedFileName);
            File.WriteAllText(convertedPath,upperContent);
        }
    }
}