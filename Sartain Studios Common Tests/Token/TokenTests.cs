using NUnit.Framework;
using Sartain_Studios_Common.Interfaces.Token;
using Sartain_Studios_Common.Token;
using SharedModels;

namespace Sartain_Studios_Common_Tests.Token
{
    public class JwtTokenTests
    {
        private IToken _hasher;

        private string jwtSecret = "zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz";

        private int jwtExpirationInMinutes = 60;

        [SetUp]
        public void Setup()
        {
            _hasher = new JwtToken(jwtSecret, jwtExpirationInMinutes);
        }

        [Test]
        public void GenerateToken_ReturnsToken()
        {
            var result = _hasher.GenerateToken();

            Assert.GreaterOrEqual(result.Length, 50);
        }

        [Test]
        public void GenerateToken_WithNullUserModelReturnsToken()
        {
            var result = _hasher.GenerateToken(null);

            Assert.GreaterOrEqual(result.Length, 50);
        }

        [Test]
        public void GenerateToken_WithEmptyUserModelReturnsToken()
        {
            var result = _hasher.GenerateToken(new UserModel { });

            Assert.GreaterOrEqual(result.Length, 50);
        }
    }
}