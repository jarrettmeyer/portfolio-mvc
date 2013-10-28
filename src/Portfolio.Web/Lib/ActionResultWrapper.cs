using System;
using System.Web.Mvc;
using Portfolio.Common;
using Portfolio.Common.Logging;
using Portfolio.Web.Lib.Actions;

namespace Portfolio.Web.Lib
{
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

        public override void ExecuteResult(ControllerContext context)
        {
            try
            {
                logWriter.WriteDebug("Executing action: " + action.GetType());
                action.Execute();
                actionResult = action.OnSuccess.Invoke();
                actionResult.ExecuteResult(context);
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