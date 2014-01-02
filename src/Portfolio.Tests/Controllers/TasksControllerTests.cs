using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Moq;
using MvcFlashMessages;
using NUnit.Framework;
using Portfolio.Lib;
using Portfolio.Lib.Commands;
using Portfolio.Lib.Queries;
using Portfolio.Lib.Services;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    [TestFixture]
    public class TasksControllerTests
    {
        private Mock<IMediator> mockMediator;
        private TaskInputModel model;
        private TasksController tasksController;

        [SetUp]
        public void Before_each_test()
        {
            mockMediator = new Mock<IMediator> { DefaultValue = DefaultValue.Mock };            
            ServiceLocator.Instance = new MockServiceLocator();
            tasksController = new TasksController(mockMediator.Object);
            MvcTest.SetupControllerContext(tasksController);
        }

        [TearDown]
        public void After_each_test()
        {
            ServiceLocator.Instance = null;
        }

        [Test]
        public void Controller_should_exist()
        {
            tasksController.Should().BeAssignableTo<TasksController>();
        }

        [Test]
        public void Delete_Delete_should_return_a_JSON_result()
        {
            var result = tasksController.Delete(new DeleteTaskCommand(1));
            MvcTest.HasExpectedActionResult<JsonResult>(result);
        }

        [Test]
        public void Delete_Delete_should_send_delete_task_command()
        {
            var command = new DeleteTaskCommand(1);
            tasksController.Delete(command);
            mockMediator.Verify(x => x.Send(command), Times.Once());
        }

        [Test]
        public void Get_Edit_should_have_the_expected_view_model()
        {
            var result = tasksController.Edit(new TaskByIdQuery(1));
            MvcTest.HasExpectedModel<TaskInputModel>(result);
        }

        [Test]
        public void Get_Edit_should_return_a_view()
        {
            var result = tasksController.Edit(new TaskByIdQuery(1));
            MvcTest.HasExpectedActionResult<ViewResult>(result);
        }

        [Test]
        public void Get_Edit_should_request_task_by_id()
        {
            var query = new TaskByIdQuery(1);
            tasksController.Edit(query);
            mockMediator.Verify(x => x.Request(query), Times.Once());
        }

        [Test]
        public void Get_Index_should_fetch_all_open_tasks()
        {
            tasksController.Index();
            mockMediator.Verify(x => x.Request(It.IsAny<OpenTasksQuery>()), Times.Once());
        }

        [Test]
        public void Get_Index_should_have_expected_view_model()
        {
            var actionResult = tasksController.Index();
            MvcTest.HasExpectedModel<TaskListViewModel>(actionResult);
        }

        [Test]
        public void Get_Index_should_return_a_view()
        {
            var actionResult = tasksController.Index();
            MvcTest.HasExpectedActionResult<ViewResult>(actionResult);
        }

        [Test]
        public void Get_New_should_return_a_view()
        {
            var actionResult = tasksController.New();
            MvcTest.HasExpectedActionResult<ViewResult>(actionResult);
        }

        [Test]
        public void Get_New_should_have_expected_view_model()
        {
            var actionResult = tasksController.New();
            MvcTest.HasExpectedModel<TaskInputModel>(actionResult);
        }

        [Test]
        public void Post_Complete_should_add_flash_message()
        {
            var command = new CompleteTaskCommand(1);
            tasksController.Complete(command);
            FlashMessage flashMessage = tasksController.TempData.GetFlashMessages().First();
            Assert.AreEqual("success", flashMessage.Key);
            StringAssert.Contains("Completed task:", flashMessage.Message);
        }

        [Test]
        public void Post_Complete_should_return_a_JSON_result()
        {
            var result = tasksController.Complete(new CompleteTaskCommand(1));
            MvcTest.HasExpectedActionResult<JsonResult>(result);
        }

        [Test]
        public void Post_Complete_should_send_to_mediator()
        {
            var command = new CompleteTaskCommand(1);
            tasksController.Complete(command);
            mockMediator.Verify(x => x.Send(command), Times.Once());
        }

        [Test]
        public void Post_Edit_should_redirect_to_index()
        {
            model = new TaskInputModel();
            var result = tasksController.Edit(model);
            MvcTest.RedirectsToRoute(result, action: "Index");            
        }
    }
}
