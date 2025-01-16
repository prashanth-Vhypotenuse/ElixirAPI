using ElixirAPI.Handler;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ElixirAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly MenuHandler _menuHandler;

        public MenuController(MenuHandler menuHandler) {
            _menuHandler = menuHandler;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetMenu([FromQuery] string Type)
        {
            Log.Information($"Menu Type {Type}");
            try
            {
                var menu = await _menuHandler.GetMenuList(Type);
                return Ok(menu);
            }
            catch (Exception ex) {
                Log.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
