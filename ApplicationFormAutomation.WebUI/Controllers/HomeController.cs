using ApplicationFormAutomation.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

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
            var model = _dbContext.Forms
                .Include(t=> t.FormElements)
                .FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(FormSubmit answer)
        {
            answer.CreatedDate = DateTime.Now;
            _dbContext.FormSubmits.Add(answer);
            _dbContext.SaveChanges();
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
