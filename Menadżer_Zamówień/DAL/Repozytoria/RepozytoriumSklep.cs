using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Menadżer_Zamówień.DAL.Repozytoria
{
    using Encje;
    class RepozytoriumSklep
    {
        private const string WSZYSTKIE_SKLEPY = "Select * from sklep";

        #region Metody
        public static List<Sklep> PobierzSklepy()
        {
            List<Sklep> sklepy = new List<Sklep>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_SKLEPY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    sklepy.Add(new Sklep(reader));
                connection.Close();
            }
            return sklepy;
        }

        public static List<string> PobierzNazwySklepow()
        {
            List<string> sklepy = new List<string>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_SKLEPY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    sklepy.Add(new Sklep(reader).Nazwa);
                connection.Close();
            }
            return sklepy;
        }
        #endregion
    }
}
