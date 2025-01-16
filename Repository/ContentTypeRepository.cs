using Dapper;
using ElixirAPI.Data;
using ElixirAPI.Models;
using System.Data;

namespace ElixirAPI.Repository
{
    public class ContentTypeRepository
    {
        private readonly DatabaseContext _context;

        public ContentTypeRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContentType>> GetContentTypes()
        {
            using (var connection = _context.CreateConnection())
            {
                var contentTypes = await connection.QueryAsync<ContentType>("[dbo].[GetContentTypes]", commandType: CommandType.StoredProcedure);

                return contentTypes.ToList();
            }
        }
    }
}
