﻿using System;
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
    public class ValuesController : ControllerBase
    {
        private readonly IApplicantService _applicantService;
        public ValuesController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_applicantService.GetApplicants());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_applicantService.GetApplicant(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Applicant applicant)
        {
            _applicantService.UpdateApplicant(applicant, id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _applicantService.DeleteApplicant(id);
        }
    }
}