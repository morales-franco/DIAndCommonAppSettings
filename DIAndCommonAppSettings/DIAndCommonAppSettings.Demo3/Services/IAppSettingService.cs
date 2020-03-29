namespace DIAndCommonAppSettings.Demo3.Services
{
    public interface IAppSettingService
    {
        int RefreshGridTimerInSeconds { get; }
        int RowsPerPage { get; }
        string StorageAddress { get; }

        void ReloadParameters();
    }
}
