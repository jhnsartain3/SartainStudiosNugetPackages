namespace Sartain_Studios_Common.Time_Calculator.Models
{
    public interface IQuantitiesOfRelativeTimeModel
    {
        double RelativeSeconds { get; set; }
        double RelativeMinutes { get; set; }
        double RelativeHours { get; set; }
        double RelativeDays { get; set; }
        double RelativeWeeks { get; set; }
        double RelativeMonths { get; set; }
        double RelativeYears { get; set; }
        double RelativeDecades { get; set; }
        double RelativeCenturies { get; set; }
        double RelativeMillenniums { get; set; }
    }

    public class QuantitiesOfRelativeTimeModel : IQuantitiesOfRelativeTimeModel
    {
        public double RelativeSeconds { get; set; }
        public double RelativeMinutes { get; set; }
        public double RelativeHours { get; set; }
        public double RelativeDays { get; set; }
        public double RelativeWeeks { get; set; }
        public double RelativeMonths { get; set; }
        public double RelativeYears { get; set; }
        public double RelativeDecades { get; set; }
        public double RelativeCenturies { get; set; }
        public double RelativeMillenniums { get; set; }
    }
}