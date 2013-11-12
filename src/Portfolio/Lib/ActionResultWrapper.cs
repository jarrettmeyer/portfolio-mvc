using System;
using System.Diagnostics;
using System.Web.Mvc;
using Portfolio.Common;
using Portfolio.Lib.Actions;
using Portfolio.Web.Lib.Logging;
using Portfolio.Web.ViewModels;

namespace Portfolio.Lib
{
    /// <summary>
    /// Common construct for executing actions in an MVC action. If everything works, the action's
    /// OnSuccess delegate will be invoked. If there is an error, via throwing an exception, the
    /// action's OnError delegate will be invoked.
    /// </summary>
    public class ActionResultWrapper : ActionResult
    {
        private readonly IAction action;
        private ActionResult actionResult;
        private static readonly ILogWriter logWriter = Log.For<ActionResultWrapper>();
        private Stopwatch stopWatch;

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

                stopWatch = new Stopwatch();
                stopWatch.Start();
                action.Execute();
                actionResult = action.OnSuccess.Invoke();
                actionResult.ExecuteResult(context);
                stopWatch.Stop();                
                logWriter.WriteDebug(string.Format("Executed action '{0}'. Total time was {1} ms.", action.GetType(), stopWatch.ElapsedMilliseconds));
            }
            catch (Exception e)
            {
                e = GetInnermostException(e);
                AddErrorToFlash(e);
                logWriter.WriteError(string.Format("Error perfoming action {0}", action), e);
                actionResult = action.OnError.Invoke();
                actionResult.ExecuteResult(context);
            }            
        }

        private void AddErrorToFlash(Exception e)
        {
            if (action.TempData != null)
            {
                new FlashMessageCollection(action.TempData).AddErrorMessage(e.Message);
            }
        }

        private static Exception GetInnermostException(Exception exception)
        {
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
            }
            return exception;
        }
    }
}