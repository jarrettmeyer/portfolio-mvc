using System.Web.Mvc;

namespace Portfolio.Web.Lib
{
    public abstract class ActionResolver
    {
        public abstract TActionResult GetAction<TActionResult>() where TActionResult : ActionResult;
    }
}