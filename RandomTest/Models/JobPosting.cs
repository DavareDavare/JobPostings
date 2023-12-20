namespace RandomTest.Models
{
    public class JobPosting
    {
        public int id { get; set; }
        public string JobTitle { get; set; }
        public string JobLocation { get; set; }
        public string JobDescription { get; set; }
        public float Salary { get; set; }
        public DateTime Startdate { get; set; }
        public string? Companyname { get; set; }
        public byte[] CompanyImage { get; set; }

        public string? OwnerUsername { get; set; }

    }
}
