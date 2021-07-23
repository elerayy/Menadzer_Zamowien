using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Menadżer_Zamówień.DAL.Repozytoria
{
    using Encje;
    using System.Globalization;
    using System.Threading;

    class RepozytoriumZamowienie
    {
        #region Zapytania

        private const string WSZYSTKIE_ZAMOWIENIA = "Select * from zamowienie";
        private const string ZAMOWIENIA_LEPIEJ = "select id, co, koszt, data_zam, data_est, status, zwrot, username, " +
            "nazwa, rodzaj, firma from zamowienie z, przewoznik p, sklep s WHERE z.id_sklepu = s.id_sklepu and z.id_p = p.id_p";
        private const string DODAJ_ZAMOWIENIE = "insert into `zamowienie`(`co`, `koszt`, `data_zam`, `data_est`," +
            " `status`, `zwrot`, `username`, `id_sklepu`, `id_p`) values";
        #endregion

        #region metody CRUD

        public static List<Zamowienie> PobierzZamowienia()
        {
            List<Zamowienie> zamowienia = new List<Zamowienie>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ZAMOWIENIA_LEPIEJ, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    zamowienia.Add(new Zamowienie(reader));
                connection.Close();
            }
            return zamowienia;
        }

        public static bool DodajZamowienie(Zamowienie zamowienie)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_ZAMOWIENIE} {zamowienie.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                zamowienie.Id = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return stan;
        }

        public static bool EdytujZamowienie(Zamowienie zamowienie, sbyte? id)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_ZAMOWIENIE = $"UPDATE zamowienie SET status='{zamowienie.Status}'," +
                    $"zwrot='{zamowienie.Zwrot}' WHERE id={id}";
                MySqlCommand command = new MySqlCommand(EDYTUJ_ZAMOWIENIE, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;
                connection.Close();
            }
            return stan;
        }

        #endregion
    }
}
