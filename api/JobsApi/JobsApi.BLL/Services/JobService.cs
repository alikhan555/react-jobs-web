using JobsApi.DLL.Models;
using JobsApi.DLL.Repositories;

namespace JobsApi.BLL.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository=jobRepository;
        }

        public async Task<List<Job>> GetAllJobs(int _limit)
        {
            List<Job> jobs = await _jobRepository.GetAllJobs();

            if (_limit > 0)
                jobs = jobs.Take(_limit).ToList();

            return jobs;
        }

        public async Task<Job> GetJobById(string id)
        {
            Job job = await _jobRepository.GetJobById(id);
            return job;
        }

        public async Task SaveJob(Job Job)
        {
            await _jobRepository.SaveJob(Job);
        }

        public async Task UpdateJob(string id, Job Job)
        {
            Job.Id = id;
            await _jobRepository.UpdateJob(Job);
        }

        public async Task DeleteJob(string id)
        {
            await _jobRepository.DeleteJob(id);
        }
    }
}
