using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Template.Dtos;
using Template.Repositories.Interfaces;

namespace Template.Repositories.Implementation
{
    public class OrderDetailsProvider : IOrderDetailsProvider, 
                                        IRepository<OrderDetail, OrderDto>
    {
        private readonly string _connectionString;

        public OrderDetailsProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<string> CancelOrder(int id, string reason, int cencelledBy)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Create(OrderDto item)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<OrderDetail>> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            var res = await connection.QueryAsync<OrderDetail>(@"SELECT o.UserName AS [User], od.ProductName AS Name, od.Quantity  FROM [Order] o
                                                JOIN [OrderDetail] od on o.Id = od.OrderId");

            return res;
        }

        public Task<OrderDetail> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Update(OrderDto item)
        {
            throw new System.NotImplementedException();
        }
    }
}
