using System.Web.Mvc;
using Portfolio.Lib;
using Portfolio.Lib.Services;
using Portfolio.ViewModels;

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
            var passwordUtility = ServiceLocator.Instance.GetService<IPasswordUtility>();
            model.HashedPassword = passwordUtility.HashText(model.Password);
            return View(model);
        }
	}
}