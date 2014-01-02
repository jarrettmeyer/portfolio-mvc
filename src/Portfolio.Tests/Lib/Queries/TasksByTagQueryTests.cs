using NUnit.Framework;

namespace Portfolio.Lib.Queries
{
    [TestFixture]
    public class TasksByTagQueryTests
    {
        private TasksByTagQuery query;

        [Test]
        public void Can_get_and_set_Tagged()
        {
            query = new TasksByTagQuery();
            query.Tagged = "tag";
            Assert.AreEqual("tag", query.Tagged);
        }

        [Test]
        public void Can_set_Tagged_in_constructor()
        {
            query = new TasksByTagQuery("testing");
            Assert.AreEqual("testing", query.Tagged);
        }
    }
}
