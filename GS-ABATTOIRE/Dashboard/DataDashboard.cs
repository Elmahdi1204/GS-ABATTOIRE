using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Dashboard
{
    class DataDashboard
    {
        public static int  Count_vents(DateTime date1  , DateTime date2 )
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select count (vents.idvent) from vents where date between '"+date1+"' and '"+date2+"' ", Connexion.conn);
               SqlDataReader dr = sql.ExecuteReader();
                int count = 0;

                while (dr.Read())
                {
                    count = int.Parse(dr[0].ToString());

                }
                Connexion.conn.Close();
                return count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
                return 0;
            }
        }
        public static double totale_vents(DateTime date1, DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select sum(prixtotal) from vents  where date between '" + date1 + "' and '" + date2 + "' ", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                int count = 0;

                while (dr.Read())
                {
                    count = int.Parse(dr[0].ToString());

                }
                Connexion.conn.Close();
                return count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
                return 0;
            }
        }
        public static double totale_credit(DateTime date1, DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select sum(prixtotal -versment  ) - (select sum(Versement.montant) from Versement where Versement.type ='Vents' ) from vents    where date between '" + date1 + "' and '" + date2 + "' ", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                int count = 0;

                while (dr.Read())
                {
                    count = int.Parse(dr[0].ToString());

                }
                Connexion.conn.Close();
                return count;
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
