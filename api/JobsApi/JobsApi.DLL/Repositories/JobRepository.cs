using JobsApi.DLL.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsApi.DLL.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly JobDbContext _context;

        public JobRepository(JobDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<int> DeleteJob(string id)
        {
            Job job = await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);

            if (job == null)
                return 0;

            _context.Remove(job);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Job>> GetAllJobs()
        {
            List<Job> jobs = await _context.Jobs.ToListAsync();
            return jobs;
        }

        public async Task<Job> GetJobById(string id)
        {
            Job job = await _context.Jobs.SingleOrDefaultAsync(x => x.Id == id);
            return job;
        }

        public async Task<int> SaveJob(Job job)
        {
            job.Id = Guid.NewGuid().ToString();
            await _context.Jobs.AddAsync(job);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateJob(Job job)
        {
            Job jobInDb = await _context.Jobs.SingleOrDefaultAsync(x => x.Id == job.Id);

            if (jobInDb is null)
                return 0;

            jobInDb.Title = job.Title;
            jobInDb.Type = job.Type;
            jobInDb.Description = job.Description;
            jobInDb.Location = job.Location;
            jobInDb.Salary = job.Salary;
            jobInDb.CompanyName = job.CompanyName;
            jobInDb.CompanyDescription = job.CompanyDescription;
            jobInDb.CompanyContactEmail = job.CompanyContactEmail;
            jobInDb.CompanyContactPhone = job.CompanyContactPhone;

            return await _context.SaveChangesAsync();
        }
    }
}
