using System.Web.Mvc;
using Portfolio.Lib;

namespace Portfolio.Controllers
{
    public class SettingsController : ApplicationController
    {
        [HttpGet]
        public ActionResult PageSize()
        {
            int pageSize = Config.PageSize;
            return Json(pageSize, JsonRequestBehavior.AllowGet);
        }

    }
}
