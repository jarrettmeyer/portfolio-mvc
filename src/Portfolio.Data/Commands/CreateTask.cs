using Portfolio.Data.Models;

namespace Portfolio.Data.Commands
{
    public abstract class CreateTask : AbstractCommand<CreateTask.Request, CreateTask.Response>
    {
        public class Request
        {
            public Task Task { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
        }
    }
}
