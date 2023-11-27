using Microsoft.EntityFrameworkCore;
using TeknorixAPI.Data;
using TeknorixAPI.Models;

namespace TeknorixAPI.Services
{
    public class JobService: IJobService
    {
        private readonly DataContext _context;

        public JobService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Job>> AddJob(Job Job)
        {
            _context.Jobs.Add(Job);
            await _context.SaveChangesAsync();
            return await _context.Jobs.ToListAsync();
        }

        public async Task<List<Job>?> DeleteJob(int id)
        {
            var Job = await _context.Jobs.FindAsync(id);
            if (Job is null)
                return null;

            _context.Jobs.Remove(Job);
            await _context.SaveChangesAsync();

            return await _context.Jobs.ToListAsync();
        }

        public async Task<SearchResultDto> GetAllJobs(SearchDto searchDto)
        {
            Jobs result = new Jobs();
            var jobs = from p in _context.Jobs.Where(p => p.Title.StartsWith(searchDto.query))  select p;
            int page = searchDto.PageNo ;
            int pagesize = searchDto.PageSize;
            var jobsl =jobs.Skip((page-1)*pagesize).Take(pagesize).ToList();
            //var Jobs = await _context.Jobs.Where(p =>p.Title.StartsWith(searchDto.query)).ToListAsync();
            SearchResultDto results = new SearchResultDto();
            //results.data = new List<Job>();
            results.data = new List<Jobs>();
            results.Total = jobsl.Count;
            foreach (var Job in jobsl)
            {
                if (searchDto.DepartmentID != null || searchDto.LocationId != null)
                {
                    if(Job.DepartmentID == searchDto.DepartmentID)
                    {
                        result.Title = Job.Title;
                        result.JobID = Job.JobID;
                        result.DepartmentID = Job.DepartmentID;
                        result.Code = Job.Code;
                        result.Description = Job.Description;
                        result.PostedDate = Job.PostedDate;
                        result.ClosedDate = Job.ClosedDate;
                        result.LocationID = Job.LocationID;
                    }
                    if (Job.LocationID == searchDto.LocationId)
                    {
                        result.Title = Job.Title;
                        result.JobID = Job.JobID;
                        result.DepartmentID = Job.DepartmentID;
                        result.Code = Job.Code;
                        result.Description = Job.Description;
                        result.PostedDate = Job.PostedDate;
                        result.ClosedDate = Job.ClosedDate;
                        result.LocationID = Job.LocationID;
                    }
                    
                    results.data.Add(result);
                    result = new Jobs();
                }
                else
                {
                    result.Title = Job.Title;
                    result.JobID = Job.JobID;
                    result.DepartmentID = Job.DepartmentID;
                    result.Code = Job.Code;
                    result.Description = Job.Description;
                    result.PostedDate = Job.PostedDate;
                    result.ClosedDate = Job.ClosedDate;
                    result.LocationID = Job.LocationID;
                    results.data.Add(result);
                    result = new Jobs();
                }
            }
            
            if(jobsl.Count > 0){
                
                return results;
            }
            else
            {
                return null;
            }
            
        }

        public async Task<Job?> GetSingleJob(int id)
        {
            var Job = await _context.Jobs.FindAsync(id);
            if (Job is null)
                return null;
            else
            {
                Job.Location = await _context.Locations.FindAsync(Job.LocationID);
                Job.Department = await _context.Departments.FindAsync(Job.DepartmentID);
            }
            return Job;
        }

        public async Task<List<Job>?> UpdateJob(int id, Job request)
        {
            var Job = await _context.Jobs.FindAsync(id);
            if (Job is null)
                return null;
            Job.DepartmentID = request.DepartmentID;
            Job.LocationID = request.LocationID;
            Job.Description = request.Description;
            Job.Title = request.Title;
            Job.ClosedDate = request.ClosedDate;
            //Job.FirstName = request.FirstName;
            //Job.LastName = request.LastName;
            //Job.DOB = request.DOB;


            await _context.SaveChangesAsync();

            return await _context.Jobs.ToListAsync();
        }
    }
}
