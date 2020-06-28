using Sartain_Studios_Common.Time_Calculator.Models;

namespace Sartain_Studios_Common.Time_Calculator
{
    public static class QuantitiesOfTimeHelpers
    {
        public static QuantitiesOfTimeModel FillQuantitiesOfTimeModel(double totalSeconds, double totalMinutes,
            double totalHours, double totalDays, double totalWeeks, double totalMonths, double totalYears,
            double totalDecades, double totalCenturies, double totalMillenniums, double relativeSeconds,
            double relativeMinutes, double relativeHours, double relativeDays, double relativeWeeks,
            double relativeMonths, double relativeYears, double relativeDecades, double relativeCenturies,
            double relativeMillenniums)
        {
            return new QuantitiesOfTimeModel
            {
                TotalSeconds = totalSeconds,
                TotalMinutes = totalMinutes,
                TotalHours = totalHours,
                TotalDays = totalDays,
                TotalWeeks = totalWeeks,
                TotalMonths = totalMonths,
                TotalYears = totalYears,
                TotalDecades = totalDecades,
                TotalCenturies = totalCenturies,
                TotalMillenniums = totalMillenniums,

                RelativeSeconds = relativeSeconds,
                RelativeMinutes = relativeMinutes,
                RelativeHours = relativeHours,
                RelativeDays = relativeDays,
                RelativeWeeks = relativeWeeks,
                RelativeMonths = relativeMonths,
                RelativeYears = relativeYears,
                RelativeDecades = relativeDecades,
                RelativeCenturies = relativeCenturies,
                RelativeMillenniums = relativeMillenniums
            };
        }

        public static QuantitiesOfRelativeTimeModel FillQuantitiesOfRelativeTimeModel(double relativeSeconds,
            double relativeMinutes, double relativeHours, double relativeDays, double relativeWeeks,
            double relativeMonths, double relativeYears, double relativeDecades, double relativeCenturies,
            double relativeMillenniums)
        {
            return new QuantitiesOfRelativeTimeModel
            {
                RelativeSeconds = relativeSeconds,
                RelativeMinutes = relativeMinutes,
                RelativeHours = relativeHours,
                RelativeDays = relativeDays,
                RelativeWeeks = relativeWeeks,
                RelativeMonths = relativeMonths,
                RelativeYears = relativeYears,
                RelativeDecades = relativeDecades,
                RelativeCenturies = relativeCenturies,
                RelativeMillenniums = relativeMillenniums
            };
        }

        public static QuantitiesOfTotalTimeModel FillQuantitiesOfTotalTimeModel(double totalSeconds,
            double totalMinutes, double totalHours, double totalDays, double totalWeeks, double totalMonths,
            double totalYears, double totalDecades, double totalCenturies, double totalMillenniums)
        {
            return new QuantitiesOfTotalTimeModel
            {
                TotalSeconds = totalSeconds,
                TotalMinutes = totalMinutes,
                TotalHours = totalHours,
                TotalDays = totalDays,
                TotalWeeks = totalWeeks,
                TotalMonths = totalMonths,
                TotalYears = totalYears,
                TotalDecades = totalDecades,
                TotalCenturies = totalCenturies,
                TotalMillenniums = totalMillenniums
            };
        }

        public static QuantitiesOfTimeModel MergeQuantitiesOfTimeModels(QuantitiesOfTotalTimeModel totalsModel,
            QuantitiesOfRelativeTimeModel relativesModel)
        {
            return FillQuantitiesOfTimeModel(
                totalsModel.TotalSeconds,
                totalsModel.TotalMinutes,
                totalsModel.TotalHours,
                totalsModel.TotalDays,
                totalsModel.TotalWeeks,
                totalsModel.TotalMonths,
                totalsModel.TotalYears,
                totalsModel.TotalDecades,
                totalsModel.TotalCenturies,
                totalsModel.TotalMillenniums,
                relativesModel.RelativeSeconds,
                relativesModel.RelativeMinutes,
                relativesModel.RelativeHours,
                relativesModel.RelativeDays,
                relativesModel.RelativeWeeks,
                relativesModel.RelativeMonths,
                relativesModel.RelativeYears,
                relativesModel.RelativeDecades,
                relativesModel.RelativeCenturies,
                relativesModel.RelativeMillenniums
            );
        }
    }
}