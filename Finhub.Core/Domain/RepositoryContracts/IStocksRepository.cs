using Finhub.Core.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finhub.Core.Domain.RepositoryContracts
{
    public interface IStocksRepository
    {
        public Task<BuyOrder> CreateBuyOrder(BuyOrder buyOrder);

        public Task<SellOrder> CreateSellOrder(SellOrder sellOrder);

        public Task<List<BuyOrder>> GetBuyOrders();

        public Task<List<SellOrder>> GetSellOrders();
    }
}
