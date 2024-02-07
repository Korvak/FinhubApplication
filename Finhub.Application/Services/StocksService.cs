using Finhub.Core.Domain.Entitites;
using Finhub.Core.Domain.RepositoryContracts;
using Finhub.Core.DTO;
using Finhub.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finhub.Application.Services
{
    public class StocksService : IStocksService
    {
        private readonly IStocksRepository _stocksRepository;

        public StocksService(IStocksRepository stocksRepository)
        {
            _stocksRepository = stocksRepository;
        }

        public async Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest request)
        {
            BuyOrder order = new BuyOrder();
            order.FromBuyOrderRequest(request);
            BuyOrder result = await _stocksRepository.CreateBuyOrder(order);
            return result.ToBuyOrderResponse();
        }

        public async Task<SellOrderResponse> CreateSellOrder(SellOrderRequest request)
        {
            //the DTO must not know the structure of the entity it is based upon
            SellOrder order = new SellOrder();
            order.FromSellOrderRequest(request); //extension method to set the data.
            SellOrder result = await _stocksRepository.CreateSellOrder(order);
            return result.ToSellOrderResponse();
        }

        public async Task<List<BuyOrderResponse>> GetBuyOrders()
        {
            List<BuyOrder> orders = await _stocksRepository.GetBuyOrders();
            List<BuyOrderResponse> buyOrders = new List<BuyOrderResponse>();
            foreach (BuyOrder order in orders)
            {
                buyOrders.Add(order.ToBuyOrderResponse());
            }
            return buyOrders;
        }

        public async Task<List<SellOrderResponse>> GetSellOrders()
        {
            List<SellOrder> orders = await _stocksRepository.GetSellOrders();
            List<SellOrderResponse> buyOrders = new List<SellOrderResponse>();
            foreach (SellOrder order in orders)
            {
                buyOrders.Add(order.ToSellOrderResponse());
            }
            return buyOrders;
        }
    }
}
