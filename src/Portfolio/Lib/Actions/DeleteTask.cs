using System;
using Portfolio.Web.Lib.Queries;

namespace Portfolio.Lib.Actions
{
    public class DeleteTask : AbstractAction
    {        
        private bool hasSetTaskId = false;
        private readonly DeleteTaskById query;
        private int taskId;

        public DeleteTask(DeleteTaskById query)
        {
            this.query = query;
        }

        public override void Execute()
        {
            DeleteTaskFromDatabase();            
        }

        public DeleteTask ForId(int id)
        {
            taskId = id;
            hasSetTaskId = true;
            return this;
        }

        protected override void OnDisposing()
        {
            if (query != null)
                query.Dispose();
        }

        private void DeleteTaskFromDatabase()
        {
            if (!hasSetTaskId)
                throw new InvalidOperationException("Task ID has not been set. Cannot execute delete task action.");
            query.ExecuteQuery(taskId);            
        }
    }
}