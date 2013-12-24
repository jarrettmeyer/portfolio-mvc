using System.Web.Mvc;
using MvcFlashMessages;
using Portfolio.Lib;
using Portfolio.Lib.Services;
using Portfolio.Lib.ViewModels;

namespace Portfolio.Controllers
{
    public class SessionController : ApplicationController
    {
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
            CheckModelState(() =>
            {
                this.Flash("danger", "Both a username and password are required.");
                return View("New", credentials);
            });
            var service = ServiceLocator.Instance.GetService<ILogonService>();
            var logonResult = service.Logon(credentials);
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