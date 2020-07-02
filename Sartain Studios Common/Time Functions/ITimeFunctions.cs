using System;

namespace Sartain_Studios_Common.Time_Functions
{
    public interface ITimeFunctions
    {
        DateTime GetCurrentDateTime();
        DateTime GetCurrentDateTimeLocal();
    }
}