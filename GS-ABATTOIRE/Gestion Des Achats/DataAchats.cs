﻿using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Achats
{
    class DataAchats
    {
        public static void Ajouter_kottas(int idkottas,String  nomkottas, int idfournisseur,String categorie,int qteunite,double qtepoid , double prixunitaire , double remise , double prixfournisseur , double versment , double poidapres , double poidabats , double transport, double charges , double Prixterunitaire ,DateTime date )
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("INSERT INTO kottas (idkottas,   nomkottas,idfournisseur,categorie, qteunite, qtepoid , prixunitaire , remise , prixfournisseur , versment , poidapres , poidabats , transport, charges ,Prixterunitaire ,  date)VALUES ('"+idkottas+"' , +N'"+nomkottas+"', '"+idfournisseur+"', N'"+categorie+ "', '" + qteunite + "','" + qtepoid + "','" + prixunitaire + "','" + remise + "','" + prixfournisseur + "','" + versment + "' , '" + poidapres + "', '" + poidabats + "', '" + transport + "','" + charges + "','" + Prixterunitaire + "','" + date + "');", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void Ajouter_produitachete(int idproduit , int idkotta , double qte )
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("insert into Produit_achet ( idproduit , idkotta , qteunit  ) values (N'" + idproduit + "' ,  N'" + idkotta + "' , N'" + qte + "' );", Connexion.conn);
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
                SqlCommand sql = new SqlCommand("select isnull(max(idkottas) ,  0 ) as k from Kottas ;", Connexion.conn);
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
        public static void List_des_ensembles(BunifuDataGridView bunifuDataGridView, String txt)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select idkottas, nomkottas, nomfournisseur, prixfournisseur, versment, prixfournisseur - versment, date, prixfournisseur + transport + charges + (Prixterunitaire * qteunite), isnull((select sum(prixtotal) from Vents where Vents.idkotta = Kottas.idkottas ), 0), isnull((select sum(prixtotal) from Vents where Vents.idkotta = Kottas.idkottas )  , 0 ) -(prixfournisseur + transport + charges + (Prixterunitaire * qteunite)) from kottas, Fournisseurs where Fournisseurs.idfournisseur = Kottas.idfournisseur and Fournisseurs.nomfournisseur LIKE N'%"+txt+"%'  order by Kottas.date desc ; ", Connexion.conn);
                SqlDataReader dr = sql.ExecuteReader();
                bunifuDataGridView.Rows.Clear();
                while (dr.Read())
                {
                    bunifuDataGridView.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], DateTime.Parse(dr[6].ToString()).ToString("dd-MM | HH:mm") , dr[7], dr[8], dr[9]);

                }
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static List<String> Getcotta(int id )
        {
            List<String> list = new List<String>();
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select * from kottas where idkottas ='"+id+"' ;", Connexion.conn);
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
                    list.Add(dr[7].ToString());
                    list.Add(dr[8].ToString());
                    list.Add(dr[9].ToString());
                    list.Add(dr[10].ToString());
                    list.Add(dr[11].ToString());
                    list.Add(dr[12].ToString());
                    list.Add(dr[13].ToString());
                    list.Add(dr[14].ToString());
                    list.Add(dr[15].ToString());
                  


                }
                Connexion.conn.Close();
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
                return list ;
            }
        }
        public static void Get_produit_cotta(BunifuDataGridView bunifuDataGridView, int id )
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("select Produits.idproduit , nomproduit , qteunit  , categorie from Produit_achet , produits where Produit_achet.idproduit = Produits.idproduit and idkotta ='"+id+"';", Connexion.conn);
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
        public static void Modifier_kottas(int idkottas, String nomkottas, int idfournisseur, String categorie, int qteunite, double qtepoid, double prixunitaire, double remise, double prixfournisseur, double versment, double poidapres, double poidabats, double transport, double charges, double Prixterunitaire, DateTime date)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("update  kottas set    nomkottas ='"+nomkottas+"',idfournisseur ='"+idfournisseur+"',categorie ='"+categorie+"', qteunite ='"+qteunite+"', qtepoid ='"+qtepoid+"' , prixunitaire ='"+prixunitaire+"' , remise ='"+remise+"', prixfournisseur ='"+prixfournisseur+"' , versment ='"+versment+"', poidapres ='"+poidapres+"', poidabats ='"+poidabats+"' , transport ='"+transport+"', charges ='"+charges+"' ,Prixterunitaire = '"+Prixterunitaire+"',  date ='"+date+"'  where idkottas = '"+idkottas+"';", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void Delete_kottas(int idkotta)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("delete  from kottas  where   idkottas = N'" + idkotta + "' ;", Connexion.conn);
                sql.ExecuteNonQuery();
                Connexion.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Connexion.conn.Close();
            }
        }
        public static void Delete_produit_achete( int idkotta)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand sql = new SqlCommand("delete  from Produit_achet  where   idkotta = N'" + idkotta + "' ;", Connexion.conn);
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
