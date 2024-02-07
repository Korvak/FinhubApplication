using Finhub.Core.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finhub.Core.DTO
{
    public class SellOrderResponse
    {
        public Guid SellOrderID { get; set; }

        public string StockSymbol { get; set; }

        public string StockName { get; set; }

        public DateTime DateAndTimeOfOrder { get; set; }

        public uint Quantity { get; set; }

        public double Price { get; set; }

        public double TradeAmount { get; set; }
    }

    public static class SellOrderResponseExtension
    {
        public static SellOrderResponse ToSellOrderResponse(this SellOrder order)
        {
            return new SellOrderResponse()
            {
                SellOrderID = order.SellOrderID,
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
