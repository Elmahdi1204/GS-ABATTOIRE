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
    public partial class bonclient : Form
    {
        List<String> data = new List<string>();
        List<String> dataclient = new List<string>();

        public bonclient(int idvent, List<objet> list)
        {
            InitializeComponent();
            data = Datavents.Getvents(idvent);
           
            dataclient = Dataclients.Getclient(int.Parse(data[2]));
            double totale = double.Parse(data[4]);
            double versment = double.Parse(data[5])+  Datavents.Totale_des_versment(int.Parse(data[0]));

            double rest = totale - versment;

            double remis = double.Parse(data[3]);
          double ancien = double.Parse(dataclient[9]) - rest  ;


            double totale2 = remis + totale;

            

            ReportParameterCollection parameters = new ReportParameterCollection();

            parameters.Add(new ReportParameter("totale", $"{totale:### ### ##0.00}"));
            parameters.Add(new ReportParameter("t", $"{totale2:### ### ##0.00}"));
            parameters.Add(new ReportParameter("versment", $"{versment:### ### ##0.00}"));
            parameters.Add(new ReportParameter("rest", $"{rest:### ### ##0.00}"));
            parameters.Add(new ReportParameter("nom", "" + dataclient[1]));
            parameters.Add(new ReportParameter("date", "" + data[6]));
            parameters.Add(new ReportParameter("numf", "" + data[0]));
            parameters.Add(new ReportParameter("remis", $"{remis:### ### ##0.00}"));
              parameters.Add(new ReportParameter("ancien", $"{ancien:### ### ##0.00}"));
            parameters.Add(new ReportParameter("credit", $"{double.Parse(dataclient[9]):### ### ##0.00}"));


            this.reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.LocalReport.SetParameters(parameters);
            ReportDataSource ds = new ReportDataSource();
            ds.Name = "DataSet1";
            ds.Value = list;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(ds);
            reportViewer1.RefreshReport();
        }

        private void bonclient_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
