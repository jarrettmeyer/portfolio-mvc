using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Portfolio.Common;
using Portfolio.Data;
using Portfolio.Data.Commands;
using Portfolio.Data.Models;
using Portfolio.Domain.ViewModels;

namespace Portfolio.Domain.Services.Impl
{
    public class TaskServiceImplTests
    {
        [TestFixture]
        public class UpdateTaskTests
        {
            private Mock<IClock> mockClock;
            private Mock<ICommandStore> mockCommandStore;
            private Mock<IRepository> mockRepository;
            private DateTime now;
            
            private TaskInputModel taskInputModel;
            private ITaskService taskService;
            
            [SetUp]
            public void before_each_test()
            {
                mockRepository = new Mock<IRepository> { DefaultValue = DefaultValue.Mock };
                mockRepository.Setup(x => x.Load<Task>(1)).Returns(new Task { Id = 1 });

                mockCommandStore = new Mock<ICommandStore>();

                now = DateTime.Now;
                mockClock = new Mock<IClock>();
                mockClock.SetupGet(x => x.Now).Returns(now);

                taskService = new TaskServiceImpl(mockRepository.Object, mockCommandStore.Object, mockClock.Object);
            }

            [Test]
            public void should_fetch_task_by_id()
            {
                taskInputModel = new TaskInputModel
                                 {
                                     Id = 1
                                 };
                taskService.UpdateTask(taskInputModel);
                mockRepository.Verify(x => x.Load<Task>(taskInputModel.Id), Times.Once());
            }

            [Test]
            public void should_save_changes()
            {
                taskInputModel = new TaskInputModel
                                 {
                                     Id = 1,
                                     Description = "This is an updated description"
                                 };
                taskService.UpdateTask(taskInputModel);
                mockRepository.Verify(x => x.SaveChanges(), Times.Once());
            }

            [Test]
            public void should_update_description()
            {
                taskInputModel = new TaskInputModel
                {
                    Id = 1,
                    Description = "This is an updated description"
                };
                var result = taskService.UpdateTask(taskInputModel);
                Assert.AreEqual("This is an updated description", result.Description);                
            }

            [Test]
            public void should_update_updated_at()
            {
                taskInputModel = new TaskInputModel
                {
                    Id = 1,
                    Description = "This is an updated description"
                };
                var result = taskService.UpdateTask(taskInputModel);
                result.UpdatedAt.Should().Be(now);
            }
        }
    }
}
