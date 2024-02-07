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
    public class FinnhubCompanyProfileService : IFinnhubCompanyProfileService
    {

        private readonly IFinnhubRepository _finnhubRepository;

        public FinnhubCompanyProfileService(IFinnhubRepository finnhubRepository)
        {
            _finnhubRepository = finnhubRepository;
        }

        public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
        { //just calls the repository method method with extra controls
            try
            {
                Dictionary<string, object>? result = await _finnhubRepository.GetCompanyProfile(stockSymbol);
                return result;
            }
            catch(HttpRequestException ex)
            { //toy demonstration should be handled using serilog
                throw new FinhubException($"error {ex.StatusCode}. Connection refused.");
            }
        }
    }
}
