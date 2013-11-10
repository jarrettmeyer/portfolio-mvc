using System;
using System.Web.Mvc;

namespace Portfolio.Lib.Actions
{
    public interface IAction : IDisposable
    {
        /// <summary>
        /// Gets and sets the <see cref="ActionResult"/> to be executed if there is an error.
        /// </summary>
        Func<ActionResult> OnError { get; set; }

        /// <summary>
        /// Gets and sets the <see cref="ActionResult"/> to be executed when the action succeeds.
        /// </summary>
        Func<ActionResult> OnSuccess { get; set; }

        /// <summary>
        /// Gets the temp data for the the given action.
        /// </summary>
        TempDataDictionary TempData { get; }

        /// <summary>
        /// Execute the action.
        /// </summary>
        void Execute();

        IAction WithErrorAction(Func<ActionResult> onError);

        IAction WithSuccessAction(Func<ActionResult> onSuccess);
    }
}