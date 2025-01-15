using ElixirAPI.Repository;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetContent([FromQuery] string Type)
        {
            try
            {
                var content = await _contentRepository.GetContent(Type);
                return Ok(content);
            }
            catch (Exception ex)
            {
                // Error log
                return StatusCode(500, ex.Message);
            }
        }
    }
}
