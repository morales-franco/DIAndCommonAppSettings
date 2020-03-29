using DIAndCommonAppSettings.Demo3.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DIAndCommonAppSettings.Demo3.Repositories
{
    public class AppSettingRepository: IAppSettingRepository
    {
        private static IList<AppSettings> _appSettings = new List<AppSettings>()
        {
            new AppSettings()
            {
                Id = 1,
                Code = "RefreshGridTimerInSeconds",
                Value =  "120"
            },
            new AppSettings()
            {
                Id = 2,
                Code = "RowsPerPage",
                Value =  "25"
            },
            new AppSettings()
            {
                Id = 3,
                Code = "StorageAddress",
                Value =  @"E:\Storage"
            },
        };

        public IEnumerable<AppSettings> GetList()
        {
            return _appSettings.ToList();
        }

    }
}
