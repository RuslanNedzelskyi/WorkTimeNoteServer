using Microsoft.Extensions.Configuration;

namespace WorkTimeNoteCommon
{
    public sealed class ConfigurationManager
    {
        private static string _databaseConnectionString;

        public static void SetAppSettingsProperties(IConfiguration configuration)
        {
            _databaseConnectionString = configuration.GetConnectionString(ConnectionNames.DEFAULT_CONNECTION);
        }

        public static string DatabaseConnectionString => _databaseConnectionString;
    }
}
