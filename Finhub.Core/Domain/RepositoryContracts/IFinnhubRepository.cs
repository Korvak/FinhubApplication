using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finhub.Core.Domain.RepositoryContracts
{
    public interface IFinnhubRepository
    {
        public Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol);

        public Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);

        public Task<List<Dictionary<string, string>>?> GetStocks();

        public Task<Dictionary<string, object>?> SearchStocks(string stockSymbolToSearch);
    }
}
