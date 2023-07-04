using Microsoft.AspNetCore.Mvc;

namespace DemoWebApiProject.Controllers
{
    [ApiController]
    [Route("api/gameprogresses")]
    public class GameProgressDemoController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetAllGameProgresses()
        {
            return new JsonResult (GameProgressDataStore.Instance.GameProgresses);
        }

        [HttpGet("{id}")]
        public JsonResult GetASpecificGameProgress(int id)
        {
            return new JsonResult(
                GameProgressDataStore.Instance.GameProgresses.FirstOrDefault(
                    c => c.Id == id
                    )
                );
        }
    }
}
