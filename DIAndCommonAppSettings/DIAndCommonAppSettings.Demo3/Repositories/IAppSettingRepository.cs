using DIAndCommonAppSettings.Demo3.Entities;
using System.Collections.Generic;

namespace DIAndCommonAppSettings.Demo3.Repositories
{
    public interface IAppSettingRepository
    {
        IEnumerable<AppSettings> GetList();
    }
}
