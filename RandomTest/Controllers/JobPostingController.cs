using RandomTest.Data;
using RandomTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace JobPortal.Controllers
{

    [Authorize]
    public class JobPostingController : Controller
    {
        private ApplicationDbContext _context;



        public JobPostingController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            var jobPostings = _context.JobPosts.Where(x => x.OwnerUsername == User.Identity.Name).ToList();
            return View(jobPostings);
        }

        public IActionResult DeleteJobPosting(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var jobPostingfromDB = _context.JobPosts.SingleOrDefault(x=>x.id == id);

            if(jobPostingfromDB is null)
            {
                return NotFound();
            }

            _context.JobPosts.Remove(jobPostingfromDB);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult CreateEditJobPosting(int id)
        {
            if(id!=0)
            {
                var JobFromDB = _context.JobPosts.SingleOrDefault(x=>x.id==id);

                if(JobFromDB!=null)
                {
                    if(JobFromDB.OwnerUsername != User?.Identity?.Name)
                    {
                        return Unauthorized();
                    }
                    return View(JobFromDB);
                }

            }
                return View();
            
            
        }
        public IActionResult CreateEditJob(JobPosting jobPosting, IFormFile file)
        {
            jobPosting.OwnerUsername = User.Identity.Name;
            if (file != null)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var bytes = ms.ToArray();
                    jobPosting.CompanyImage = bytes;
                }
            }
            if (jobPosting.id == 0)
            {
                _context.JobPosts.Add(jobPosting);
            }
            else
            {
                var jobFromDB = _context.JobPosts.SingleOrDefault(x => x.id == jobPosting.id);
                if (jobFromDB == null)
                {
                    return NotFound();
                }
                else
                {
                    jobFromDB.JobTitle = jobPosting.JobTitle;
                    jobFromDB.JobLocation = jobPosting.JobLocation;
                    jobFromDB.JobDescription = jobPosting.JobDescription;
                    jobFromDB.Salary = jobPosting.Salary;
                    jobFromDB.Startdate = jobPosting.Startdate;
                    jobFromDB.Companyname = jobPosting.Companyname;
                    jobFromDB.CompanyImage = jobPosting.CompanyImage;
                }
            }
            _context.SaveChanges();



            return RedirectToAction("Index");
        }
    }
}