using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS_1.Models;
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

        public InboxController(IInboxService _inboxService)
        {
            inboxService = _inboxService;
        }
        // GET: api/Inbox
        [HttpGet(Name = "GetAllInbox")]
        public IActionResult Get()
        {
            return Ok(this.inboxService.GetAllInbox());
        }

        [HttpGet("{id}", Name = "GetInbox")]
        public IActionResult Get(int id)
        {
            return Ok(this.inboxService.GetInbox(id));
        }

        // POST: api/Inbox
        [HttpPost(Name = "PostInbox")]
        public void Post([FromBody] Inbox InboxedApplicant)
        {
            this.inboxService.InsertInbox(InboxedApplicant);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "DeleteInbox")]
        public void Delete(int id)
        {
            this.inboxService.DeleteInbox(id);
        }
    }
}
