using GS_ABATTOIRE.Gestion_Des_Ventes;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Facture
{
    public partial class Facture : Form
    {
        List<String> data = new List<string>();
        public Facture( int idvent , List<objet> list , double tva)
        {
            InitializeComponent();

            data = Datavents.Getvents(idvent);
            double prix = double.Parse(data[4]);
            double prixtva = double.Parse(data[4]) * (tva / 100);
            double totale = prix + prixtva;






            ReportParameterCollection parameters = new ReportParameterCollection();
          parameters.Add(new ReportParameter("prix", ""+prix));
            parameters.Add(new ReportParameter("prixtva", ""+prixtva));
            parameters.Add(new ReportParameter("prixavectva", ""+totale));
            parameters.Add(new ReportParameter("tva", "" + tva));

            /* parameters.Add(new ReportParameter("prix", $"{ double.Parse(totale):### ### ###.##}"));
             parameters.Add(new ReportParameter("versment", $"{ double.Parse(versment):### ### ###.##}"));
             parameters.Add(new ReportParameter("count", count.ToString()));
             parameters.Add(new ReportParameter("url", new Uri(@"C:\logs\logo.png").AbsoluteUri));
             parameters.Add(new ReportParameter("tele", new Uri(@"C:\logs\num.png").AbsoluteUri));*/
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.LocalReport.SetParameters(parameters);
            ReportDataSource ds = new ReportDataSource();
            ds.Name = "DataSet1";
            ds.Value = list;



            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(ds);




            reportViewer1.RefreshReport();



        }

        private void Facture_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
           
        }
    }

}
