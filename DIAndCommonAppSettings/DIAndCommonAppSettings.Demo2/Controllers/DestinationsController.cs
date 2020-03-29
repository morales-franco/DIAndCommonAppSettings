using DIAndCommonAppSettings.Demo2.Services;
using Microsoft.AspNetCore.Mvc;

namespace DIAndCommonAppSettings.Demo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private IAppSettingService _appSettingService;

        public DestinationsController(IAppSettingService appSettingService)
        {
            _appSettingService = appSettingService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                _appSettingService.RefreshGridTimerInSeconds,
                _appSettingService.RowsPerPage,
                _appSettingService.StorageAddress
            });
        }

    }
}