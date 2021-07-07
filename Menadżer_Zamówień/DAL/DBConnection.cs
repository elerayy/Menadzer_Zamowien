using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Menadżer_Zamówień.DAL
{
    class DBConnection
    {
        private MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();

        private static DBConnection instance = null;
        public static DBConnection Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBConnection();
                return instance;
            }
        }

        public MySqlConnection Connection => new MySqlConnection(stringBuilder.ToString());


        private DBConnection()
        {
            stringBuilder.UserID = Properties.Settings.Default.userID;
            stringBuilder.Server = Properties.Settings.Default.server;
            stringBuilder.Database = Properties.Settings.Default.database;
            stringBuilder.Port = Properties.Settings.Default.port;
            stringBuilder.Password = Properties.Settings.Default.passwd;
        }
    }
}
