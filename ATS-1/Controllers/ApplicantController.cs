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

        // GET api/applicants/status
        [HttpGet("count/{status}", Name = "GetStatusCountQueryResult")]
        public ActionResult GetStatusCountQueryResult(string status)
        {
            return Ok(_applicantService.GetStatusCountQueryResult(status));
        }

        [HttpGet("status/{status}", Name = "GetByStatusQueryResult")]
        public ActionResult GetByStatusQueryResult(string status)
        {
            return Ok(_applicantService.GetApplicantByStatus(status));
        }

        // POST api/applicants
        [EnableCors("myAllowedOrigins")]
        [HttpPost(Name = "PostApplicant")]
        public IActionResult Post([FromBody] Applicant applicant)
        {
            Applicant applicantFound = _applicantService.FindSimilarApplicant(applicant.Email, applicant.PhoneNumber);
            if (applicantFound == null)
            {
                _applicantService.InsertApplicant(applicant);
                return Ok("Successfully added a new applicant");
            }
            else
            {
                return Ok(applicantFound.Name + " is allready added");
            }

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
        [HttpDelete("{id}", Name = "DeleteApplicant")]
        public void DeleteApplicant(int id)
        {
            _applicantService.DeleteApplicant(id);
        }

        // POST api/applicants
        [EnableCors("myAllowedOrigins")]
        [HttpPost("query", Name = "QueryApplicants")]
        public IActionResult QueryApplicants([FromBody] ApplicantQueryStructure query)
        {
            List<Applicant> applicantsFound = _applicantService.GetApplicantsQueryResult(query);
            if (applicantsFound != null)
            {
                return Ok(applicantsFound);
            } else {
                return Ok("there are no records found matchiung your query!");
            }

        }
    }

}
