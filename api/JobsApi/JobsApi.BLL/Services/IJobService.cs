using JobsApi.DLL.Models;

namespace JobsApi.BLL.Services
{
    public interface IJobService
    {
        Task<List<Job>> GetAllJobs(int _limit);
        Task<Job> GetJobById(string id);
        Task SaveJob(Job Job);
        Task UpdateJob(string id, Job Job);
        Task DeleteJob(string id);
    }
}
