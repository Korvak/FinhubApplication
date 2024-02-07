using Finhub.Core.Domain.RepositoryContracts;
using Finhub.Core.Exceptions;
using Finhub.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finhub.Application.Services
{
    public class FinnhubSearchStocksService : IFinnhubSearchStocksService
    {
        private readonly IFinnhubRepository _finnhubRepository;

        public FinnhubSearchStocksService(IFinnhubRepository finnhubRepository)
        {
            _finnhubRepository = finnhubRepository;
        }

        public async Task<Dictionary<string, object>?> SearchStocks(string stockSymbolToSearch)
        {
            try
            {
                return await _finnhubRepository.SearchStocks(stockSymbolToSearch);
            }
            catch (HttpRequestException ex)
            { //toy demonstration should be handled using serilog
                throw new FinhubException($"error {ex.StatusCode}. Connection refused.");
            }
        }
    }
}
