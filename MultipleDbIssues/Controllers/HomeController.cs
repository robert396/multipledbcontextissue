using Microsoft.AspNetCore.Mvc;
using MultipleDbIssues.Data;
using MultipleDbIssues.Data.Models;
using MultipleDbIssues.Models;
using System.Diagnostics;
using System.Linq;

namespace MultipleDbIssues.Controllers
{
    public class HomeController : Controller
    {
        private readonly SiteDbContext _siteDbContext;

        public HomeController(SiteDbContext siteDbContext)
        {
            _siteDbContext = siteDbContext;
        }

        public IActionResult Index()
        {
            if (!_siteDbContext.Sites.Any())
            {
                _siteDbContext.Sites.Add(new Site
                {
                    Name = "TestSite",
                    Domain = "TestSiteDomain"
                });

                _siteDbContext.SaveChanges();
            }

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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
