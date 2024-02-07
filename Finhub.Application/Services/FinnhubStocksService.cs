using Finhub.Core.ConfigOptions;
using Finhub.Core.Domain.RepositoryContracts;
using Finhub.Core.Exceptions;
using Finhub.Core.ServiceContracts;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finhub.Application.Services
{
    public class FinnhubStocksService : IFinnhubStocksService
    {
        private readonly IFinnhubRepository _finnhubRepository;
        private readonly TradingOptions _tradeOptions;

        public FinnhubStocksService(IFinnhubRepository finnhubRepository, IOptions<TradingOptions> options)
        {
            _finnhubRepository = finnhubRepository;
            _tradeOptions = options.Value;
        }

        public async Task<List<Dictionary<string, string>>?> GetStocks(string? exchange = null)
        {
            try
            {
                exchange = exchange ?? _tradeOptions.DefaultExchange;
                return await _finnhubRepository.GetStocks(exchange);
            }
            catch (HttpRequestException ex)
            { //toy demonstration should be handled using serilog
                throw new FinhubException($"error {ex.StatusCode}. Connection refused.");
            }
        }
    }
}
