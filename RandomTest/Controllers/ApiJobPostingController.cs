using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomTest.Data;
using RandomTest.Models;

namespace RandomTest.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiJobPostingController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ApiJobPostingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            var alljobs = _context.JobPosts.ToArray();
            return Ok(alljobs);
        }

        [HttpGet("GetByID")]
        public IActionResult Get(int id)
        {
            var JobFromDB = _context.JobPosts.SingleOrDefault(x => x.id == id);
            return Ok(JobFromDB);
        }

        [HttpDelete("Delete")]

        public IActionResult Delete(int id)
        {
            var JobFromDB = _context.JobPosts.SingleOrDefault(x => x.id == id);
            if (JobFromDB == null)
            {
                return BadRequest("Nicht gefunden");
            }
            else
            {
                _context.JobPosts.Remove(JobFromDB);
                _context.SaveChanges();

                return Ok("Ok, gelöscht");
            }

        }

        [HttpPut("Update")]

        public IActionResult Put(int id, JobPosting job)
        {
            var JobFromDB = _context.JobPosts.SingleOrDefault(x => x.id == id);
            if (JobFromDB == null)
            {
                return BadRequest("Nicht gefunden");
            }
            else
            {
                JobFromDB.JobTitle = job.JobTitle;
                JobFromDB.JobLocation = job.JobLocation;
                JobFromDB.JobDescription = job.JobDescription;
                JobFromDB.Salary = job.Salary;
                JobFromDB.Startdate = job.Startdate;
                JobFromDB.Companyname = job.Companyname;
                JobFromDB.CompanyImage = job.CompanyImage;
                _context.SaveChanges();
                return Ok(JobFromDB);
            }
        }

        [HttpPost("Create")]
        public IActionResult Create(JobPosting job)
        {
            _context.JobPosts.Add(job);
            _context.SaveChanges();

            return Ok(job);
        }
    }
}
