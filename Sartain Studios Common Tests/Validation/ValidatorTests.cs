using Moq;
using NUnit.Framework;
using Sartain_Studios_Common.Validation;
using System.Collections.Generic;

namespace Sartain_Studios_Common_Tests.Validation
{
    public class ValidatorTests
    {
        Validator _validator;

        Mock<IValidationList> _validationListMock;

        [SetUp]
        public void Setup()
        {
            _validationListMock = new Mock<IValidationList>
            {
            };

            _validator = new Validator(_validationListMock.Object);
        }

        [Test]
        public void IsValidReturnsTrueWhenValid()
        {
            _validationListMock.Setup(validationList => validationList.IsValid).Returns(true);

            Assert.IsTrue(_validator.IsValid);
        }

        [Test]
        public void IsValidReturnsFalseWhenInvalid()
        {
            _validationListMock.Setup(validationList => validationList.IsValid).Returns(false);

            Assert.IsFalse(_validator.IsValid);
        }


        [Test]
        public void MessagesReturnsListOfMessages()
        {
            var messages = new List<string> { "Error 1", "Error 2" };
            _validationListMock.Setup(validationList => validationList.Messages).Returns(messages);

            Assert.AreEqual(messages, _validator.Messages);
        }
    }
}