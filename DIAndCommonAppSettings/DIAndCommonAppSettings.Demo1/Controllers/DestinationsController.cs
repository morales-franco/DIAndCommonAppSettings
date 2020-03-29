using DIAndCommonAppSettings.Demo1.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DIAndCommonAppSettings.Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly AppSettings _appSettings;

        //Inject appSettings using Option pattern
        public DestinationsController(IOptionsSnapshot<AppSettings> appSettings)
        {
            //IOptionsSnapshot retrieve the appSeetings value per request
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new 
            {
                _appSettings.RefreshGridTimerInSeconds,
                _appSettings.RowsPerPage,
                _appSettings.StorageAddress
            });
        }
    }
}