using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Ventes
{
    class Datavents
    {
        public static void Get_produit_cotta(BunifuDataGridView bunifuDataGridView, int id)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select Produits.idproduit , nomproduit , qteunit -isnull((select sum(qteunit) from Produits_vendu where Produits_vendu.idkotta = '" + id+"' and Produits_vendu.idproduit =produits.idproduit), 0)  , categorie from Produit_achet , produits where Produit_achet.idproduit = Produits.idproduit and idkotta ='" + id + "';", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                bunifuDataGridView.Rows.Clear();
                while (dr.Read())
                {
                    bunifuDataGridView.Rows.Add(dr[0], dr[1], dr[2], dr[3]);

                }
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void List_des_ensembles(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select idkottas, nomkottas, nomfournisseur, prixfournisseur, versment, prixfournisseur - versment, date, prixfournisseur + transport + charges + (Prixterunitaire * qteunite), isnull((select sum(prixtotal) from Vents where Vents.idkotta = Kottas.idkottas ), 0), isnull((select sum(prixtotal) from Vents where Vents.idkotta = Kottas.idkottas )  , 0 ) -(prixfournisseur + transport + charges + (Prixterunitaire * qteunite)) from kottas, Fournisseurs where Fournisseurs.idfournisseur = Kottas.idfournisseur and  (select sum(Produit_achet.qteunit)- (select isnull(sum(Produits_vendu.qteunit) , 0) from Produits_vendu where Produits_vendu.idkotta =kottas.idkottas) from Produit_achet where Produit_achet.idkotta =kottas.idkottas)<> 0 and  Fournisseurs.nomfournisseur LIKE N'%" + txt + "%'  order by Kottas.date desc ; ", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                bunifuDataGridView.Rows.Clear();
                while (dr.Read())
                {
                    bunifuDataGridView.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], DateTime.Parse(dr[6].ToString()).ToString("dd-MM | HH:mm"), dr[7], dr[8], dr[9]);

                }
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void Get_specfic_ensmble(BunifuDataGridView bunifuDataGridView, String txt , int idkotta)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select idkottas, nomkottas, nomfournisseur, prixfournisseur, versment, prixfournisseur- versment  , date , prixfournisseur + transport +charges +(Prixterunitaire* qteunite) from kottas  , Fournisseurs where Fournisseurs.idfournisseur = Kottas.idfournisseur and idkottas ='"+idkotta+"' ;", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                bunifuDataGridView.Rows.Clear();
                while (dr.Read())
                {
                    bunifuDataGridView.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], DateTime.Parse(dr[6].ToString()).ToString("dd-MM | HH:mm"), dr[7]);

                }
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void Ajouter_vents(int idvent , int idkotta, int idclient , double remise , double prixtotale , double versment , DateTime date)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("INSERT INTO Vents (idvent , idkotta , idclient , remise ,prixtotal , versment  ,date  )VALUES ('" + idvent + "' , +N'" + idkotta + "', '" + idclient + "', N'" + remise + "', '" + prixtotale + "','" + versment + "','" + date + "');", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }

        public static void Ajouter_produit_vendu(int idproduit, int idvent , int idkotta, double qte, double prix)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("insert into Produits_vendu ( idproduit , idkotta , qteunit , prixunit , idvent   ) values (N'" + idproduit + "' ,  N'" + idkotta + "' , N'" + qte + "'  , N'" + prix + "' , N'" + idvent + "' );", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static int Get_lastid()
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select isnull(max(idvent) ,  0 ) as k from Vents ;", Connexion.conn);
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
        public static void Get_produit_vendu(BunifuDataGridView bunifuDataGridView, int id)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select produits.idproduit , nomproduit , qteunit , prixunit from Produits_vendu , produits where Produits_vendu.idproduit = Produits.idproduit and Produits_vendu.idvent ='"+id+"'; ", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                bunifuDataGridView.Rows.Clear();
                while (dr.Read())
                {
                    bunifuDataGridView.Rows.Add(dr[0], dr[1], dr[2], dr[3]);

                }
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void List_des_vents(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select idvent , nomkottas , nomclient , vents.remise , vents.prixtotal , (vents.versment + (select isnull( sum(Versement.montant), 0) from Versement where Versement.type='Vents' and Versement.idvente = Vents.idvent )) , vents.prixtotal- (vents.versment + (select isnull( sum(Versement.montant), 0) from Versement where Versement.type='Vents' and Versement.idvente = Vents.idvent )) , vents.date from Vents , clients , Kottas where  Clients.idclient = Vents.idclient and Kottas.idkottas = Vents.idkotta  and nomclient LIKE N'%" + txt+"%' order by vents.date desc", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                bunifuDataGridView.Rows.Clear();
                while (dr.Read())
                {
                    bunifuDataGridView.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5] , dr[6], DateTime.Parse(dr[7].ToString()).ToString("dd-MM | HH:mm"));

                }
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static List<String> Getvents(int id)
        {
            List<String> list = new List<String>();
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select * from vents where idvent ='" + id + "' ;", Connexion.conn);
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
      
        public static void Modifier_vents(int idkottas, String nomkottas, int idfournisseur, String categorie, int qteunite, double qtepoid, double prixunitaire, double remise, double prixfournisseur, double versment, double poidapres, double poidabats, double transport, double charges, double Prixterunitaire, DateTime date)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("update  kottas set    nomkottas ='" + nomkottas + "',idfournisseur ='" + idfournisseur + "',categorie ='" + categorie + "', qteunite ='" + qteunite + "', qtepoid ='" + qtepoid + "' , prixunitaire ='" + prixunitaire + "' , remise ='" + remise + "', prixfournisseur ='" + prixfournisseur + "' , versment ='" + versment + "', poidapres ='" + poidapres + "', poidabats ='" + poidabats + "' , transport ='" + transport + "', charges ='" + charges + "' ,Prixterunitaire = '" + Prixterunitaire + "',  date ='" + date + "'  where idkottas = '" + idkottas + "';", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void Delete_vente(int idvent)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("delete  from vents  where   idvent = N'" + idvent + "' ;", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void Delete_produit_vendu(int idvent)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("delete  from Produits_vendu  where   idvent = N'" + idvent + "' ;", Connexion.conn);
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
