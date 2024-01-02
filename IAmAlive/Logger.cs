using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAmAlive
{
    internal class Logger
    {

        private readonly string _appDir;
        private readonly string _logFile;
        private readonly long _maxFileSize = 536870912;

        public Logger(string appDir)
        {
            _appDir = appDir;
            _logFile = @$"{appDir}\i-am-alive.log";
        }

        public void Log( string message)
        {
            if (File.Exists(_logFile) && LogFileExeedsMaximum())
                ArchiveLogFile();

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            File.AppendAllText(_logFile, $"{timestamp} - {message}\n");
        }

        public bool LogFileExeedsMaximum()
        {
            try
            {
                long length = new FileInfo(_logFile).Length;

                return length > _maxFileSize;
            }
            catch (Exception e)
            {
                new CrashDumper(_appDir).Dunp(e.Message);

                return false;
            }
        }

        public void ArchiveLogFile()
        {
            try
            {
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                File.Move(_logFile, _logFile.Replace(".txt", $" - {timestamp}.txt"));
            }
            catch (Exception e)
            {
                new CrashDumper(_appDir).Dunp(e.Message);
            }
        }
    }
}
