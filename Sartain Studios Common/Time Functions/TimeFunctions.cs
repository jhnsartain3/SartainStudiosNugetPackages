using System;

namespace Sartain_Studios_Common.Time_Functions
{
    public class TimeFunctions : ITimeFunctions
    {
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }

        public DateTime GetCurrentDateTimeLocal()
        {
            return DateTime.Now.ToLocalTime();
        }
    }
}