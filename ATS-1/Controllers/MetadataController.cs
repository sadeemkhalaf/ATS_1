using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ATS_1.Models;
using ATS_1.Services;

namespace ATS_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetadataController : ControllerBase
    {
        private readonly IMetadataService _metadataService;

        public MetadataController(IMetadataService metadataService)
        {
            _metadataService = metadataService;
        }

        // GET: api/Metadatas
        [HttpGet]
        public IActionResult GetMetadata()
        {
            return Ok(_metadataService.GetAllMetadata().ToList());
        }

        // GET: api/Metadatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Metadata>> GetMetadata(int id)
        {
            return Ok(this._metadataService.GetMetadata(id));
        }

        // POST: api/Metadatas
        [HttpPost]
        public void PostMetadata(Metadata metadata)
        {
            this._metadataService.InsertMetadata(metadata);
        }
    }
}
