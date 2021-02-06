using System;

namespace console_timer
{
    public class Config
    {
        public Timer[] Timers { get; set; }
        public int Delay { get; set; }
        public bool ShowTimers { get; set; }
        
        public Config ()
        {
            Timers = new [] { new Timer { Duration = 60, Name = "Default", ForegroundColor = ConsoleColor.Black, BackgroundColor = ConsoleColor.Red } };
            Delay = 0;
            ShowTimers = true;
        }
    }
}