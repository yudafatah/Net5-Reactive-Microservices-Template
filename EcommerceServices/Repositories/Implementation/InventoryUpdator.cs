using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Template.Repositories.Interfaces;

namespace Template.Repositories.Implementation
{
    public class InventoryUpdator: IInventoryUpdator
    {
        private readonly string connectionString;

        public InventoryUpdator(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task Update(int productId, int quantity)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("UPDATE_INVENTORY", new { productId, quantity }, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
