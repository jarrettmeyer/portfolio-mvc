using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using Portfolio.Lib;
using Portfolio.Lib.ViewModels;

namespace Portfolio.Controllers
{
    public class PasswordController : Controller
    {
        public ActionResult Forgot()
        {
            var model = new PasswordForgotViewModel();
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Test(PasswordTestViewModel model)
        {
            model = model ?? new PasswordTestViewModel();
            var passwordUtility = ServiceLocator.Current.GetInstance<IPasswordUtility>();
            model.HashedPassword = passwordUtility.HashText(model.Password);
            return View(model);
        }
	}
}