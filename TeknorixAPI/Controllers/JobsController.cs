using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TeknorixAPI.Models;
using TeknorixAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeknorixAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _Jobservice;
        private readonly IDepartmentService _JDepartmentservice;
        private readonly ILocationService _Locationservice;
        public JobsController(IJobService JobService,IDepartmentService departmentService,ILocationService locationService)
        {
            _Jobservice = JobService;
            _JDepartmentservice = departmentService;
            _Locationservice = locationService;
        }

        [HttpPost]
        public async Task<ActionResult<List<Job>>> Jobs(Job Job)
        {
            if (ModelState.IsValid)
            {
                Job.Code = Guid.NewGuid();
                Job.PostedDate = DateTime.Now;
                Job.Location = await _Locationservice.GetSingleLocation(Job.LocationID);
                Job.Department = await _JDepartmentservice.GetSingleDepartment(Job.DepartmentID);

                var result = await _Jobservice.AddJob(Job);
                return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created };
            }
            else return BadRequest(ModelState);
            
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Job>>> Job(int id, Job request)
        {
            var result = await _Jobservice.UpdateJob(id, request);
            if (result is null)
                return NotFound("Job not found.");

            return Ok(result);
        }

        [HttpGet]
        //[Route("{searchDto}")]
        public async Task<ActionResult<SearchResultDto>> List([FromQuery]SearchDto searchDto)
        {
            return await _Jobservice.GetAllJobs(searchDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> jobs(int id)
        {
            var result = await _Jobservice.GetSingleJob(id);
            if (result is null)
                return NotFound("Job not found.");

            return Ok(result);
        }


        

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<List<Job>>> DeleteJob(int id)
        //{
        //    var result = await _Jobservice.DeleteJob(id);
        //    if (result is null)
        //        return NotFound("Job not found.");

        //    return Ok(result);
        //}
    }
}
