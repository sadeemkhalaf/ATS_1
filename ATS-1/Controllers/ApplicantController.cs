using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS_1.Services;
using Microsoft.AspNetCore.Mvc;
using ATS_1.Models;

namespace ATS_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        private readonly IApplicantService _applicantService;
        public ApplicantsController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }
        // GET api/applicants
        [HttpGet(Name = "GetApplicants")]
        public IActionResult Get()
        {
            return Ok(_applicantService.GetApplicants());
        }

        // GET api/applicants/5
        [HttpGet("{id}", Name = "GetApplicant")]
        public ActionResult Get(int id)
        {
            return Ok(_applicantService.GetApplicant(id));
        }

        // POST api/applicants
        [HttpPost(Name = "PostApplicant")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/applicants/5
        [HttpPut("{id}", Name = "PutApplicant")]
        public void Put(int id, [FromBody] Applicant applicant)
        {
            _applicantService.UpdateApplicant(applicant, id);
        }

        // DELETE api/applicants/5
        [HttpDelete("{id}", Name ="DeleteApplicant")]
        public void Delete(int id)
        {
            _applicantService.DeleteApplicant(id);
        }
    }
}
