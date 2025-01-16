using System.Data;
using Dapper;
using ElixirAPI.Data;
using ElixirAPI.Models;

namespace ElixirAPI.Repository
{
    public class ContentRepository
    {
        private readonly DatabaseContext _context;

        public ContentRepository(DatabaseContext context) { 
            _context = context;
        }

        public async Task<IEnumerable<Content>> GetContent(string Type)
        {
            using (var connection = _context.CreateConnection())
            {
                var content = await connection.QueryAsync<Content>("[dbo].[GetContent]", new { Type }, commandType: CommandType.StoredProcedure);
                return content.ToList();
            }
        }

    }
}
