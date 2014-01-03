using System.Diagnostics.Contracts;
using System.Web.Http;
using Portfolio.API.Models;
using Portfolio.Lib;
using Portfolio.Lib.Models;
using Portfolio.Lib.Queries;

namespace Portfolio.API.Controllers
{
    public class TasksController : ApiController
    {
        private readonly IMediator mediator;

        public TasksController(IMediator mediator)
        {
            Contract.Requires(mediator != null);
            this.mediator = mediator;
        }

        public ApiResult<GetTasksResult> Get()
        {
            var tasks = mediator.Request(new OpenTasksQuery());
            var getTasksResult = new GetTasksResult(tasks);
            return new ApiResult<GetTasksResult>(getTasksResult);
        }

        public ApiResult<GetTaskResult> Get(int id)
        {
            var query = new TaskByIdQuery(id);
            var task = mediator.Request(query);
            var getTaskResult = new GetTaskResult(task);
            return new ApiResult<GetTaskResult>(getTaskResult);
        }

        public ApiResult<PostTaskResult> Post(PostTaskRequest model)
        {
            var command = model.ToCreateTaskCommand();
            Task task = mediator.Send(command);
            PostTaskResult postTaskResult = new PostTaskResult(task);
            return new ApiResult<PostTaskResult>(postTaskResult);
        }
    }
}