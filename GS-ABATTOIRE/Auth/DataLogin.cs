using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Auth
{
    internal class DataLogin
    {
      public static bool log(string nom,string mot_de_passe) {
            
            try
            {
                
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("Select * from Utilisateur where Username='" + nom + "' and Passeword='" + mot_de_passe + "' ", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                bool con = false;


                if (dr.HasRows)
                {

                    con = true;
                    while (dr.Read())
                    {
                        Connexion.Type = dr[2].ToString();
                    }

                  
                   

                }

                Connexion.conn.Close();
                return con;
            }
            catch (Exception ex)

            {
                MessageBox.Show( ex.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
                return false;
                    
            }
        }
        public static void Ajouter_user(String nom,String mot_de_passe, String type)
        {
            try {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("insert into Utilisateur  Values('" + nom+"','"+mot_de_passe+"','"+type+"')",Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }

        }

        public static void supp_user(String nom)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("delete from Utilisateur where Username='" + nom + "'", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void change_Mpass_user(String nom,String mot_de_passe)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("Update Utilisateur set Passeword='" + mot_de_passe + "' where Username='" + nom + "';", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        public static void Liste_Utilisateur(BunifuDataGridView bunifuDataGridView, string text)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select * from Utilisateur ",Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                bunifuDataGridView.Rows.Clear();
                while (dr.Read())
                {
                    bunifuDataGridView.Rows.Add(dr[0], dr[1], dr[2]);
                }
                Connexion.conn.Close();
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    }
}
       

