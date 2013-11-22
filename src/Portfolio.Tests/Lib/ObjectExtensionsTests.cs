using FluentAssertions;
using NUnit.Framework;

namespace Portfolio.Lib
{
    [TestFixture]
    public class ObjectExtensionsTests
    {
        [Test]
        public void can_convert_an_object_to_a_dictionary()
        {
            var obj = new
            {
                Id = 1,
                Name = "John Doe",
                Age = 30
            };

            var dict = obj.ToDictionary();
            
            dict["Id"].Should().Be(1);
            dict["Name"].Should().Be("John Doe");
            dict["Age"].Should().Be(30);
        }
    }
}
