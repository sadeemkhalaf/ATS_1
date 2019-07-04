using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS_1.Services;
using Microsoft.AspNetCore.Mvc;
using ATS_1.Models;
using Microsoft.AspNetCore.Cors;

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

        [EnableCors("myAllowedOrigins")]
        [Route("")]
        [Route("applicants")]
        [HttpGet]
        public IActionResult GetApplicants()
        {
            return Ok(_applicantService.GetApplicants());
        }

        // GET api/applicants/5
        [HttpGet("{id}", Name = "GetApplicant")]
        public ActionResult GetApplicant(int id)
        {
            return Ok(_applicantService.GetApplicant(id));
        }

        // POST api/applicants
        [EnableCors("myAllowedOrigins")]
        [HttpPost(Name = "PostApplicant")]
        public void Post([FromBody] Applicant applicant)
        {
            _applicantService.InsertApplicant(applicant);
        }

        // PUT api/applicants/5
        [EnableCors("myAllowedOrigins")]
        [HttpPut("{id}", Name = "PutApplicant")]
        public void UpdateApplicant(int id, [FromBody] Applicant applicant)
        {
            _applicantService.UpdateApplicant(applicant, id);
        }

        // DELETE api/applicants/5
        [EnableCors("myAllowedOrigins")]
        [HttpDelete("{id}", Name ="DeleteApplicant")]
        public void DeleteApplicant(int id)
        {
            _applicantService.DeleteApplicant(id);
        }
    }
}
