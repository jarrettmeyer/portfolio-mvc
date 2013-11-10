using Portfolio.Lib.Actions;
using Portfolio.Web.Lib.Actions;

namespace Portfolio.Lib
{
    public abstract class ActionResolver
    {
        /// <summary>
        /// Get the action with the given action type.
        /// </summary>
        public abstract TAction GetAction<TAction>() where TAction : IAction;
    }
}