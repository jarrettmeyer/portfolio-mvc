using System;
using System.Web.Mvc;
using Portfolio.Data.Queries;

namespace Portfolio.Web.Lib.Actions
{
    public class DeleteTask : ActionResult, IDisposable
    {        
        private bool hasSetTaskId = false;
        private readonly DeleteTaskById query;
        private int taskId;

        public DeleteTask(DeleteTaskById query)
        {
            this.query = query;
        }

        public void Dispose()
        {
            if (query != null)
            {
                query.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public override void ExecuteResult(ControllerContext context)
        {
            DeleteTaskFromDatabase();
            ExecuteEmptyResult(context);
        }

        public DeleteTask ForId(int id)
        {
            taskId = id;
            hasSetTaskId = true;
            return this;
        }

        private void DeleteTaskFromDatabase()
        {
            if (!hasSetTaskId)
                throw new InvalidOperationException("Task ID has not been set. Cannot execute delete task action.");
            query.ExecuteQuery(taskId);            
        }

        private static void ExecuteEmptyResult(ControllerContext context)
        {
            var emptyResult = new EmptyResult();
            emptyResult.ExecuteResult(context);            
        }

    }
}