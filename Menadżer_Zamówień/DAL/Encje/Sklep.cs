using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menadżer_Zamówień.DAL.Encje
{
    class Sklep
    {
        #region Własności

        public sbyte IdS { get; set; }
        public string Nazwa { get; set; }
        public string Strona { get; set; }

        #endregion

        #region Konstruktory
        public Sklep(MySqlDataReader reader)
        {
            IdS = sbyte.Parse(reader["id_sklepu"].ToString());
            Nazwa = reader["nazwa"].ToString();
            Strona = reader["strona_www"].ToString();
        }

        #endregion

        #region Metody
        public override string ToString()
        {
            return $"{IdS}: {Nazwa} ({Strona})";

        }
        #endregion
    }
}
