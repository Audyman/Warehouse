using System.Configuration;

namespace Warehouse.Database.Configuration
{
    public class DbConfigManager
    {
        public static bool IsDeleteExistDatabase
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["IsDeleteExistDatabase"]); }
        }

        public static bool IsTrowIfDatabaseNotFound
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["IsTrowIfDatabaseNotFound"]); }
        }

        public static bool IsAddTestData
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["IsAddTestData"]); }
        }

        public static string ConnectionName
        {
            get { return "WarehouseContext"; }
        }
    }
}