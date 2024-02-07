using Finhub.Core.Domain.Entitites;
using Finhub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finhub.Core.ServiceContracts
{
    public interface IStocksService
    {
        public Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest request);

        public Task<SellOrderResponse> CreateSellOrder(SellOrderRequest sellOrder);

        public Task<List<BuyOrderResponse>> GetBuyOrders();

        public Task<List<SellOrderResponse>> GetSellOrders();
    }
}
