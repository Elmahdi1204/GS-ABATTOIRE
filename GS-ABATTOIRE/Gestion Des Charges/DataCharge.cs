using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Charges
{
    internal class DataCharge
    {
        public static void Ajouter_Charge(String Titre,String Description, double Montant , DateTime date)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("insert into Charge( Titre , Description , Montant, date ) values (N'" + Titre +"' , N'" + Description + "' , N'" + Montant + "', N'" + date +"');", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void Modifier_Charge( String Titre, String Description, double Montant, DateTime date,int id)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("update  Charge set Titre=N '" + Titre + "', Description=N '" + Description + "',Montant=N'" + Montant + "',date=N'" + date + "' where ID=N'" + id + "' ;", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void Supprimer_Charge(int ID)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("delete from charge where ID =N'" + ID + "';", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void liste_Charge(BunifuDataGridView bunifuDataGridView , string text)
        {
            try 
            { 
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand(" select* from Charge;",Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                bunifuDataGridView.Rows.Clear();
                while (dr.Read())
                {
                    bunifuDataGridView.Rows.Add(dr[0], dr[1], dr[2], dr[3], DateTime.Parse(dr[4].ToString()).ToString("dd/MM/yyyy")) ;

                }
                Connexion.conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

    }
}
