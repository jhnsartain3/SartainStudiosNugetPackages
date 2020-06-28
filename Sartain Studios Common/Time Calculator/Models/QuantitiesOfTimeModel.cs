namespace Sartain_Studios_Common.Time_Calculator.Models
{
    public class QuantitiesOfTimeModel : IQuantitiesOfTotalTimeModel, IQuantitiesOfRelativeTimeModel
    {
        public double TotalSeconds { get; set; }
        public double TotalMinutes { get; set; }
        public double TotalHours { get; set; }
        public double TotalDays { get; set; }
        public double TotalWeeks { get; set; }
        public double TotalMonths { get; set; }
        public double TotalYears { get; set; }
        public double TotalDecades { get; set; }
        public double TotalCenturies { get; set; }
        public double TotalMillenniums { get; set; }
        
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