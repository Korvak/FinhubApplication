using Finhub.Core.Domain.ConfigOptions;
using Finhub.Core.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fihub.Infrastructure.Repository
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

        protected async Task<HttpResponseMessage> SendFinhubRequest(string stockSymbol, string methodName, HttpMethod method)
        {
            //a shared method for Finuhb general requests
            using (HttpClient client = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"{_options.Weburl}/{methodName}?symbol={stockSymbol}&token={_options.ApiKey}"),
                    Method = method
                };
                return await client.SendAsync(request);
            }
        }

        public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
        {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Dictionary<string, string>>?> GetStocks()
        {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<string, object>?> SearchStocks(string stockSymbolToSearch)
        {
            throw new NotImplementedException();
        }
    }
}
