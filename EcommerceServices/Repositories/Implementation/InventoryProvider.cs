using Dapper;
using System.Data.SqlClient;
using System.Linq;
using Template.Dtos;
using Template.Repositories.Interfaces;

namespace Template.Repositories.Implementation
{
    public class InventoryProvider: IInventoryProvider
    {
        private readonly string _connectionString;

        public InventoryProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public InventoryDto[] Get()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<InventoryDto>(@"SELECT Id, Name, Quantity, ProductId FROM Inventory")
                .ToArray();
        }
    }
}
