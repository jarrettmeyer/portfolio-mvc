using System.Web.Mvc;
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
                FlashMessages.AddErrorMessage("Both a username and password are required.");
                return View("New", credentials);
            });
            var service = ServiceLocator.Instance.GetService<ILogonService>();
            var logonResult = service.Logon(credentials);
            if (logonResult.IsSuccessful)
            {
                SessionAdapter.SetUpSession(logonResult.User);
                FlashMessages.AddSuccessMessage(string.Format("Welcome back, {0}", logonResult.User.Username));
                return RedirectToAction("Index", "Tasks");    
            }
            else
            {
                FlashMessages.AddErrorMessage("Invalid credentials");
                return View("New", credentials);
            }
        }

        [HttpGet]
        public ActionResult Delete()
        {
            FlashMessages.AddSuccessMessage("You have successfully logged off.");
            SessionAdapter.ResetSession();
            return RedirectToAction("New", "Session");
        }
	}
}