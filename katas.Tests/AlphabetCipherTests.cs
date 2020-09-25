using NUnit.Framework;

namespace katas.Tests
{
    public class AlphabetCipherTests
    {
        [Test]
        public void Should_encode_input_with_given_keyword()
        {
            // Arrange
            const string expected = "egsgqwtahuiljgs";
            var sut = new AlphabetCipher("scones");

            // Act
            var actual = sut.Encode("meetmebythetree");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
