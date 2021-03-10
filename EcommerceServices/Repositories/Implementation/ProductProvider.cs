using Dapper;
using System.Data.SqlClient;
using System.Linq;
using Template.Dtos;
using Template.Repositories.Interfaces;

namespace Template.Repositories.Implementation
{
    public class ProductProvider : IProductProvider
    {
        private readonly string _connectionString;

        public ProductProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ProductDto[] Get()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<ProductDto>(@"SELECT Id, Name, Description, Type FROM Product")
                .ToArray();
        }
    }
}
