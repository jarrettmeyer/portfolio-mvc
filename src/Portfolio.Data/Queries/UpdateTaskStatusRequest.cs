namespace Portfolio.Data.Queries
{
    public class UpdateTaskStatusRequest
    {
        private readonly string comment;
        private readonly int taskId;
        private readonly string toStatus;

        public UpdateTaskStatusRequest(int taskId, string toStatus, string comment = null)
        {
            this.taskId = taskId;
            this.toStatus = toStatus;
            this.comment = comment;
        }

        public string Comment
        {
            get { return comment; }
        }

        public int TaskId
        {
            get { return taskId; }
        }

        public string ToStatus
        {
            get { return toStatus; }
        }
    }
}
