using ElixirAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ElixirAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentTypeController : ControllerBase
    {
        private readonly ContentTypeRepository _contentTypeRepository;

        public ContentTypeController(ContentTypeRepository contentTypeRepository)
        {
            _contentTypeRepository = contentTypeRepository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetContentTypes()
        {
            try
            {
                var contentTypes = await _contentTypeRepository.GetContentTypes();
                return Ok(contentTypes);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
