using Finhub.Application.Services;
using Finhub.Core.ConfigOptions;
using Finhub.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Finhub.UI.Controllers
{
    public class TradeController : Controller
    {
        private readonly TradingOptions _tradeOptions;

        public TradeController(IOptions<TradingOptions> options) 
        {
            _tradeOptions = options.Value;
        }


        [HttpGet]
        [Route("Trade/Index")]
        public IActionResult Index(
            IFinnhubCompanyProfileService profileService, 
            IFinnhubStockPriceQuoteService quoteService,
            string stockSymbol
            )
        {




            return View();
        }

        [HttpPost]
        [Route("Trade/BuyOrder")]
        public IActionResult BuyOrder()
        {
            return View();
        }

        [HttpPost]
        [Route("Trade/SellOrder")]
        public IActionResult SellOrder()
        {
            return View();
        }

        [HttpGet]
        [Route("Trade/OrdersPDF")]
        public IActionResult OrdersPDF() 
        { 
            return View(); 
        }

    }
}
