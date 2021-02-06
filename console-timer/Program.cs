using System;
using System.Threading;

namespace console_timer
{
    class Program
    {
        public static void Timer(Config cfg)
        {
            Console.CursorVisible = false;

            if (cfg.Delay > 0)
            {
                Console.WriteLine("Waiting {0}s to start...", cfg.Delay);
                Thread.Sleep(cfg.Delay * 1000);
            }

            int timers = cfg.Timers.Length;
            
            DateTime now = DateTime.Now;
            
            while (true)
            {
                Console.Clear();

                if (cfg.ShowTimers)
                {
                    foreach (Timer timer in cfg.Timers)
                    {
                        double remainingTime = timer.Duration - (DateTime.Now - now).TotalSeconds % timer.Duration;
                        Console.WriteLine("{0}: {1}s left", timer.Name, (int) Math.Ceiling(remainingTime));
                    }
                }
                
                Console.WriteLine();
                
                foreach (Timer timer in cfg.Timers)
                {
                    double remainingTime = timer.Duration - (DateTime.Now - now).TotalSeconds % timer.Duration;

                    if (remainingTime <= 5)
                    {
                        Console.ForegroundColor = timer.ForegroundColor;
                        Console.BackgroundColor = timer.BackgroundColor;
                        
                        Console.WriteLine("{0}", timer.Name);
                        
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }

                Thread.Sleep(500);
            }
        }
        
        static void Main(string[] args)
        {
            Config cfg = new ConfigLoader().Load();
            
            Timer(cfg);
        }
    }
}