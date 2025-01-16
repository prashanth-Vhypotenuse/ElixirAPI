using ElixirAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ElixirAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly ContentRepository _contentRepository;

        public ContentController(ContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetContent([FromQuery] string Type)
        {
            Log.Information($"Content Type {Type}");

            try {
                var content = await _contentRepository.GetContent(Type);
                return Ok(content);
            }
            catch (Exception ex) {
                Log.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
