using Microsoft.AspNetCore.Mvc;

namespace WebApplicationV1._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public ConfigController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("")]
        public ActionResult GetConfig()
        {
            var config = new {
                AllowedHosts = configuration["AllowedHosts"],
                DefaultConnection = configuration.GetConnectionString("DefaultConnection"),
                //DefaultConnection = configuration["ConnectionStrings:DefaultConnection"]
                DefaultLogLevel = configuration["Logging:LogLevel:Default"],
                TestKey = configuration["TestKey"],
                SigningKey = configuration["Signingkey"]
            };

            return Ok(config);
        }

    }
}
