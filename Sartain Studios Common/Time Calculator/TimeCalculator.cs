using Sartain_Studios_Common.Time_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Sartain_Studios_Common.Time_Calculator
{
    public interface ITimeCalculator
    {
        QuantitiesOfTimeModel GetElapsedTimeQuantities(DateTime startingInstance, DateTime endingInstance);

        QuantitiesOfTimeModel GetElapsedTimeQuantities(
            List<(DateTime startingInstance, DateTime endingInstance)> listOfStartingAndEndingTimes);

        double GetElapsedHours(List<(DateTime startingInstance, DateTime endingInstance)> listOfStartingAndEndingTimes);

        bool DatesAreInTheSameWeek(DateTime date1, DateTime date2);
        bool DatesAreInTheSameMonth(DateTime date1, DateTime date2);
        bool DatesAreInTheSameYear(DateTime date1, DateTime date2);
    }

    public class TimeCalculator : ITimeCalculator
    {
        public bool DatesAreInTheSameYear(DateTime date1, DateTime date2)
        {
            return date1.Year == date2.Year;
        }

        public bool DatesAreInTheSameMonth(DateTime date1, DateTime date2)
        {
            return date1.Month == date2.Month;
        }

        public bool DatesAreInTheSameWeek(DateTime date1, DateTime date2)
        {
            var cal = DateTimeFormatInfo.CurrentInfo.Calendar;
            var d1 = date1.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date1));
            var d2 = date2.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date2));

            return d1 == d2;
        }

        public QuantitiesOfTimeModel GetElapsedTimeQuantities(DateTime startingInstance, DateTime endingInstance)
        {
            var totalMinutes = CalculateTotalMinutesBetweenStartAndEndInstance(startingInstance, endingInstance);

            return CalculateQuantitiesOfTime(totalMinutes);
        }

        public QuantitiesOfTimeModel GetElapsedTimeQuantities(
            List<(DateTime startingInstance, DateTime endingInstance)> listOfStartingAndEndingTimes)
        {
            double totalMinutes = 0;

            listOfStartingAndEndingTimes.ForEach(x =>
                totalMinutes += CalculateTotalMinutesBetweenStartAndEndInstance(
                    x.startingInstance,
                    x.endingInstance));

            return CalculateQuantitiesOfTime(totalMinutes);
        }

        public double GetElapsedHours(List<(DateTime startingInstance, DateTime endingInstance)> listOfStartingAndEndingTimes)
        {
            double totalMinutes = 0;

            listOfStartingAndEndingTimes.ForEach(x =>
                totalMinutes += CalculateTotalMinutesBetweenStartAndEndInstance(
                    x.startingInstance,
                    x.endingInstance));

            double minutesInHour = 60;

            return totalMinutes / minutesInHour;
        }

        private QuantitiesOfTimeModel CalculateQuantitiesOfTime(double totalMinutes)
        {
            var quantitiesOfTotalTime = CalculateQuantitiesOfTotalTime(totalMinutes);
            var quantitiesOfRelativeTime = CalculateElapsedRelativeTime(totalMinutes);

            return QuantitiesOfTimeHelpers.MergeQuantitiesOfTimeModels(quantitiesOfTotalTime, quantitiesOfRelativeTime);
        }

        private QuantitiesOfTotalTimeModel CalculateQuantitiesOfTotalTime(double totalTimeInMinutes)
        {
            var totalSeconds = MinutesToSeconds(totalTimeInMinutes);
            var totalMinutes = MinutesToMinutes(totalTimeInMinutes);
            var totalHours = MinutesToHours(totalTimeInMinutes);
            var totalDays = MinutesToDays(totalTimeInMinutes);
            var totalWeeks = MinutesToWeeks(totalTimeInMinutes);
            var totalMonths = MinutesToMonths(totalTimeInMinutes);
            var totalYears = MinutesToYears(totalTimeInMinutes);
            var totalDecades = MinutesToDecades(totalTimeInMinutes);
            var totalCenturies = MinutesToCenturies(totalTimeInMinutes);
            var totalMillenniums = MinutesToMillenniums(totalTimeInMinutes);

            return QuantitiesOfTimeHelpers.FillQuantitiesOfTotalTimeModel(totalSeconds, totalMinutes, totalHours,
                totalDays, totalWeeks,
                totalMonths,
                totalYears, totalDecades, totalCenturies, totalMillenniums);
        }

        private QuantitiesOfRelativeTimeModel CalculateElapsedRelativeTime(double totalTimeInMinutes)
        {
            double relativeSeconds = 0;
            double relativeMinutes = 0;
            double relativeHours = 0;
            double relativeDays = 0;
            double relativeWeeks = 0;
            double relativeMonths = 0;
            double relativeYears = 0;
            double relativeDecades = 0;
            double relativeCenturies = 0;
            double relativeMillenniums = 0;

            if (MinutesToMillenniums(totalTimeInMinutes) != 0)
            {
                relativeMillenniums = (int)MinutesToMillenniums(totalTimeInMinutes);
                totalTimeInMinutes -= MillenniumsToMinutes(relativeMillenniums);
            }

            if (MinutesToCenturies(totalTimeInMinutes) != 0)
            {
                relativeCenturies = (int)MinutesToCenturies(totalTimeInMinutes);
                totalTimeInMinutes -= CenturiesToMinutes(relativeCenturies);
            }

            if (MinutesToDecades(totalTimeInMinutes) != 0)
            {
                relativeDecades = (int)MinutesToDecades(totalTimeInMinutes);
                totalTimeInMinutes -= DecadesToMinutes(relativeDecades);
            }

            if (MinutesToYears(totalTimeInMinutes) != 0)
            {
                relativeYears = (int)MinutesToYears(totalTimeInMinutes);
                totalTimeInMinutes -= YearsToMinutes(relativeYears);
            }

            if (MinutesToMonths(totalTimeInMinutes) != 0)
            {
                relativeMonths = (int)MinutesToMonths(totalTimeInMinutes);
                totalTimeInMinutes -= MonthsToMinutes(relativeMonths);
            }

            if (MinutesToWeeks(totalTimeInMinutes) != 0)
            {
                relativeWeeks = (int)MinutesToWeeks(totalTimeInMinutes);
                totalTimeInMinutes -= WeeksToMinutes(relativeWeeks);
            }

            if (MinutesToDays(totalTimeInMinutes) != 0)
            {
                relativeDays = (int)MinutesToDays(totalTimeInMinutes);
                totalTimeInMinutes -= DaysToMinutes(relativeDays);
            }

            if (MinutesToHours(totalTimeInMinutes) != 0)
            {
                relativeHours = (int)MinutesToHours(totalTimeInMinutes);
                totalTimeInMinutes -= HoursToMinutes(relativeHours);
            }

            if (MinutesTooMinutes(totalTimeInMinutes) != 0)
            {
                relativeMinutes = (int)MinutesTooMinutes(totalTimeInMinutes);
                totalTimeInMinutes -= MinutesToMinutes(relativeMinutes);
            }

            if (MinutesToSeconds(totalTimeInMinutes) != 0)
            {
                relativeSeconds = (int)MinutesToSeconds(totalTimeInMinutes);
                totalTimeInMinutes -= SecondsToMinutes(relativeSeconds);
            }

            return QuantitiesOfTimeHelpers.FillQuantitiesOfRelativeTimeModel(relativeSeconds, relativeMinutes,
                relativeHours, relativeDays,
                relativeWeeks, relativeMonths, relativeYears, relativeDecades, relativeCenturies,
                relativeMillenniums);
        }

        private double CalculateTotalMinutesBetweenStartAndEndInstance(DateTime startTime, DateTime endTime)
        {
            return CalculateMinutesBetweenTwoPointsInTime(startTime, endTime);
        }

        private double CalculateMinutesBetweenTwoPointsInTime(DateTime startTime, DateTime endTime)
        {
            return endTime.Subtract(startTime).TotalMinutes;
        }

        #region TimeUnitConversions

        #region MinutesToTimeUnitsConversions

        private static double MinutesToSeconds(double minutes)
        {
            return minutes * 60;
        }

        private static double MinutesToMinutes(double minutes)
        {
            return minutes;
        }

        private static double MinutesToHours(double minutes)
        {
            return minutes / 60;
        }

        private static double MinutesToDays(double minutes)
        {
            return minutes / 60 / 24;
        }

        private static double MinutesToWeeks(double minutes)
        {
            return minutes / 60 / 24 / 7;
        }

        private static double MinutesToMonths(double minutes)
        {
            return minutes / 60 / 24 / 30;
        }

        private static double MinutesToYears(double minutes)
        {
            return minutes / 60 / 24 / 365;
        }

        private static double MinutesToDecades(double minutes)
        {
            return minutes / 60 / 24 / 365 / 10;
        }

        private static double MinutesToCenturies(double minutes)
        {
            return minutes / 60 / 24 / 365 / 100;
        }

        private static double MinutesToMillenniums(double minutes)
        {
            return minutes / 60 / 24 / 365 / 1000;
        }

        #endregion

        #region TimeUnitToMinutesConversions

        private static double SecondsToMinutes(double seconds)
        {
            return seconds / 60;
        }

        private static double MinutesTooMinutes(double minutes)
        {
            return minutes;
        }

        private static double HoursToMinutes(double hours)
        {
            return hours * 60;
        }

        private static double DaysToMinutes(double days)
        {
            return days * 60 * 24;
        }

        private static double WeeksToMinutes(double weeks)
        {
            return weeks * 60 * 24 * 7;
        }

        private static double MonthsToMinutes(double months)
        {
            return months * 60 * 24 * 30;
        }

        private static double YearsToMinutes(double years)
        {
            return years * 60 * 24 * 365;
        }

        private static double DecadesToMinutes(double decades)
        {
            return decades * 60 * 24 * 365 * 10;
        }

        private static double CenturiesToMinutes(double centuries)
        {
            return centuries * 60 * 24 * 365 * 100;
        }

        private static double MillenniumsToMinutes(double millenniums)
        {
            return millenniums * 60 * 24 * 365 * 1000;
        }

        #endregion

        #endregion
    }
}