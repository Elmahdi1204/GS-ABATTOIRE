using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace GS_ABATTOIRE.Dashboard
{
    class Chartes
    {
        public static void chart1(Chart chart , DateTime date1 , DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand countmatier = new SqlCommand("select idkottas , isnull((select sum(prixtotal) from Vents where Vents.idkotta = Kottas.idkottas )  , 0 ) -(prixfournisseur + transport + charges + (Prixterunitaire * qteunite)) as k from kottas where date between '"+date1+"' and '"+date2+"' order by k desc ", Connexion.conn);

                SqlDataReader dr = countmatier.ExecuteReader();


                chart.Series["Series1"].Points.Clear();


                while (dr.Read())
                {
                    if (dr[1].ToString() != "")
                    {
                        chart.Series["Series1"].Points.AddXY("" + dr[0], dr[1]);
                    }



                }

                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                Connexion.conn.Close();
                MessageBox.Show(e.Message);


            }
        }
        public static void chart2(Chart chart, DateTime date1, DateTime date2)
        {
            try
            {
                Connexion.conn.Open();
                SqlCommand countmatier = new SqlCommand("select Top 12 nomclient , isnull((select sum(Vents.prixtotal - versment) from Vents where Vents.idclient = Clients.idclient ) -(select isnull(sum(Versement.montant) , 0) from Versement , Vents where Vents.idvent = Versement.idvente and Versement.type = 'Vents' and Vents.idclient = Clients.idclient) , 0) , (select count (Vents.idvent) from Vents where Vents.idclient = Clients.idclient) from Clients  ", Connexion.conn);

                SqlDataReader dr = countmatier.ExecuteReader();


                chart.Series["Series1"].Points.Clear();
                chart.Series["Series2"].Points.Clear();


                while (dr.Read())
                {
                    if (dr[1].ToString() != "")
                    {
                        chart.Series["Series1"].Points.AddXY("" + dr[0], dr[2]);
                        chart.Series["Series2"].Points.AddXY(" ", dr[1]);
                    }



                }

                Connexion.conn.Close();


            }
            catch (Exception e)
            {
                Connexion.conn.Close();
                MessageBox.Show(e.Message);


            }
        }
    }
}
