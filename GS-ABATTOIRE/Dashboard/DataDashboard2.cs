using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Dashboard
{
    class DataDashboard2

    {
        public static int Ensmbles_finis (DateTime date1, DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select  count(kottas.idkottas) from kottas, Fournisseurs where Fournisseurs.idfournisseur = Kottas.idfournisseur and  (select sum(Produit_achet.qteunit)- (select isnull(sum(Produits_vendu.qteunit) , 0) from Produits_vendu where Produits_vendu.idkotta =kottas.idkottas) from Produit_achet where Produit_achet.idkotta =kottas.idkottas)= 0 and kottas.date between '" + date1 + "' and '" + date2 + "' ", Connexion.conn);
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
        public static int Ensmbles_encours(DateTime date1, DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select  count(kottas.idkottas) from kottas, Fournisseurs where Fournisseurs.idfournisseur = Kottas.idfournisseur and  (select sum(Produit_achet.qteunit)- (select isnull(sum(Produits_vendu.qteunit) , 0) from Produits_vendu where Produits_vendu.idkotta =kottas.idkottas) from Produit_achet where Produit_achet.idkotta =kottas.idkottas)<> 0 and kottas.date between '" + date1 + "' and '" + date2 + "' ", Connexion.conn);
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
        public static int Count_achats(DateTime date1, DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select count (Kottas.idkottas) from kottas  where date between '" + date1 + "' and '" + date2 + "' ", Connexion.conn);
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
        public static double totale_achats(DateTime date1, DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select isnull( sum (prixfournisseur + transport + charges + (Prixterunitaire*qteunite)),0) from kottas   where date between '" + date1 + "' and '" + date2 + "' ", Connexion.conn);
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
                SqlCommand sql = new SqlCommand("select count(idkottas)  from Kottas where prixfournisseur - (Kottas.versment)-(select sum(Versement.montant) from Versement where Versement.type = 'Achats' and Versement.idvente = Kottas.idkottas )  <>0 and  date between '" + date1 + "' and '" + date2 + "' ", Connexion.conn);
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
                SqlCommand sql = new SqlCommand("select isnull( sum(prixfournisseur -kottas.versment  ) - (select sum(Versement.montant) from Versement where Versement.type ='Achats' ) , 0) from Kottas      where date between '" + date1 + "' and '" + date2 + "' ", Connexion.conn);
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
        public static double totale_money_out(DateTime date1, DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select  isnull((select sum(prixtotal) from Vents where Vents.idkotta = Kottas.idkottas  )  , 0 ) -(prixfournisseur + transport + charges + (Prixterunitaire * qteunite)) from kottas, Fournisseurs where Fournisseurs.idfournisseur = Kottas.idfournisseur and  (select sum(Produit_achet.qteunit)- (select isnull(sum(Produits_vendu.qteunit) , 0) from Produits_vendu where Produits_vendu.idkotta =kottas.idkottas) from Produit_achet where Produit_achet.idkotta =kottas.idkottas)<> 0    and  date between '" + date1 + "' and '" + date2 + "' ", Connexion.conn);
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
        public static double benifice_temp_reel(DateTime date1, DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                    SqlCommand sql = new SqlCommand("select isnull(sum(vents.prixtotal), 0)- (select isnull( sum(prixfournisseur + transport + charges + (Prixterunitaire * qteunite)) , 0)  from Kottas where  date between '" + date1 + "' and '" + date2 + "') from Vents where date between '" + date1 + "' and '" + date2 + "' ", Connexion.conn);
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
        public static double Totale_des_charges(DateTime date1, DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select isnull( sum(Charge.Montant) , 0 )from Charge where  date between '" + date1 + "' and '" + date2 + "'", Connexion.conn);
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
    }
}
