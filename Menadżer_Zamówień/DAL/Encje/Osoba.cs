using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menadżer_Zamówień.DAL.Encje
{
    class Osoba
    {
        #region Własności

        public string Username { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public string NrTel { get; set; }

        #endregion

        #region Konstruktory

        // Konstruktor tworzący obiekt za pomocą MySqlDataReader
        public Osoba(MySqlDataReader reader)
        {
            Username = reader["username"].ToString();
            Imie = reader["imie"].ToString();
            Nazwisko = reader["nazwisko"].ToString();
            Adres = reader["adres"].ToString();
            NrTel = reader["nr_tel"].ToString();
        }

        // Konstruktor tworzący nowy obiekt
        public Osoba(string username, string imie, string nazwisko, string adres, string nrTel)
        {
            Username = username.Trim();
            Imie = imie.Trim();
            Nazwisko = nazwisko.Trim();
            Adres = adres.Trim();
            NrTel = nrTel.Trim();
        }

        public Osoba(Osoba osoba)
        {
            Username = osoba.Username;
            Imie = osoba.Imie;
            Nazwisko = osoba.Nazwisko;
            Adres = osoba.Adres;
            NrTel = osoba.NrTel;
        }

        #endregion

        #region Metody


        public override string ToString()
        {
            return $"{Username} - {Imie} {Nazwisko}";  // Czy dodać tu adres i nr tel?
        }

        // Metoda do insert to
        public string ToInsert()
        {
            return $"('{Username}', '{Imie}', {Nazwisko},'{Adres}', '{NrTel}')";
        }

        // Sprawdzenie czy taka osoba już istnieje
        public override bool Equals(object obj)
        {
            var osoba = obj as Osoba;
            if (osoba is null) return false;
            if (Username.ToLower() != osoba.Username.ToLower()) return false;
            if (Imie.ToLower() != osoba.Imie.ToLower()) return false;
            if (Nazwisko.ToLower() != osoba.Nazwisko.ToLower()) return false;
            if (Adres.ToLower() != osoba.Adres.ToLower()) return false;
            if (NrTel.ToLower() != osoba.NrTel.ToLower()) return false;
            return true;

        }

        // to nie wiem co to
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
