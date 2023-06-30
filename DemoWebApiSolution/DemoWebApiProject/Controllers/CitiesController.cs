using Microsoft.AspNetCore.Mvc;

namespace DemoWebApiProject.Controllers
{
    [ApiController]
    public class CitiesController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
