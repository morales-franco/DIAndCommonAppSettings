namespace DIAndCommonAppSettings.Demo2.Services
{
    public class AppSettingService: IAppSettingService
    {
        public int RefreshGridTimerInSeconds { get; private set; }
        public int RowsPerPage { get; private set; }
        public string StorageAddress { get; private set; }

        public AppSettingService(int refreshGridTimerInSeconds, int rowsPerPage, string storageAddress)
        {
            RefreshGridTimerInSeconds = refreshGridTimerInSeconds;
            RowsPerPage = rowsPerPage;
            StorageAddress = storageAddress;
        }

    }
}
