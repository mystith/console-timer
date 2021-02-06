using System;

namespace console_timer
{
    public struct Timer
    {
        public double Duration { get; set; }
        public string Name { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
    }
}