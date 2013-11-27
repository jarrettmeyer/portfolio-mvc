using FluentAssertions;
using NUnit.Framework;

namespace Portfolio.Lib
{
    [TestFixture]
    public class ByteExtensionsTests
    {
        [Test]
        public void Can_write_byte_array_to_string()
        {
            byte[] bytes = { 0, 0, 0, 0, 0, 0, 8, 71 };
            string byteString = bytes.ToBase64String();
            byteString.Should().Be("AAAAAAAACEc=");
        }
    }
}
