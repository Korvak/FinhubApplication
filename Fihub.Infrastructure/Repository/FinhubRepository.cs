using Finhub.Core.ConfigOptions;
using Finhub.Core.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Finhub.Infrastructure.Repository
{
    public class FinhubRepository : IFinnhubRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly FinhubOptions _options;

        public FinhubRepository(IHttpClientFactory httpClientFactory, IOptions<FinhubOptions> options) 
        {
            _httpClientFactory = httpClientFactory;
            _options = options.Value;
        }

        protected async Task<string> ReadResponseAsString(HttpResponseMessage response)
        {
            Stream stream = await response.Content.ReadAsStreamAsync();
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        protected async Task<HttpResponseMessage> SendFinhubRequest(string stockSymbol, string methodName, HttpMethod method, 
            string searchMethod = "symbol")
        {
            /** a shared method for Finuhb API general requests
             */
            using (HttpClient client = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"{_options.Weburl}/{methodName}?{searchMethod}={stockSymbol}&token={_options.ApiKey}"),
                    Method = method
                };
                return await client.SendAsync(request);
            }
        }

        public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
        {
            HttpResponseMessage response = await SendFinhubRequest(stockSymbol, "stock/profile2", HttpMethod.Get);
            string jsonData = await ReadResponseAsString(response);
            return JsonSerializer.Deserialize<Dictionary<string, object>?>(jsonData);
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            HttpResponseMessage response = await SendFinhubRequest(stockSymbol, "quote", HttpMethod.Get);
            string jsonData = await ReadResponseAsString(response);
            return JsonSerializer.Deserialize<Dictionary<string, object>?>(jsonData);
        }

        public async Task<List<Dictionary<string, string>>?> GetStocks(string? exchange = "US")
        { 
            HttpResponseMessage response = await SendFinhubRequest(exchange ?? "US", "symbol", HttpMethod.Get, "exchange");
            string jsonData = await ReadResponseAsString(response);
            return JsonSerializer.Deserialize<List<Dictionary<string, string>>?>(jsonData);
        }

        public async Task<Dictionary<string, object>?> SearchStocks(string stockSymbolToSearch)
        {
            HttpResponseMessage response = await SendFinhubRequest(stockSymbolToSearch, "quote", HttpMethod.Get, "q");
            string jsonData = await ReadResponseAsString(response);
            return JsonSerializer.Deserialize<Dictionary<string, object>?>(jsonData);
        }
    }
}
