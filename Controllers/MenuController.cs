using ElixirAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElixirAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly MenuRepository _menuRepository;

        public MenuController(MenuRepository menuRepository) {
            _menuRepository = menuRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMenu([FromQuery] string Type)
        {
            try
            {
                var menu = await _menuRepository.GetMenu(Type);
                return Ok(menu);
            }
            catch (Exception ex) { 
                return StatusCode(500, ex.Message);
            }
        }
    }
}
