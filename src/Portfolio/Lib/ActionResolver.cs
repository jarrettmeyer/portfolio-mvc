using Portfolio.Web.Lib.Actions;

namespace Portfolio.Web.Lib
{
    public abstract class ActionResolver
    {
        /// <summary>
        /// Get the action with the given action type.
        /// </summary>
        public abstract TAction GetAction<TAction>() where TAction : IAction;
    }
}