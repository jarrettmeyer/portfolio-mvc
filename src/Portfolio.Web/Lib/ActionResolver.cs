using Portfolio.Web.Lib.Actions;

namespace Portfolio.Web.Lib
{
    public abstract class ActionResolver
    {
        public abstract TAction GetAction<TAction>() where TAction : IAction;
    }
}