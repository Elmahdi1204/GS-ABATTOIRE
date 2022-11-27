using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Achats
{
    class DataAchats
    {
        public static void Ajouter_kottas(int idkottas ,string  nomkotta,double  prixtotal,double  versment, double poidgeneral,double prixunit,  double transport, double charges,double poidapres , double poidabbas ,string  categorie ,int  qteunit ,double remise ,  double Prixdefournisseur )
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("INSERT INTO kottas (idkotta, nomkotta, prixtotal, versment, poidgeneral, prixunit, transport, charges, poidapres, poidabbas, categorie, qteunit, remise, Prixdefournisseur)VALUES ('"+idkottas+"' , '"+nomkotta+"', '"+prixtotal+"', '"+versment+ "', '" + poidgeneral + "','" + prixunit + "','" + transport + "','" + charges + "','" + poidapres + "','" + poidabbas + "' , '" + categorie + "', '" + qteunit + "', '" + remise + "','" + Prixdefournisseur +"');", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
    }
}
