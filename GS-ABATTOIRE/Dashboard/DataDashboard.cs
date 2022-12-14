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
                SqlCommand sql = new SqlCommand("select isnull(sum(prixtotal),0) from vents  where date between '" + date1 + "' and '" + date2 + "' ", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                double count = 0;

                while (dr.Read())
                {
                    count = double.Parse(dr[0].ToString());

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
        public static int Count_credit(DateTime date1, DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select count(idvent)  from Vents where prixtotal - (Vents.versment)-(select sum(Versement.montant) from Versement where Versement.type = 'Vents' and Vents.idvent = Versement.idvente )  <>0  ", Connexion.conn);
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
                    SqlCommand sql = new SqlCommand("select isnull( sum(prixtotal -versment  ) - (select sum(Versement.montant) from Versement where Versement.type ='Vents' ) , 0) from vents   ", Connexion.conn);
                    SqlDataReader dr = sql.ExecuteReader();
                double count = 0;

                while (dr.Read())
                {
                    count = double.Parse(dr[0].ToString());

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
        public static double totale_benifice(DateTime date1, DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select  isnull((select sum(prixtotal) from Vents where Vents.idkotta = Kottas.idkottas  and Vents.date between '" + date1 + "' and '" + date2 + "')  , 0 ) -(prixfournisseur + transport + charges + (Prixterunitaire * qteunite)) from kottas, Fournisseurs where Fournisseurs.idfournisseur = Kottas.idfournisseur and  (select sum(Produit_achet.qteunit)- (select isnull(sum(Produits_vendu.qteunit) , 0) from Produits_vendu where Produits_vendu.idkotta =kottas.idkottas) from Produit_achet where Produit_achet.idkotta =kottas.idkottas)= 0 and kottas.date between '"+date1+"' and '"+date2+"'", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                double count = 0;

                while (dr.Read())
                {
                    count =count + double.Parse(dr[0].ToString());

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
