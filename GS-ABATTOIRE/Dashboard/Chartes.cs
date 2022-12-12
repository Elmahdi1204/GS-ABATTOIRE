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
    }
}
