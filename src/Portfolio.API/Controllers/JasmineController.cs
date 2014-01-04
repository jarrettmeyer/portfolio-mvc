using System;
using System.Web.Mvc;

namespace Portfolio.API.Controllers
{
    public class JasmineController : Controller
    {
        public ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
