using Microsoft.AspNetCore.Mvc;
using Data.Factory.Dev;

namespace DevWebAPI.Controllers
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

        [HttpGet]
        [Route("DBConnectionTest")]
        public bool DBConnectionTest()
        {
            bool result = devFactory.GetDevUserId() == 1;
            return result;
        }

        [HttpGet]
        [Route("MathAdd/{a}/{b}")]
        public int MathAdd(int a, int b)
        {
            return a + b;
        }
    }
}
