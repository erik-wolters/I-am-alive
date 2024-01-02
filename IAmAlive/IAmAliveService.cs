using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace IAmAlive
{
    internal class IAmAliveService
    {
        private readonly System.Timers.Timer _timer;
        private readonly Logger _logger;
        private readonly string _appDir;

        public IAmAliveService()
        {
            _appDir = AppDomain.CurrentDomain.BaseDirectory;
            _logger = new(_appDir);
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += TimerElapsed;

        }

        private void TimerElapsed(object? sender, ElapsedEventArgs e)
        {
            _logger.Log("I am alive!");
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer?.Stop();
        }
    }
}
