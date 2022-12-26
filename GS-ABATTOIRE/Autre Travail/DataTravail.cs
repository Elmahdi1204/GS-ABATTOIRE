using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Autre_Travail
{
    internal class DataTravail
    {
        public static void Ajouter_Travail(int idclient, int mort, int qtegrl, int qtetriash, double prixabattage, double priwtriash, double prixtotale, double remise, double versment, double credit, DateTime date)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("INSERT INTO Travail (idclient ,mor,qtegrl,qtetriash,prixabattage,prixtriash,prixtotale,remise,versement,credit,date )VALUES ('" + idclient + "', '" + mort + "','" + qtegrl + "','" + qtetriash + "','" + prixabattage + "','" + priwtriash + "', '" + prixtotale + "','" + remise + "','" + versment + "','" + credit + "','" + date + "');", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static int Get_lastid_trv()
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select isnull(max(idtrv) ,  0 ) as k from Travail ;", Connexion.conn);
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
        public static void List_des_travali(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select idtrv , nomclient ,remise,prixtotale,versement,credit , Travail.date from Travail , Clients where Clients.idclient= Travail.idclient ", Connexion.conn);
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
        public static void supprimer_Travail(int idtrv)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("delete  from Travail  where   idtrv = N'" + idtrv + "' ;", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void Modifier_Travail(int Idtrv, int idclient, int mort, int qtegrl, int qtetriash, double prixabattage, double priwtriash, double prixtotale, double remise, double versment, double credit, DateTime date)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("update   Travail set  idclient = '" + idclient + "' , mor='"+mort+"',qtegrl='"+qtegrl+"',qtetriash='"+qtetriash+"',priwabattage='"+prixabattage+"',prixtriash='"+priwtriash+ "', ,prixtotale='" + prixtotale + "', remise=N'" + remise + "', versment ='" + versment + "' ,credit='"+credit+"',date ='" + date + "' where idvent ='" + Idtrv + "';", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static List<String> GetTravail(int id)
        {
            List<String> list = new List<String>();
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select * from Travail where idtrv ='" + id + "' ;", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(dr[0].ToString());
                    list.Add(dr[1].ToString());
                    list.Add(dr[2].ToString());
                    list.Add(dr[3].ToString());
                    list.Add(dr[4].ToString());
                    list.Add(dr[5].ToString());
                    list.Add(dr[6].ToString());




                }
                Connexion.conn.Close();
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
                return list;
            }
        }
    }
}
