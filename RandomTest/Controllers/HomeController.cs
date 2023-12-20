using Microsoft.AspNetCore.Mvc;
using RandomTest.Data;
using RandomTest.Models;
using System.Diagnostics;

namespace RandomTest.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult GetJobPostingsPartial(string query)
        {
            List<JobPosting> jobs;
            if (string.IsNullOrEmpty(query))
            {
                jobs = _context.JobPosts.ToList();
            }
            else
            {
                jobs = _context.JobPosts.Where(x => x.JobTitle.ToLower().Contains(query.ToLower())).ToList();
            }

            return PartialView("_jobPostingListPartial", jobs);
        }


        public IActionResult Index()
        {
            List<JobPosting> jobPostings = _context.JobPosts.ToList();
            return View(jobPostings);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}