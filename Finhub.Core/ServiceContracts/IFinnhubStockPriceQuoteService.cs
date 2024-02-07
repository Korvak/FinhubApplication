using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finhub.Core.ServiceContracts
{
    public interface IFinnhubStockPriceQuoteService
    {
        public Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);
    }
}
