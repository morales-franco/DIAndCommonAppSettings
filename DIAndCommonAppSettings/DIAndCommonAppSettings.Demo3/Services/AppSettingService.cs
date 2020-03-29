using System;
using System.Linq;
using DIAndCommonAppSettings.Demo3.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DIAndCommonAppSettings.Demo3.Services
{
    public class AppSettingService: IAppSettingService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public int RefreshGridTimerInSeconds { get; private set; }
        public int RowsPerPage { get; private set; }
        public string StorageAddress { get; private set; }

        //IServiceScopeFactory allows create scope and use the provider to retrieve instances from the container manually ;)
        public AppSettingService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            this.ReloadParameters();
        }

        public void ReloadParameters()
        {
            using(var scope = _serviceScopeFactory.CreateScope())
            {
                var repository = scope.ServiceProvider.GetService<IAppSettingRepository>();
                var settings = repository.GetList();
                RefreshGridTimerInSeconds = Convert.ToInt32(settings.First(s => s.Code == "RefreshGridTimerInSeconds").Value);
                RowsPerPage = Convert.ToInt32(settings.First(s => s.Code == "RowsPerPage").Value);
                StorageAddress = settings.First(s => s.Code == "StorageAddress").Value;
            }
        }
    }
}
