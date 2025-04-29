namespace MainApp
{
    public class GlobalSettings
    {
        public const string DefaultEndPoint = "https://dummyjson.com";
        public string UserEndpoint {  get; set; }

        public static GlobalSettings Instance { get; } = new GlobalSettings();

        #region Local Database
        public const string DatabaseFilename = "AppDevSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);          

        #endregion

        public GlobalSettings() 
        {
            UserEndpoint = $"{DefaultEndPoint}/user";
        }
    }
}