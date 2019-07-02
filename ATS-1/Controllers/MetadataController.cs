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
            var metadata = _metadataService.GetMetadata(id);

            if (metadata == null)
            {
                return NotFound();
            }

            return metadata;
        }

        // POST: api/Metadatas
        [HttpPost]
        public async Task<ActionResult<Metadata>> PostMetadata(Metadata metadata)
        {
            //_context.Metadata.Add(metadata);
            //  await _context.SaveChangesAsync();

            //return CreatedAtAction("GetMetadata", new { id = metadata.Id }, metadata);
            return null;
        }

        private bool MetadataExists(int id)
        {
            //return _context.Metadata.Any(e => e.Id == id);
            return false;
        }
    }
}
