using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebApplicationV1._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration configuration;
        // IOptions Registered as Singleton
        private readonly IOptionsSnapshot<AttachmentsOptions> attachments;



        public ConfigController(IConfiguration configuration,
            IOptionsSnapshot<AttachmentsOptions> attachments)
        {
            this.configuration = configuration;
            this.attachments = attachments;
            var value = attachments.Value;
        }

        [HttpGet]
        [Route("GetConfig")]
        public ActionResult GetConfig()
        {
            var config = new {
                AllowedHosts = configuration["AllowedHosts"],
                DefaultConnection = configuration.GetConnectionString("DefaultConnection"),
                //DefaultConnection = configuration["ConnectionStrings:DefaultConnection"]
                DefaultLogLevel = configuration["Logging:LogLevel:Default"],
                TestKey = configuration["TestKey"],
                SigningKey = configuration["Signingkey"],
                AttachmentsOptions = attachments.Value
            };

            return Ok(config);
        }

    }
}
