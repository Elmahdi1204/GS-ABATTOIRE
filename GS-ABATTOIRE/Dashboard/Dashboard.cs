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
         totalev.Text = $"{ DataDashboard.totale_vents(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)):### ### ###.##}";
          totalecredit.Text = $"{ DataDashboard.totale_credit(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)):### ### ###.##}";
            double c = DataDashboard.totale_vents(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)) - DataDashboard.totale_credit(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24));
            Caisse.Text = $"{ c:### ### ###.##}";
            nbfacturecredit.Text = ""+ DataDashboard.Count_credit(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24));
            benifice.Text = $"{ DataDashboard.totale_benifice(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)):### ### ###.##}";
            ensmbleencours.Text = "" + DataDashboard2.Ensmbles_encours(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24));
            Ensmblefinis.Text = "" + DataDashboard2.Ensmbles_finis(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24));
            nbachat.Text = "" + DataDashboard2.Count_achats(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24));
            totaleachat.Text = $"{ DataDashboard2.totale_achats(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)):### ### ###.##}";
            nbcredit.Text = "" + DataDashboard2.Count_credit(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24));
            credittotale.Text = $"{ DataDashboard2.totale_credit(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)):### ### ###.##}";
            Money_out.Text = $"{ DataDashboard2.totale_money_out(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)):### ### ###.##}";
            tempreel.Text = $"{ DataDashboard2.benifice_temp_reel(bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(24)):### ### ###.##}";


        }
    }
}
