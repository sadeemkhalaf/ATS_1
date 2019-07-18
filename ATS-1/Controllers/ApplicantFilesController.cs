using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS_1.Models;
using ATS_1.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATS_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantFilesController : ControllerBase
    {
        private readonly IApplicantFilesService applicantFilesService;
        [HttpGet]
        [EnableCors("myAllowedOrigins")]
        public IActionResult GetAllFiles()
        {
            return Ok(applicantFilesService.GetAllFiles());
        }

        [HttpGet("{ApplicantId}")]
        [EnableCors("myAllowedOrigins")]
        public IActionResult GetAllApplicantFiles(int ApplicantId)
        {
            return Ok(applicantFilesService.GetAllApplicantFiles(ApplicantId));
        }

        [HttpGet("{applicantId}/{id}")]
        [EnableCors("myAllowedOrigins")]
        public IActionResult GeApplicantFile(int applicantId, int id)
        {
            return Ok(applicantFilesService.GetFile(applicantId, id));
        }

        [HttpPost]
        [EnableCors("myAllowedOrigins")]
        public void Post([FromBody] List<ApplicantFiles> files)
        {
            applicantFilesService.AddFiles(files);
        }

        [HttpDelete("{id}")]
        [EnableCors("myAllowedOrigins")]
        public void Delete(int id)
        {
            applicantFilesService.DeleteFile(id);
        }
    }
}
