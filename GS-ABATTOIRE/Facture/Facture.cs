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
        public Facture( int idvent , List<objet> list , double tva , string methode , String dest )
        {
            InitializeComponent();
            string notice = "";
            if (methode == "Atterm ")
            {
                notice = "Délais de Paiements: 20 Jours";
            }

            data = Datavents.Getvents(idvent);
            double prix = double.Parse(data[4]);
            double prixtva = double.Parse(data[4]) * (tva / 100);
            double totale = prix + prixtva;
         
            dataclient = Dataclients.Getclient(int.Parse(data[2]));
            ReportParameterCollection parameters = new ReportParameterCollection();
            parameters.Add(new ReportParameter("prix", $"{ prix:### ### ##0.00} "));
            parameters.Add(new ReportParameter("prixtva", $"{ prixtva:### ### ##0.00} "));
            parameters.Add(new ReportParameter("prixavectva", $"{ totale:### ### ##0.00} "));
            parameters.Add(new ReportParameter("tva", "" + tva));
            parameters.Add(new ReportParameter("method", "" + methode));
            parameters.Add(new ReportParameter("nomclient", "" + dataclient[1]));
            parameters.Add(new ReportParameter("adress", "" + dataclient[3]));
            parameters.Add(new ReportParameter("nis", "" + dataclient[4]));
            parameters.Add(new ReportParameter("nif", "" + dataclient[5]));
            parameters.Add(new ReportParameter("rc", "" + dataclient[6]));
            parameters.Add(new ReportParameter("art", "" + dataclient[7]));
            parameters.Add(new ReportParameter("rip", "" + dataclient[8]));
            parameters.Add(new ReportParameter("totalecar", NumberToWords(((int)totale))));
            parameters.Add(new ReportParameter("numf", ""+data[0]));
            parameters.Add(new ReportParameter("date", ""+DateTime.Parse( data[6]).ToString("dd/MM/yyyy")));
            parameters.Add(new ReportParameter("dest", "" +dest));
            parameters.Add(new ReportParameter("notice", "" + notice));



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
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Mille ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Cent ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "et ";

                var unitsMap = new[] { "zero", "un", "deux", "trois", "quatre", "cenque", "six", "sept", "huit", "neuf", "dix", "onze", "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf" };
                var tensMap = new[] { "zero", "dix", "vingt", "trente", "quarente", "cinquante", "soixante", "soixante-dix", "quatre-vingts", "quatre-vingts-dix" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
    }


}
