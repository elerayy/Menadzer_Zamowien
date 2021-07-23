using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menadżer_Zamówień.DAL.Encje
{
    class Przewoznik
    {
        #region Własności

        public sbyte IdP { get; set; }
        public string Rodzaj { get; set; }
        public string Firma { get; set; }

        #endregion

        #region Konstruktory
        public Przewoznik(MySqlDataReader reader)
        {
            IdP = sbyte.Parse(reader["id_p"].ToString());
            Rodzaj = reader["rodzaj"].ToString();
            Firma = reader["firma"].ToString();
        }

        #endregion

        #region Metody
        public override string ToString()
        {
            return $"{Rodzaj} - {Firma}";
        }
        #endregion
    }
}
