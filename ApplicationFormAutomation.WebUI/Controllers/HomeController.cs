using ApplicationFormAutomation.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ApplicationFormAutomation.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly FormBuilderDbContext _dbContext;
        public HomeController(FormBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
            var dbExist = dbContext.Database.EnsureCreated();
        }
        public IActionResult Index()
        {
            var model = _dbContext.Form
                .Include(t=> t.FormElements)
                .FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(FormSubmit answer)
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
