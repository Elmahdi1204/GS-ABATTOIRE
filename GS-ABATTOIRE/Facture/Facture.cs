using GS_ABATTOIRE.Gestion_des_clients;
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
        List<String> dataclient = new List<string>();
        public Facture( int idvent , List<objet> list , double tva , string methode)
        {
            InitializeComponent();

            data = Datavents.Getvents(idvent);
            double prix = double.Parse(data[4]);
            double prixtva = double.Parse(data[4]) * (tva / 100);
            double totale = prix + prixtva;
            dataclient = Dataclients.Getclient(int.Parse(data[2]));






            ReportParameterCollection parameters = new ReportParameterCollection();
          parameters.Add(new ReportParameter("prix", ""+prix));
            parameters.Add(new ReportParameter("prixtva", ""+prixtva));
            parameters.Add(new ReportParameter("prixavectva", ""+totale));
            parameters.Add(new ReportParameter("tva", "" + tva));
            parameters.Add(new ReportParameter("method", "" + methode));
            parameters.Add(new ReportParameter("nomclient", "" + dataclient[1]));
            parameters.Add(new ReportParameter("adress", "" + dataclient[3]));
            parameters.Add(new ReportParameter("nis", "" + dataclient[4]));
            parameters.Add(new ReportParameter("nif", "" + dataclient[5]));
            parameters.Add(new ReportParameter("rc", "" + dataclient[6]));
            parameters.Add(new ReportParameter("art", "" + dataclient[7]));
            parameters.Add(new ReportParameter("rip", "" + dataclient[8]));


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
