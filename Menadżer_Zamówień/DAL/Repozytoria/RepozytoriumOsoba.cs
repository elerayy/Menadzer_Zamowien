using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Menadżer_Zamówień.DAL.Repozytoria
{
    using Encje;
    class RepozytoriumOsoba
    {
        #region Zapytania

        private const string WSZYSTKIE_OSOBY = "Select * from osoby";
        private const string DODAJ_OSOBE = "insert into `osoby`(`username`, `imie`, `nazwisko`, `adres`, `nr_tel`) values";

        #endregion

        #region metody CRUD

        // Metoda do wyświetlenia wszystkich osób
        public static List<Osoba> PobierzWszystkieOsoby()
        {
            List<Osoba> osoby = new List<Osoba>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_OSOBY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    osoby.Add(new Osoba(reader));
                connection.Close();
            }
            return osoby;
        }

        // Metoda do dodania nowej osoby
        public static bool DodajOsobe(Osoba osoba)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_OSOBE} {osoba.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                connection.Close();
            }
            return stan;
        }


        // Metoda do edycji osoby
        public static bool EdytujOsobe(Osoba osoba, string username)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDYTUJ_OSOBE = $"UPDATE osoby SET imie='{osoba.Imie}', nazwisko='{osoba.Nazwisko}', " +
                    $"adres='{osoba.Adres}', nr_tel='{osoba.NrTel}' WHERE username='{username}'";
                Console.WriteLine(EDYTUJ_OSOBE);
                MySqlCommand command = new MySqlCommand(EDYTUJ_OSOBE, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;
                connection.Close();
            }
            return stan;
        }

        // Metoda zbierająca nazwy dostępnych użytkowników
        public static List<string> PobierzWszystkieUsername()
        {
            List<string> usernames = new List<string>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_OSOBY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    usernames.Add(new Osoba(reader).Username);
                connection.Close();
            }
            return usernames;
        }
        #endregion
    }
}
