namespace DIAndCommonAppSettings.Demo2.Services
{
    public interface IAppSettingService
    {
        int RefreshGridTimerInSeconds { get; }
        int RowsPerPage { get;}
        string StorageAddress { get;  }
    }
}
