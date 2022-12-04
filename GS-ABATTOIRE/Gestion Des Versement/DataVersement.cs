using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_ABATTOIRE.Gestion_Des_Versement
{
    internal class DataVersement
    {
        public static void Ajouter_Versement(Double Montant, DateTime date)
        {
            Connexion.conn.Open();
            SqlCommand sql = new SqlCommand("insert into Versement(  ) ");

        }
       
    }
}
