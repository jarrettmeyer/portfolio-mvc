using System.Linq;
using System.Web.Mvc;
using Portfolio.Lib.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IRepository repository;

        public CategoriesController()
        {
            repository = Repository.Instance;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var categories = repository.FindAll<Category>().OrderBy(c => c.Description).ToArray();
            return View("Index", categories);
        }

    }
}
