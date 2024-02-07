using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finhub.Core.ServiceContracts
{
    public interface IFinnhubStocksService
    {
        public Task<List<Dictionary<string, string>>?> GetStocks();
    }
}
