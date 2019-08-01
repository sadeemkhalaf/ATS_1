using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS_1.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATS_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantStatusHistoryController : ControllerBase
    {
        private readonly IApplicantStatusHistoryService _applicantStatusHistory;

        public ApplicantStatusHistoryController(IApplicantStatusHistoryService applicantStatusHistory) {
            _applicantStatusHistory = applicantStatusHistory;
        }

        [EnableCors("myAllowedOrigins")]
        [Route("")]
        [Route("applicants")]
        [HttpGet]
        public IActionResult GetAllApplicantsStatusHistories()
        {
            return Ok(_applicantStatusHistory.GetAllApplicantStatusHistory());
        }
        [EnableCors("myAllowedOrigins")]
        [Route("")]
        [Route("applicants")]
        [HttpGet ("{id}")]
        public IActionResult GetApplicantsStatusHistories(int id)
        {
            return Ok(_applicantStatusHistory.GetAllApplicantStatusHistory(id));
        }
        [HttpDelete("{id}")]
        public void DeleteApplicantsStatusHistories(int id)
        {
            _applicantStatusHistory.DeleteApplicantStatusHistory(id);
        }
    }
}