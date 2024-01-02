using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAmAlive
{
    internal class CrashDumper
    {
        private readonly string _path;

        public CrashDumper(string path)
        {
            _path = @$"{path}\crashdump.txt";
        }

        public void Dunp(string message)
        {
            DateTime timestamp = DateTime.Now;
            File.AppendAllText(_path, $"{timestamp} - {message}");
            Environment.Exit( 0 );
        }
    }
}
