using Portfolio.Lib.Queries;

namespace Portfolio.API.Models
{
    public class GetTaskRequest
    {
        public GetTaskRequest()
        {
        }

        public GetTaskRequest(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }

        public TaskByIdQuery ToTaskByIdQuery()
        {
            return new TaskByIdQuery(Id);
        }
    }
}