using Microsoft.AspNetCore.Mvc;

namespace TicketApp.UI.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return new StatusCodeResult(200);
        }
    }
}
