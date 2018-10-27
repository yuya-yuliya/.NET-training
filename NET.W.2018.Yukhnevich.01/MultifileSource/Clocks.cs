using System;
using Clock;

namespace ClockShop
{
  class Clocks
  {
    static void Main(string[] args)
    {
      DigitalClock digitalClock = new DigitalClock();
      Console.WriteLine(digitalClock.DigitalClockInfo());

      FlipClock flipClock = new FlipClock();
      Console.WriteLine(flipClock.FlipClockInfo());

      QuartzClock quartzClock = new QuartzClock();
      Console.WriteLine(quartzClock.QuartzClockInfo());
    }
  }
}
