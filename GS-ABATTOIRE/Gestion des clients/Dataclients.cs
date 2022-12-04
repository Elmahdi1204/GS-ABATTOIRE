using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GS_ABATTOIRE.Gestion_des_clients
{
    class Dataclients
    {

        public static void Ajouter_Client(String nomclient, string numtele, string adress, string nis, String numregistre, string nif)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("insert into Clients ( nomclient , numtele , adress , nis , nif , numregistre ) values (N'" + nomclient + "' ,  N'" + numtele + "' , N'" + adress + "' , N'" + nis + "', N'" + nif + "' ,  N'" + numregistre + "');", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void Modifier_Client(String nomclient, string numtele, string adress, string nis, string nif, String numregistre, int id)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("update  Clients Set nomclient=N'" + nomclient + "' , numtele =N'" + numtele + "' , adress =N'" + adress + "', nis =N'" + nis + "', nif =N'" + nif + "' , numregistre =N'" + numregistre + "' where idclient=N'" + id + "' ;", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void List_des_clients(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("Select * from Clients  ;", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                bunifuDataGridView.Rows.Clear();
                while (dr.Read())
                {
                    bunifuDataGridView.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);

                }
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static string Get_specifice_client( int id )
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("Select * from Clients where idclient ='"+id+"'  ;", Connexion.conn);
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
        public static void Supprimer_clients(int id)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("delete from Clients where idclient =N'" + id + "' ;", Connexion.conn);
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
