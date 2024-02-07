using Finhub.Core.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finhub.Core.DTO
{
    public class BuyOrderResponse
    {
        public Guid BuyOrderID { get; set; }

        public string StockSymbol { get; set; }

        public string StockName { get; set; }

        public DateTime DateAndTimeOfOrder { get; set; }

        public uint Quantity { get; set; }

        public double Price { get; set; }

        public double TradeAmount { get; set; }
    }

    public static class BuyOrderResponseExtension
    {
        public static BuyOrderResponse ToBuyOrderResponse(this BuyOrder order)
        {
            return new BuyOrderResponse()
            {
                BuyOrderID = order.BuyOrderID,
                StockName = order.StockName,
                StockSymbol = order.StockSymbol,
                DateAndTimeOfOrder = order.DateAndTimeOfOrder,
                Price = order.Price,
                Quantity = order.Quantity,
                TradeAmount = order.Quantity
            };
        }
    }
}
