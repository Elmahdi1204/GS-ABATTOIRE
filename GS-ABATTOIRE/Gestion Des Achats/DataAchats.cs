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
        public static void Ajouter_kottas(int idkottas,String  nomkottas, int idfournisseur,String categorie,int qteunite,double qtepoid , double prixunitaire , double remise , double prixfournisseur , double versment , double poidapres , double poidabats , double transport, double charges , double Prixterunitaire ,DateTime date )
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("INSERT INTO kottas (idkottas,   nomkottas,idfournisseur,categorie, qteunite, qtepoid , prixunitaire , remise , prixfournisseur , versment , poidapres , poidabats , transport, charges ,Prixterunitaire ,  date)VALUES ('"+idkottas+"' , +N'"+nomkottas+"', '"+idfournisseur+"', N'"+categorie+ "', '" + qteunite + "','" + qtepoid + "','" + prixunitaire + "','" + remise + "','" + prixfournisseur + "','" + versment + "' , '" + poidapres + "', '" + poidabats + "', '" + charges + "','" + transport + "','" + Prixterunitaire + "','" + date + "');", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void Ajouter_produitachete(int idproduit , int idkotta , double qte )
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("insert into Produit_achet ( idproduit , idkotta , qteunit  ) values (N'" + idproduit + "' ,  N'" + idkotta + "' , N'" + qte + "' );", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static int Get_lastid()
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select isnull(max(idkottas) ,  0 ) as k from Kottas ;", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                int lastid = 0;
                while (dr.Read())
                {
                    lastid = int.Parse(dr[0].ToString());

                }
                Connexion.conn.Close();
                return lastid;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
                return 0;
            }
        }
    }
}
