using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menadżer_Zamówień.DAL.Encje
{
    class Zamowienie
    {
        #region Własności

        public sbyte? Id { get; set; }
        public string Co { get; set; }
        public float Koszt { get; set; }
        public string DataZam { get; set; }
        public string DataEst { get; set; }
        public string Status { get; set; }
        public string Zwrot { get; set; }
        public string Username { get; set; }
        //public sbyte IdS { get; set; }
        //public sbyte IdP { get; set; }
        public string IdS { get; set; }
        public string IdP { get; set; }

        #endregion

        #region Konstruktory

        // Konstruktor tworzący obiekt za pomocą MySqlDataReader
        public Zamowienie(MySqlDataReader reader)
        {
            Id = sbyte.Parse(reader["id"].ToString());
            Co = reader["co"].ToString();
            Koszt = float.Parse(reader["koszt"].ToString());
            DataZam = (reader["data_zam"].ToString()).Substring(0, 10);
            DataEst = (reader["data_est"].ToString()).Substring(0, 10);
            Status = reader["status"].ToString();
            Zwrot = reader["zwrot"].ToString();
            Username = reader["username"].ToString();
            //IdS = sbyte.Parse(reader["id_sklepu"].ToString());
            //IdP = sbyte.Parse(reader["id_p"].ToString());
            IdS = reader["nazwa"].ToString();
            IdP = reader["firma"].ToString();
        }

        // Konstruktor tworzący nowy obiekt
        public Zamowienie(string co, float koszt, string data_zam, string data_est,
            string status, string zwrot, string username, string idS, string idP)
        {
            Id = null;
            Co = co.Trim();
            Koszt = koszt;
            DataZam = data_zam.Trim();
            DataEst = data_est.Trim();
            Status = status.Trim();
            Zwrot = zwrot.Trim();
            Username = username.Trim();
            IdS = idS;
            IdP = idP;

        }

        public Zamowienie(Zamowienie zamowienie)
        {
            Id = zamowienie.Id;
            Co = zamowienie.Co;
            Koszt = zamowienie.Koszt;
            DataZam = zamowienie.DataZam;
            DataEst = zamowienie.DataEst;
            Status = zamowienie.Status;
            Zwrot = zamowienie.Zwrot;
            Username = zamowienie.Username;
            IdS = zamowienie.IdS;
            IdP = zamowienie.IdP;
        }

        #endregion

        #region Metody


        public override string ToString()
        {
            return $"{Id}: {Co} ({IdS}) - {Koszt} zł. {Username}";  // Czy dodać tu resztę własności?
        }

        // Metoda do insert to
        public string ToInsert()
        {
            return $"('{Id}', '{Co}', {Koszt},'{DataZam}', '{DataEst}', '{Status}', '{Zwrot}', " +
                $"'{Username}', '{IdS}', '{IdP}')";
        }

        // Sprawdzenie czy takie zamówienie już istnieje
        public override bool Equals(object obj)
        {
            var zamowienie = obj as Zamowienie;
            if (zamowienie is null) return false;
            if (Co.ToLower() != zamowienie.Co.ToLower()) return false;
            if (Koszt != zamowienie.Koszt) return false;
            if (DataZam.ToLower() != zamowienie.DataZam.ToLower()) return false;
            if (DataEst.ToLower() != zamowienie.DataEst.ToLower()) return false;
            if (Status.ToLower() != zamowienie.Status.ToLower()) return false;
            if (Zwrot.ToLower() != zamowienie.Zwrot.ToLower()) return false;
            if (Username.ToLower() != zamowienie.Username.ToLower()) return false;
            if (IdS != zamowienie.IdS) return false;
            if (IdP != zamowienie.IdP) return false;
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
