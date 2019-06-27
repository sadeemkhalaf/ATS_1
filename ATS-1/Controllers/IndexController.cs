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
    public class IndexController : ControllerBase
    {
        // GET: api/Index
        [HttpGet(Name = "GetIndex")]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET: api/Index/5
        [HttpGet("{id}", Name = "GetAllIndex")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Index
        [HttpPost(Name = "PostIndex")]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Index/5
        [HttpPut("{id}", Name = "PutIndex")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "DeleteIndex")]
        public void Delete(int id)
        {
        }
    }
}
