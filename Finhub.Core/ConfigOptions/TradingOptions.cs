using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finhub.Core.ConfigOptions
{
    public class TradingOptions
    {
        public uint DefaultOrderQuantity { get; set; }
        public string DefaultStockSymbol { get; set; }
        public string DefaultExchange {  get; set; }
        public List<string> Top25PopularStocks { get; set; }
    }
}
