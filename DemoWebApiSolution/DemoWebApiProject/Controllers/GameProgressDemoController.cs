using Microsoft.AspNetCore.Mvc;

namespace DemoWebApiProject.Controllers
{
    [ApiController]
    [Route("api/gameprogresses")]
    public class GameProgressDemoController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetGameProgress()
        {
            return new JsonResult (
                new List<object> {
                    new {
                        id = 1,
                        Name = "心灵终结 Mental Omega",
                        ChineseName = "心灵终结",
                        EnglishName = "Mental Omega"
                    },
                    new {
                        id = 2,
                        Name = "tormented souls",
                        ChineseName = "折磨之魂",
                        EnglishName = "tormented souls"
                    },
                }
                );
        }
    }
}
