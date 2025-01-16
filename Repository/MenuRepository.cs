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
            using (var connection = _context.CreateConnection())
            {
                var menus = await connection.QueryAsync<Menu>("[dbo].[GetMenuList]", new { Type }, commandType: CommandType.StoredProcedure);

                return menus.ToList();
            }
        }
    }
}
