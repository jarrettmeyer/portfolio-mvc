namespace Portfolio.Web.Lib.Rules
{
    /// <summary>
    /// Determines if a transition from one status to another is 
    /// a valid transition.
    /// </summary>
    public interface IWorkflowValidator
    {
        bool IsValidTransition(string fromStatus, string toStatus);
    }
}
