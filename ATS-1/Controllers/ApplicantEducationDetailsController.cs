using System.Collections.Generic;
using ATS_1.Models;
using ATS_1.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ATS_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantEducationDetailsController : ControllerBase
    {
        private readonly ApplicantEducationDetailsService applicantEducationDetailsService;
        // GET: api/ApplicantEducationDetails
        [EnableCors("myAllowedOrigins")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(applicantEducationDetailsService.GetAll());
        }

        // GET: api/ApplicantEducationDetails/5
        [EnableCors("myAllowedOrigins")]
        [HttpGet("{id}", Name = "GetAllApplicantEducationDetails")]
        public IActionResult GetAllApplicantEducationDetails(int id)
        {
            return Ok(applicantEducationDetailsService.GetAllApplicantEducationDetails(id));
        }

        [EnableCors("myAllowedOrigins")]
        [HttpPost]
        public void Post([FromBody] List<ApplicantEducationDetails> educationDetails)
        {
            this.applicantEducationDetailsService.AddEducationField(educationDetails);
        }

        [EnableCors("myAllowedOrigins")]
        [HttpPut("{id}")]
        public void Put([FromBody] ApplicantEducationDetails educationField)
        {
            applicantEducationDetailsService.EditEducationField(educationField);
        }

        [EnableCors("myAllowedOrigins")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            applicantEducationDetailsService.DeleteEducationField(id);
        }
    }
}
