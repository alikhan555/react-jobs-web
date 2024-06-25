using JobsApi.DLL.Models;

namespace JobsApi.DLL.Repositories
{
    public interface IJobRepository
    {
        Task<List<Job>> GetAllJobs();
        Task<Job> GetJobById(string id);
        Task<int> SaveJob(Job job);
        Task<int> UpdateJob(Job job);
        Task<int> DeleteJob(string id);
    }
}
