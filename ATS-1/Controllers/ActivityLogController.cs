using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ATS_1.Models;
using ATS_1.Services;

namespace ATS_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityLogController : ControllerBase
    {
        private readonly IActivityLogService _ActivityLogService;

        public ActivityLogController(IActivityLogService ActivityLogService)
        {
            _ActivityLogService = ActivityLogService;
        }

        [HttpGet]
        public IActionResult GetActivityLog()
        {
            return Ok(_ActivityLogService.GetAllActivityLog().ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityLog>> GetActivityLog(int id)
        {
            return Ok(this._ActivityLogService.GetActivityLog(id));
        }

        [HttpPost]
        public void PostActivityLog(ActivityLog activityLog)
        {
            this._ActivityLogService.InsertLog(activityLog);
        }

        [HttpDelete("{id}", Name = "DeleteActivityLog")]
        public void DelteActivityLog(int id)
        {
            this._ActivityLogService.DeleteActivityLog(id);
        }
    }
}
