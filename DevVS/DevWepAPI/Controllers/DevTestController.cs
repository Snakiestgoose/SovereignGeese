using Microsoft.AspNetCore.Mvc;
using Data.Factory.Dev;

namespace DevWepAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevTestController : ControllerBase
    {
        public DevFactory devFactory { get; set; }

        public DevTestController()
        {
            devFactory = new DevFactory();
        }

        [HttpGet(Name = "GetDevTest")]
        public bool Get()
        {
            return devFactory.GetDevUserId() == 1;
        }
    }
}
