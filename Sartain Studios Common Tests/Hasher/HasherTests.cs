using NUnit.Framework;

namespace Sartain_Studios_Common_Tests.Hasher
{
    public class HasherTests
    {
        private Sartain_Studios_Common.Cryptography.Hasher _hasher;

        [SetUp]
        public void Setup()
        {
            _hasher = new Sartain_Studios_Common.Cryptography.Hasher();
        }

        [Test]
        public void GenerateHash_CreatesStringOf128Characters()
        {
            Assert.AreEqual(128, _hasher.GenerateHash("fdsaf").Length);
        }
    }
}