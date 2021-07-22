using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Menadżer_Zamówień.DAL.Repozytoria
{
    using Encje;
    class RepozytoriumPrzewoznik
    {
        
        private const string WSZYSCY_PRZEOWZNICY = "Select * from przewoznik";

        #region Metody

        public static List<Przewoznik> PobierzPrzewoznikow()
        {
            List<Przewoznik> przewoznicy = new List<Przewoznik>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSCY_PRZEOWZNICY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    przewoznicy.Add(new Przewoznik(reader));
                connection.Close();
            }
            return przewoznicy;
        }

        public static List<string> PobierzNazwyPrzewoznikow()
        {
            List<string> przewoznicy = new List<string>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSCY_PRZEOWZNICY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    przewoznicy.Add(new Przewoznik(reader).ToString());
                connection.Close();
            }
            return przewoznicy;
        }

        #endregion
    }
}
