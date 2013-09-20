using System;
using NUnit.Framework;
using Portfolio.Data.Models;

namespace Portfolio.Domain
{
    [TestFixture]
    public class TaskMapperTests
    {
        [Test]
        public void maps_CreatedAt()
        {
            var createdAt = new DateTime(2013, 2, 3, 4, 5, 6);
            var task = new Task { CreatedAt = createdAt };
            var taskViewModel = TaskMapper.Map(task);
            Assert.AreEqual(createdAt, taskViewModel.CreatedAt);
        }
    }
}
