using Moq;
using NUnit.Framework;
using Portfolio.Data.Queries;

namespace Portfolio.Web.Lib.Actions
{
    public class DeleteTaskTests
    {
        private DeleteTask deleteTask;
        private Mock<DeleteTaskById> mockQuery;

        [SetUp]
        public void before_each_test()
        {
            mockQuery = new Mock<DeleteTaskById>();
            deleteTask = new DeleteTask(mockQuery.Object).ForId(100);
        }

        [Test]
        public void invokes_execute_query()
        {            
            deleteTask.Execute();
            mockQuery.Verify(x => x.ExecuteQuery(100), Times.Once());
        }
    }
}
