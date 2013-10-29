using System;
using System.Diagnostics;
using System.Web.Mvc;
using Portfolio.Common;
using Portfolio.Common.Logging;
using Portfolio.Web.Lib.Actions;

namespace Portfolio.Web.Lib
{
    /// <summary>
    /// Common construct for executing actions in an MVC action. If everything works.
    /// </summary>
    public class ActionResultWrapper : ActionResult
    {
        private readonly IAction action;
        private ActionResult actionResult;
        private static readonly ILogWriter logWriter = Log.For<ActionResultWrapper>();

        public ActionResultWrapper(IAction action)
        {
            Ensure.ArgumentIsNotNull(action, "action");
            this.action = action;
        }

        public IAction Action
        {
            get { return action; }
        }

        public override void ExecuteResult(ControllerContext context)
        {
            try
            {
                // Execute the action. If no exceptions are thrown, execute
                // the success action. If an exception is thrown, execute the
                // error action.

                // For added touch, there is a little bit of logging in this 
                // class, just so we can see how long various actions take. If
                // certain actions get too long, we might want to come back
                // and make a better judgement about how they are written.

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                action.Execute();
                actionResult = action.OnSuccess.Invoke();
                actionResult.ExecuteResult(context);
                stopWatch.Stop();
                var duration = stopWatch.ElapsedMilliseconds;
                logWriter.WriteDebug(string.Format("Executed action '{0}'. Total time was {1} ms.", action.GetType(), duration));
            }
            catch (Exception e)
            {
                logWriter.WriteError(string.Format("Error perfoming action {0}", action), e);
                actionResult = action.OnError.Invoke();
                actionResult.ExecuteResult(context);
            }            
        }
    }
}