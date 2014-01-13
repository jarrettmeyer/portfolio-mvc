using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Portfolio.Lib
{
    [TestFixture]
    public class CollectionExtensionsTests
    {
        private readonly IEnumerable<TestObject> testCollection = new[]
        {
            new TestObject { Id = 1, Name = "Alice" },
            new TestObject { Id = 2, Name = "Bob" },
            new TestObject { Id = 3, Name = "Carol" }
        };
            
        [Test]
        public void can_convert_collection_to_select_list()
        {
            var selectList = testCollection.ToSelectList(x => x.Id, x => x.Name);
            
            selectList.DataTextField.Should().Be("Name");
            selectList.DataValueField.Should().Be("Id");
        }

        public class TestObject
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
