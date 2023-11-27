using TeknorixAPI.Models;

namespace TeknorixAPI.Services
{
    public interface IJobService
    {
        Task<SearchResultDto> GetAllJobs(SearchDto searchDto);
        Task<Job?> GetSingleJob(int id);
        Task<List<Job>> AddJob(Job Job);
        Task<List<Job>?> UpdateJob(int id, Job request);
        Task<List<Job>?> DeleteJob(int id);
    }
}
