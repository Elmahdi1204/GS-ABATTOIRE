using GS_ABATTOIRE.Autre_Travail;
using GS_ABATTOIRE.Gestion_des_clients;
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
    public partial class BonTravail : Form
    {
        List<String> data = new List<string>();
        List<String> dataclient = new List<string>();
        List<String> creditancien = new List<string>();
        public BonTravail(int idtrv)
        {
            InitializeComponent();
            data = DataTravail.GetTravail(idtrv);
           dataclient = Dataclients.Getclient(int.Parse(data[1]));
            creditancien = Dataclients.GETCREDITTRV(int.Parse(data[1]), idtrv);

            double totaleabatage = double.Parse(data[3])* double.Parse(data[5]);

            double totaleteriace  = double.Parse(data[4]) * double.Parse(data[6]);

            double totale = double.Parse(data[7]);
            double versment = double.Parse(data[9]);
           
            double remis = double.Parse(data[8]);
            double rest = totale - versment;
            double credittotale = double.Parse(creditancien[0]) + rest;
            double totale2 = remis + totale;


            ReportParameterCollection parameters = new ReportParameterCollection();

           parameters.Add(new ReportParameter("qtegrl", data[3]));
           parameters.Add(new ReportParameter("qtetriash", data[4]));
            parameters.Add(new ReportParameter("prixtriash"," X " + data[4] + " = " + $"{totaleteriace:### ### ##0.00}"));
           parameters.Add(new ReportParameter("Qteabattage", data[3]));
           parameters.Add(new ReportParameter("prixabattage"," X " +data[5]+" = "+$"{totaleabatage :### ### ##0.00}"));
            parameters.Add(new ReportParameter("nom", "" + dataclient[1]));
            parameters.Add(new ReportParameter("date", "" + data[11]));
            parameters.Add(new ReportParameter("numf", "" + data[0]));
            parameters.Add(new ReportParameter("prixtotale", $"{totale2:### ### ##0.00}"));
           parameters.Add(new ReportParameter("remise", $"{remis:### ### ##0.00}"));
          parameters.Add(new ReportParameter("prixaprremise", $"{totale:### ### ##0.00}"));
           parameters.Add(new ReportParameter("rest", $"{rest:### ### ##0.00}"));
            parameters.Add(new ReportParameter("versement", $"{versment:### ### ##0.00}"));
            parameters.Add(new ReportParameter("ancien", $"{double.Parse(creditancien[0]):### ### ##0.00}"));
            parameters.Add(new ReportParameter("credit", $"{credittotale:### ### ##0.00}"));


         
            reportViewer1.LocalReport.SetParameters(parameters);
           
            reportViewer1.RefreshReport();
        }

        private void BonTravail_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
