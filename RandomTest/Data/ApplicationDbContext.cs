using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RandomTest.Models;

namespace RandomTest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<JobPosting> JobPosts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}