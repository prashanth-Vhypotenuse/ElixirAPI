using System.Data;
using Dapper;
using ElixirAPI.Data;
using ElixirAPI.Models;

namespace ElixirAPI.Repository
{
    public class MenuRepository
    {
        private readonly DatabaseContext _context;

        public MenuRepository(DatabaseContext context) { 
            _context = context;
        }

        public async Task<IEnumerable<Menu>> GetMenu(string Type)
        {
            //var query = "SELECT * FROM Menu WHERE Type = @Type";

            using (var connection = _context.CreateConnection())
            {
                var menuList = await connection.QueryAsync<Menu>("[dbo].[GetMenuList]", new { Type }, commandType: CommandType.StoredProcedure);

                var menus = menuList.Where(m => m.ParentId == null).ToList();
                foreach (var menu in menus)
                {
                    menu.SubMenus = menuList.Where(m => m.ParentId == menu.Id).ToList();
                }
                return menus;
            }
        }
    }
}
