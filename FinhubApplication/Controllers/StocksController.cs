using Finhub.Core.ConfigOptions;
using Finhub.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Finhub.UI.Controllers
{
    public class StocksController : Controller
    {

        private readonly IFinnhubStocksService _stocksService;
        private readonly TradingOptions _tradeOptions;

        public StocksController(IFinnhubStocksService stocksService, IOptions<TradingOptions> options)
        {
            _stocksService = stocksService;
            _tradeOptions = options.Value;
        }

        [HttpGet]
        [Route("/")]
        [Route("Stocks/Explore")]
        public IActionResult Explore()
        { //the base page, displays the top 25 stocks as a list
            _stocksService.GetStocks();



            return View();
        }
    }
}
