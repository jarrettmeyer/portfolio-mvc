using Portfolio.Web.Lib;
using Portfolio.Web.Lib.Actions;

namespace Portfolio.Lib.Actions
{
    public class RedirectToListTasks : AbstractAction
    {
        public RedirectToListTasks()
        {
            OnSuccess = () => new RedirectToRouteResultBuilder()
                .Controller("Tasks")
                .Action("Index")
                .RedirectToRouteResult;
        }

        public override void Execute()
        {
        }
    }
}