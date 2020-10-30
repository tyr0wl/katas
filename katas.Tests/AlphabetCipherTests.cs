using NUnit.Framework;

namespace katas.Tests
{
    public class AlphabetCipherTests
    {
        [Test]
        public void Should_encode_message_with_given_keyword()
        {
            // Arrange
            const string expected = "egsgqwtahuiljgs";
            var sut = new AlphabetCipher("scones");

            // Act
            var actual = sut.Encode("meetmebythetree");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_decode_message_given_keyword()
        {
            // Arrange
            const string expected = "meetmebythetree";
            var sut = new AlphabetCipher("scones");

            // Act
            var actual = sut.Decode("egsgqwtahuiljgs");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
