using Portfolio.Lib.Actions;

namespace Portfolio.Lib
{
    public abstract class ActionResolver
    {
        private static volatile ActionResolver instance;

        public static ActionResolver Instance
        {
            get { return instance; }
            set { instance = value; }
        }

        /// <summary>
        /// Get the action with the given action type.
        /// </summary>
        public abstract TAction GetAction<TAction>() where TAction : IAction;
    }
}