using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GS_ABATTOIRE.Gestion_des_fournisseurs
{
    class Datafournissuer
    {
        public static void Ajouter_Fournisseur(String nomfournisseur, string adress, string numtele , String numregistre  , String nif , String nis , String numarticl , String ccp)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("insert into Fournisseurs ( nomfournisseur , adress , numtele , numregistre  , nif , nis , numarticl , ccp  ) values (N'" + nomfournisseur + "' ,  N'" + adress + "'  ,N'" + numtele + "',N'" + numregistre + "',N'" + nif + "',N'" + nis + "' ,N'" + numarticl  + "' ,N'" + ccp + "');", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static string Get_specifice_fournissuer(int id)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("Select * from Fournisseurs where idfournisseur ='" + id + "'  ;", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                String nom = "";
                while (dr.Read())
                {
                    nom = dr[1].ToString();
                }
                Connexion.conn.Close();
                return nom;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
                return "";
            }
        }
        public static void Modifier_fournissuer(String nomfournisseur, string adress, string numtele,string nis  ,string nif  , string numregistre,string numarticl ,string ccp ,  int id)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("update  Fournisseurs Set nomfournisseur=N'" + nomfournisseur + "' , adress =N'" + adress + "' , numtele =N'" + numtele + "' ,nis =N'" + nis + "' ,nif =N'" + nif + "' ,numregistre =N'" + numregistre + "' ,numarticl =N'" + numarticl + "' ,ccp =N'" + ccp + "'  where idfournisseur=N'" + id + "' ;", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void List_des_fournissuer(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select * , (select sum(kottas.prixfournisseur - versment) from Kottas where kottas.idfournisseur = Fournisseurs.idfournisseur) - isnull((select sum(montant) from Versement  , Kottas where Kottas.idfournisseur = Fournisseurs.idfournisseur and Versement.idvente = kottas.idkottas and Versement.type = 'Achats' ) ,0 )  , (select count(kottas.idkottas) from kottas  where kottas.idfournisseur = Fournisseurs.idfournisseur) from Fournisseurs where nomfournisseur LIKE '%"+txt+"%' order by nomfournisseur   desc;", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                bunifuDataGridView.Rows.Clear();
                while (dr.Read())
                {
                    bunifuDataGridView.Rows.Add(dr[0], dr[1], dr[2], dr[3] , dr[4] , dr[5], dr[6], dr[7], dr[8] , dr[9] , dr[10]);

                }
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void Supprimer_fournissuer(int id)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("delete from Fournisseurs where idfournisseur =N'" + id + "' ;", Connexion.conn);
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
