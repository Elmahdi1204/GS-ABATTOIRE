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

        public static void Ajouter_Client(String nomclient, string numtele, string adress, string nis, String numregistre, string nif , String numartcl , String ccp)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("insert into Clients ( nomclient , numtele , adress , nis , nif , numregistre ,numartcl  , ccp ) values (N'" + nomclient + "' ,  N'" + numtele + "' , N'" + adress + "' , N'" + nis + "', N'" + nif + "' ,  N'" + numregistre + "' , N'" + numartcl + "', N'" + ccp + "');", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void Modifier_Client(String nomclient, string numtele, string adress, string nis, string nif, String numregistre, String numartcl , String ccp,int id)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("update  Clients Set nomclient=N'" + nomclient + "' , numtele =N'" + numtele + "' , adress =N'" + adress + "', nis =N'" + nis + "', nif =N'" + nif + "' , numregistre =N'" + numregistre + "' , numartcl =N'" + numartcl + "' , ccp =N'" + ccp + "' where idclient=N'" + id + "' ;", Connexion.conn);
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
                SqlCommand sql = new SqlCommand("select *  , isnull((select sum(Vents.prixtotal - versment) from Vents where Vents.idclient = Clients.idclient ) -(select isnull(sum(Versement.montant) , 0) from Versement , Vents where Vents.idvent = Versement.idvente and Versement.type = 'Vents' and Vents.idclient = Clients.idclient) , 0) , (select count (Vents.idvent) from Vents where Vents.idclient = Clients.idclient) from Clients where Clients.nomclient LIKE '%" + txt + "%' order by nomclient desc;", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                bunifuDataGridView.Rows.Clear();
                while (dr.Read())
                {
                    bunifuDataGridView.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9] , dr[10]) ;

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
