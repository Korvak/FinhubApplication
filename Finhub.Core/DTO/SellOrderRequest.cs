using Finhub.Core.Attributes;
using Finhub.Core.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finhub.Core.DTO
{
    public class SellOrderRequest
    {
        [Required]
        public string? StockSymbol { get; set; }

        [Required]
        public string? StockName { get; set; }

        //[Should not be older than Jan 01, 2000]
        [MinDate("2000-01-01")]
        public DateTime DateAndTimeOfOrder { get; set; }

        [Range(1, 100000)]
        public uint Quantity { get; set; }

        [Range(1, 10000)]
        public double Price { get; set; }
    }
    public static class SellOrderRequestExtension
    {
        public static SellOrder FromSellOrderRequest(this SellOrder order, SellOrderRequest request)
        {
            order.StockName = request.StockName;
            order.StockSymbol = request.StockSymbol;
            order.Price = request.Price;
            order.Quantity = request.Quantity;
            order.DateAndTimeOfOrder = request.DateAndTimeOfOrder;
            return order;
        }
    }

}
