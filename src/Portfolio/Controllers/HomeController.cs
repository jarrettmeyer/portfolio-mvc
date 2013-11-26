using System;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class HomeController : ApplicationController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Tasks");
        }

        [HttpGet]
        public ActionResult Error()
        {            
            throw new ApplicationException("This action is used to test ELMAH.");
        }
    }
}
