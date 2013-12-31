using System;
using System.Diagnostics.Contracts;
using System.Web.Mvc;
using MvcFlashMessages;
using Portfolio.Lib;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class SessionController : ApplicationController
    {
        readonly IMediator mediator;

        public SessionController(IMediator mediator)
        {
            Contract.Requires<ArgumentNullException>(mediator != null);
            this.mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult New()
        {
            var credentials = new Credentials();
            return View("New", credentials);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult New(Credentials credentials)
        {
            Contract.Requires<ArgumentNullException>(credentials != null);

            CheckModelState(() =>
            {
                this.Flash("danger", "Both a username and password are required.");
                return View("New", credentials);
            });
                        
            var logonResult = mediator.Send(credentials.ToCommand());
            if (logonResult.IsSuccessful)
            {
                SessionAdapter.SetUpSession(logonResult.User);
                this.Flash("success", string.Format("Welcome back, {0}", logonResult.User.Username));
                return RedirectToAction("Index", "Tasks");    
            }
            else
            {
                this.Flash("danger", "Invalid credentials");
                return View("New", credentials);
            }
        }

        [HttpGet]
        public ActionResult Delete()
        {
            this.Flash("info", "You have successfully logged off.");
            SessionAdapter.ResetSession();
            return RedirectToAction("New", "Session");
        }
	}
}