namespace Sartain_Studios_Common.Time_Calculator.Models
{
    public interface IQuantitiesOfTotalTimeModel
    {
        double TotalSeconds { get; set; }
        double TotalMinutes { get; set; }
        double TotalHours { get; set; }
        double TotalDays { get; set; }
        double TotalWeeks { get; set; }
        double TotalMonths { get; set; }
        double TotalYears { get; set; }
        double TotalDecades { get; set; }
        double TotalCenturies { get; set; }
        double TotalMillenniums { get; set; }
    }

    public class QuantitiesOfTotalTimeModel : IQuantitiesOfTotalTimeModel
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
    }
}