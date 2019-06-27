using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATS_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetadataController : ControllerBase
    {
        // GET: api/Metadata
        [HttpGet(Name = "GetAllMetadata")]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET: api/Metadata/5
        [HttpGet("{id}", Name = "GetMetadata")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Metadata
        [HttpPost(Name = "PostMetadata")]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Metadata/5
        [HttpPut("{id}", Name = "PutMetadata")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "DeleteMetadata")]
        public void Delete(int id)
        {
        }
    }
}
