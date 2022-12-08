using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Stocks
{
    class Datastocks
    {

        public static void List_de_stocks(BunifuDataGridView bunifuDataGridView, String  txt)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("Select idproduit , nomproduit  , isnull((select sum(Produit_achet.qteunit) from Produit_achet where Produit_achet.idproduit = Produits.idproduit ), 0)- isnull((select sum(Produits_vendu.qteunit) from Produits_vendu where Produits_vendu.idproduit = Produits.idproduit ), 0) , isnull((select top 1 prixunit from Produits_vendu , Vents where Vents.idvent= Produits_vendu.idvent and   Produits_vendu.idproduit = Produits.idproduit order by Vents.date desc ), 0) from Produits where nomproduit LIKE '%" + txt+"%';", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                bunifuDataGridView.Rows.Clear();
                while (dr.Read())
                {
                    bunifuDataGridView.Rows.Add(dr[0], dr[1], dr[2] ,dr[3]);

                }
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void get_details(BunifuDataGridView bunifuDataGridView , int id )
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select nomkottas ,isnull( (select qteunit from Produit_achet where Produit_achet.idproduit ='"+id+"' and Produit_achet.idkotta = Kottas.idkottas), 0 ) - isnull( (select qteunit  from Produits_vendu where Produits_vendu.idproduit ='"+id+ "' and Produits_vendu.idkotta = Kottas.idkottas), 0 ) , kottas.categorie , nomfournisseur    from kottas , Fournisseurs , Produit_achet where Fournisseurs.idfournisseur = Kottas.idfournisseur and  Produit_achet.idkotta = kottas.idkottas and Produit_achet.idproduit ='"+id+"';", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                bunifuDataGridView.Rows.Clear();
                while (dr.Read())
                    
                {
                    if (dr[1].ToString()!="0")
                    {
                        bunifuDataGridView.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
                    }
                   

                }
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
               
                Connexion.conn.Close();
            }
        }
    }
}
