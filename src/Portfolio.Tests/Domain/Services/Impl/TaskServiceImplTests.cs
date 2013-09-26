using Moq;
using NUnit.Framework;
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
            private Mock<IRepository> mockRepository;
            private Mock<ICommandStore> mockCommandStore;
            private TaskInputModel taskInputModel;
            private ITaskService taskService;
            
            [SetUp]
            public void before_each_test()
            {
                mockRepository = new Mock<IRepository> { DefaultValue = DefaultValue.Mock };
                mockRepository.Setup(x => x.Load<Task>(1)).Returns(new Task { Id = 1 });
                mockCommandStore = new Mock<ICommandStore>();

                taskService = new TaskServiceImpl(mockRepository.Object, mockCommandStore.Object);
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
        }
    }
}
