﻿namespace Warehouse.Providers.Security
{
    internal class DatabaseConnectionInfo
    {
        private string _connectionStringName;
        private string _connectionString;

        private enum ConnectionType
        {
            ConnectionStringName = 0,
            ConnectionString = 1
        }

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
                Type = ConnectionType.ConnectionString;
            }
        }

        public string ConnectionStringName
        {
            get
            {
                return _connectionStringName;
            }
            set
            {
                _connectionStringName = value;
                Type = ConnectionType.ConnectionStringName;
            }
        }

        public string ProviderName
        {
            get;
            set;
        }

        private ConnectionType Type
        {
            get;
            set;
        }
    }

}