using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS_1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATS_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InboxController : ControllerBase
    {
        private readonly IInboxService inboxService;

        public InboxController(IInboxService _inboxService) {
            inboxService = _inboxService;
        }
        // GET: api/Inbox
        [HttpGet(Name = "GetAllInbox")]
        public IActionResult Get()
        {
            return Ok(this.inboxService.GetAllInbox());
        }

        // GET: api/Inbox/5
        [HttpGet("{id}", Name = "GetInbox")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Inbox
        [HttpPost(Name = "PostInbox")]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Inbox/5
        [HttpPut("{id}", Name = "PutInbox")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "DeleteInbox")]
        public void Delete(int id)
        {
        }
    }
}
