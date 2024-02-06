using Finhub.Core.Domain.Entitites;
using Finhub.Core.Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finhub.Infrastructure.Repository
{
    public class StocksRepository : IStocksRepository
    {
        public Task<BuyOrder> CreateBuyOrder(BuyOrder buyOrder)
        {
            throw new NotImplementedException();
        }

        public Task<SellOrder> CreateSellOrder(SellOrder sellOrder)
        {
            throw new NotImplementedException();
        }

        public Task<List<BuyOrder>> GetBuyOrders()
        {
            throw new NotImplementedException();
        }

        public Task<List<SellOrder>> GetSellOrders()
        {
            throw new NotImplementedException();
        }
    }
}
