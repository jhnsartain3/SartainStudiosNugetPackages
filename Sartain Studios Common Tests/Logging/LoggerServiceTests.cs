using NUnit.Framework;
using Sartain_Studios_Common.Logging;
using System;

namespace Sartain_Studios_Common_Tests.Logging
{
    public class LoggerServiceTests
    {
        private LoggerService _loggerService;
        private readonly string _baseLogDirectory = @"C:\SomeDirectory\On\The\Drive\";
        private readonly string _sampleExampleContent = "Some example content";
        private readonly string _sampleCodeOrigin = "Network";
        private readonly string _sampleSubCodeOrigin = "Wifi";
        private readonly string _sampleType = "Warning";
        private readonly string _fileName = "Log";

        [SetUp]
        public void Setup()
        {
            _loggerService = new LoggerService(_baseLogDirectory);
        }

        [Test]
        public void DetermineContentToWrite()
        {
            var currentDate = DateTime.Now.ToLocalTime().ToString();

            var result = _loggerService.DetermineContentToWrite(_sampleExampleContent, _sampleType, _sampleCodeOrigin, _sampleSubCodeOrigin);

            Assert.AreEqual(currentDate + " Warning Network Wifi Some example content", result);
        }

        [Test]
        public void DetermineWritePath()
        {
            var result = _loggerService.DetermineWritePath(_sampleType, _fileName);

            Assert.AreEqual((@"C:\SomeDirectory\On\The\Drive\Warning\", "Log Warning.log"), result);
        }
    }
}
