using DIAndCommonAppSettings.Demo3.Repositories;
using DIAndCommonAppSettings.Demo3.Services;
using Microsoft.AspNetCore.Mvc;

namespace DIAndCommonAppSettings.Demo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly IAppSettingService _appSettingService;
        private readonly IAppSettingRepository _appSettingRepository;

        public DestinationsController(IAppSettingService appSettingService,
            IAppSettingRepository appSettingRepository)
        {
            _appSettingService = appSettingService;
            _appSettingRepository = appSettingRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //retrieve values from the singleton without accessing to databse
            return Ok(new
            {
                _appSettingService.RefreshGridTimerInSeconds,
                _appSettingService.RowsPerPage,
                _appSettingService.StorageAddress
            });
        }

        [HttpPut]
        public IActionResult UpdateSettings()
        {
            //Update values in the database
            foreach (var setting in _appSettingRepository.GetList())
            {
                if( setting.Code == "RefreshGridTimerInSeconds" ||
                    setting.Code == "RowsPerPage")
                {
                    setting.Value = "500";
                }
                else
                {
                    setting.Value = @"C:\Storage\Test";
                }
            }

            //Refresh singleton settings
            _appSettingService.ReloadParameters();

            return NoContent();
        }

    }
}