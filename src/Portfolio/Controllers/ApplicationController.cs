using System.Web.Mvc;
using Portfolio.Lib;

namespace Portfolio.Controllers
{
    public abstract class ApplicationController : Controller
    {
        public virtual void CheckModelState()
        {
            if (!ViewData.ModelState.IsValid)
                throw new InvalidModelStateException("", ViewData.ModelState);
        }
    }
}
