using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Sortie_de_caisse
{
    class Data
    {
        public static double Sortie_de_caisse(DateTime date1, DateTime date2)
        {
            Connexion.conn.Open();
            SqlCommand cm = new SqlCommand("select isnull(sum(montant),0) from sortie_de_caisse  where date between '" + date1 + "' and  '" + date2 + "' ;", Connexion.conn);
            SqlDataReader dr = cm.ExecuteReader();
            double totale = 0;

            while (dr.Read())
            {
                totale = double.Parse(dr[0].ToString());

            }
            Connexion.conn.Close();
            return totale;

        }
        public static void Loadvents(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {
                int i = 0;
                bunifuDataGridView.Rows.Clear();
                Connexion.conn.Open();
                SqlCommand cm = new SqlCommand("select dbo.vents.idvants ,dbo.client.nomclient , dbo.vents.prixtotale ,dbo.vents.versment,dbo.vents.benifice ,  dbo.vents.datevent  , dbo.client.idclient , users from dbo.vents ,dbo.client where dbo.client.idclient = dbo.vents.idclient and dbo.vents.prixtotale > dbo.vents.versment AND   dbo.vents.idvants   Like '%" + txt + "%' ORDER BY dbo.vents.datevent DESC;", Connexion.conn);
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    i++;

                    double credit = double.Parse(dr[2].ToString()) - double.Parse(dr[3].ToString());
                    bunifuDataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), credit, dr[4].ToString(), DateTime.Parse(dr[5].ToString()).ToString("dd-MM-yyyy"), dr[6], dr[7]);


                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        public static void Ajouter_c(double totale, DateTime date)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("insert into sortie_de_caisse (  montant , date)values(  '" + totale + "', '" + date + "')", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void dalete_c(int id)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("delete from sortie_de_caisse where id_c ='" + id + "' ;", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }

        public static void list(BunifuDataGridView bunifuDataGridView, DateTime date1, DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("Select * from dbo.sortie_de_caisse  where  date between  '" + date1 + "' and   '" + date2.AddHours(23) + "'  order by date desc; ", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                bunifuDataGridView.Rows.Clear();
                while (dr.Read())
                {
                    bunifuDataGridView.Rows.Add(dr[0], DateTime.Parse(dr[1].ToString()).ToString("dd-MM-yyyy"), dr[2]);
                }
                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
    }
}
