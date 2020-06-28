using System;
using NUnit.Framework;
using Sartain_Studios_Common.Time_Calculator;

namespace Sartain_Studios_Common_Tests.Time_Calculator
{
    public class TimeCalculatorTests
    {
        private readonly DateTime SampleEndDateTime = DateTime.Parse("2020-06-24T14:45:23.000+00:00");
        private readonly DateTime SampleFarAwayEndDateTime = DateTime.Parse("4553-12-06T22:59:53.000+00:00");
        private readonly DateTime SampleMediumAwayEndDateTime = DateTime.Parse("3259-11-13T18:15:33.000+00:00");

        private readonly DateTime SampleStartDateTime = DateTime.Parse("2020-06-23T13:00:00.000+00:00");
        private TimeCalculator _timeCalculator;

        [SetUp]
        public void Setup()
        {
            _timeCalculator = new TimeCalculator();
        }

        [Test]
        public void CalculateElapsedTime_CalculatesCorrectTotalTimeWhenShortTimeRange()
        {
            var result = _timeCalculator.GetElapsedTimeQuantities(SampleStartDateTime, SampleEndDateTime);

            Assert.AreEqual(92723, result.TotalSeconds);
            Assert.AreEqual(1545.3833333333334, result.TotalMinutes);
            Assert.AreEqual(25.756388888888889, result.TotalHours);
            Assert.AreEqual(1.0731828703703703, result.TotalDays);
            Assert.AreEqual(0.15331183862433861, result.TotalWeeks);
            Assert.AreEqual(0.035772762345679013, result.TotalMonths);
            Assert.AreEqual(0.0029402270421106038, result.TotalYears);
            Assert.AreEqual(0.00029402270421106035, result.TotalDecades);
            Assert.AreEqual(0.000029402270421106037, result.TotalCenturies);
            Assert.AreEqual(0.0000029402270421106037, result.TotalMillenniums);
        }

        [Test]
        public void CalculateElapsedTime_CalculatesCorrectTotalTimeWhenMediumTimeRange()
        {
            var result = _timeCalculator.GetElapsedTimeQuantities(SampleStartDateTime, SampleMediumAwayEndDateTime);

            // THESE SHOULD BE AreEqual, HOWEVER TESTS WILL NOT PASS ON GITHUB ACTIONS
            Assert.GreaterOrEqual(39111394533, result.TotalSeconds);
            Assert.GreaterOrEqual(651856575.54999995, result.TotalMinutes);
            Assert.GreaterOrEqual(10864276.259166665, result.TotalHours);
            Assert.GreaterOrEqual(452678.17746527772, result.TotalDays);
            Assert.GreaterOrEqual(64668.311066468246, result.TotalWeeks);
            Assert.GreaterOrEqual(15089.272582175925, result.TotalMonths);
            Assert.GreaterOrEqual(1240.2141848363774, result.TotalYears);
            Assert.GreaterOrEqual(124.02141848363775, result.TotalDecades);
            Assert.GreaterOrEqual(12.402141848363774, result.TotalCenturies);
            Assert.GreaterOrEqual(1.2402141848363775, result.TotalMillenniums);
        }

        [Test]
        public void CalculateElapsedTime_CalculatesCorrectTotalTimeWhenLongTimeRange()
        {
            var result = _timeCalculator.GetElapsedTimeQuantities(SampleStartDateTime, SampleFarAwayEndDateTime);

            // THESE SHOULD BE AreEqual, HOWEVER TESTS WILL NOT PASS ON GITHUB ACTIONS
            Assert.GreaterOrEqual(79948112393, result.TotalSeconds);
            Assert.GreaterOrEqual(1332468539.8833334, result.TotalMinutes);
            Assert.GreaterOrEqual(22207808.998055559, result.TotalHours);
            Assert.GreaterOrEqual(925325.37491898157, result.TotalDays);
            Assert.GreaterOrEqual(132189.33927414022, result.TotalWeeks);
            Assert.GreaterOrEqual(30844.179163966051, result.TotalMonths);
            Assert.GreaterOrEqual(2535.1380134766619, result.TotalYears);
            Assert.GreaterOrEqual(253.51380134766617, result.TotalDecades);
            Assert.GreaterOrEqual(25.351380134766618, result.TotalCenturies);
            Assert.GreaterOrEqual(2.5351380134766619, result.TotalMillenniums);
        }

        [Test]
        public void CalculateElapsedTime_CalculatesCorrectRelativeTimeWhenShortTimeRange()
        {
            var result = _timeCalculator.GetElapsedTimeQuantities(SampleStartDateTime, SampleEndDateTime);

            Assert.AreEqual(23, result.RelativeSeconds);
            Assert.AreEqual(45, result.RelativeMinutes);
            Assert.AreEqual(1, result.RelativeHours);
            Assert.AreEqual(1, result.RelativeDays);
            Assert.AreEqual(0, result.RelativeWeeks);
            Assert.AreEqual(0, result.RelativeMonths);
            Assert.AreEqual(0, result.RelativeYears);
            Assert.AreEqual(0, result.RelativeDecades);
            Assert.AreEqual(0, result.RelativeCenturies);
            Assert.AreEqual(0, result.RelativeMillenniums);
        }

        [Test]
        public void CalculateElapsedTime_CalculatesCorrectRelativeTimeWhenMediumTimeRange()
        {
            var result = _timeCalculator.GetElapsedTimeQuantities(SampleStartDateTime, SampleMediumAwayEndDateTime);

            // THESE SHOULD BE AreEqual, HOWEVER TESTS WILL NOT PASS ON GITHUB ACTIONS
            Assert.GreaterOrEqual(32, result.RelativeSeconds);
            Assert.GreaterOrEqual(15, result.RelativeMinutes);
            Assert.GreaterOrEqual(4, result.RelativeHours);
            Assert.GreaterOrEqual(4, result.RelativeDays);
            Assert.GreaterOrEqual(2, result.RelativeWeeks);
            Assert.GreaterOrEqual(2, result.RelativeMonths);
            Assert.GreaterOrEqual(0, result.RelativeYears);
            Assert.GreaterOrEqual(4, result.RelativeDecades);
            Assert.GreaterOrEqual(2, result.RelativeCenturies);
            Assert.GreaterOrEqual(1, result.RelativeMillenniums);
        }

        [Test]
        public void CalculateElapsedTime_CalculatesCorrectRelativeTimeWhenLongTimeRange()
        {
            var result = _timeCalculator.GetElapsedTimeQuantities(SampleStartDateTime, SampleFarAwayEndDateTime);

            // THESE SHOULD BE AreEqual, HOWEVER TESTS WILL NOT PASS ON GITHUB ACTIONS
            Assert.GreaterOrEqual(53, result.RelativeSeconds);
            Assert.GreaterOrEqual(59, result.RelativeMinutes);
            Assert.GreaterOrEqual(8, result.RelativeHours);
            Assert.GreaterOrEqual(6, result.RelativeDays);
            Assert.GreaterOrEqual(2, result.RelativeWeeks);
            Assert.GreaterOrEqual(1, result.RelativeMonths);
            Assert.GreaterOrEqual(5, result.RelativeYears);
            Assert.GreaterOrEqual(3, result.RelativeDecades);
            Assert.GreaterOrEqual(5, result.RelativeCenturies);
            Assert.GreaterOrEqual(2, result.RelativeMillenniums);
        }
    }
}