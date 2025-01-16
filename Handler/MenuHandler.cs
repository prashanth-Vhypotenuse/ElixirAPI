using ElixirAPI.Models;
using ElixirAPI.Repository;
using Serilog;

namespace ElixirAPI.Handler
{
    public class MenuHandler
    {
        private readonly MenuRepository _menuRepository;

        public MenuHandler(MenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IEnumerable<Menu>> GetMenuList(string Type)
        {
            var menus = await _menuRepository.GetMenu(Type);

            var menuList = menus.Where(m => m.ParentId == null).ToList();
            foreach (var menu in menuList)
            {
                menu.SubMenus = menus.Where(m => m.ParentId == menu.Id).ToList();
            }
            return menuList;
        }
    }
}
