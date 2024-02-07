using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finhub.Core.ServiceContracts
{
    public interface IFinnhubCompanyProfileService
    {
        public Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol);
    }
}
