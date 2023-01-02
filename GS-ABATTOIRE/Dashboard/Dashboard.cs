using GS_ABATTOIRE.Sortie_de_caisse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Dashboard
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
            outils.autodate2(bunifuDatePicker1 , bunifuDatePicker2);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
          NbfacuterV.Text =""+  DataDashboard.Count_vents(bunifuDatePicker1.Value  ,  bunifuDatePicker2.Value.AddHours(24));
         totalev.Text = $"{ DataDashboard.totale_vents(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)):### ### ##0.##} DA";
          totalecredit.Text = $"{ DataDashboard.totale_credit(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)):### ### ##0.##} DA";
           double c = DataDashboard.totale_vents(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)) - DataDashboard.totale_credit(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)) - Data.Sortie_de_caisse(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24) );
          Caisse.Text = $"{ c:### ### ##0.##} DA";
            nbfacturecredit.Text = ""+ DataDashboard.Count_credit(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24));
            benifice.Text = $"{ DataDashboard.totale_benifice(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)):### ### ##0.##} DA";
           ensmbleencours.Text = "" + DataDashboard2.Ensmbles_encours(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24));
            Ensmblefinis.Text = "" + DataDashboard2.Ensmbles_finis(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24));
            nbachat.Text = "" + DataDashboard2.Count_achats(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24));
            totaleachat.Text = $"{ DataDashboard2.totale_achats(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)):### ### ##0.##} DA";
            nbcredit.Text = "" + DataDashboard2.Count_credit(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24));
           credittotale.Text = $"{ DataDashboard2.totale_credit(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)):### ### ##0.##} DA";
           Money_out.Text = $"{ DataDashboard2.totale_money_out(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)):### ### ##0.##} DA";
          tempreel.Text = $"{ DataDashboard2.benifice_temp_reel(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)):### ### ##0.##} DA";
            revenuglobale.Text = $"{ DataDashboard2.benifice_temp_reel(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)):### ### ##0.##} DA";
            totaledescharges.Text = $"{ DataDashboard2.Totale_des_charges(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)):### ### ##0.##} DA";
            double profit = DataDashboard2.benifice_temp_reel(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)) - DataDashboard2.Totale_des_charges(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)) ;
            profitnet.Text = $"{ profit:### ### ##0.##} DA";
            Chartes.chart1(chart1  , bunifuDatePicker1.Value , bunifuDatePicker2.Value);
            Chartes.chart2(chart2, bunifuDatePicker1.Value, bunifuDatePicker2.Value);
            if (profit <= 0)
            {
                pictureBox16.Image = Properties.Resources.money__1_;
                profitnet.ForeColor = Color.Red;


            }
            else
            {
                pictureBox16.Image = Properties.Resources.financial_profit;
                profitnet.ForeColor = Color.Green;

            }
           

        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
             try
            {

                bunifuDatePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
                bunifuDatePicker2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);

                bunifuButton25.PerformClick();

            }
            catch
            {

            }
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuDatePicker1.Value = DateTime.Now.AddDays(-7);
                bunifuDatePicker2.Value = DateTime.Now;

                bunifuButton25.PerformClick();

            }
            catch
            {

            }
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuDatePicker1.Value = DateTime.Now.AddDays(-30);
                bunifuDatePicker2.Value = DateTime.Now;

                bunifuButton25.PerformClick();

            }
            catch
            {

            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    outils.autodate2(bunifuDatePicker1, bunifuDatePicker2);
                    bunifuButton25.PerformClick();
                }

            }
            catch
            {

            }
        }

        private void bunifuDatePicker2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = bunifuDatePicker2.Value;
                bunifuDatePicker2.Value = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
            }
            catch
            {

            }
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_DockChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            Retire retire = new Retire();
            retire.ShowDialog();

        }

        private void bunifuShadowPanel2_DoubleClick(object sender, EventArgs e)
        {
            Clotture_de_lacaisse clotture_ = new Clotture_de_lacaisse();
            clotture_.ShowDialog();
        }

        private void bunifuPanel4_Click(object sender, EventArgs e)
        {

        }
    }
}
