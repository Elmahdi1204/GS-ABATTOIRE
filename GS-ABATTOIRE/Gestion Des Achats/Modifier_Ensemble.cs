using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Achats
{
    public partial class Modifier_Ensemble : Form
    {
        List<String> data =new List<string>();
        public Modifier_Ensemble(int id )
        {
            InitializeComponent();
           data = DataAchats.Getcotta(id);
            DataAchats.Get_produit_cotta(bunifuDataGridView2, id);
            bunifuDropdown2.Text = data[3];
            bunifuTextBox7.Text = data[4];
            bunifuTextBox8.Text = data[5];
            bunifuTextBox9.Text = data[6];
            bunifuTextBox10.Text = (double.Parse(data[5]) * double.Parse(data[6])).ToString(); 
            bunifuTextBox15.Text = data[7];
            bunifuTextBox16.Text = data[8];
            bunifuTextBox11.Text = data[9];
            bunifuTextBox12.Text= (double.Parse(data[8]) - double.Parse(data[9])).ToString();
            bunifuTextBox2.Text = data[10];
            bunifuTextBox1.Text = data[11];
            bunifuTextBox13.Text = data[12];
            bunifuTextBox14.Text = data[13];
            bunifuTextBox4.Text = data[14];
            bunifuTextBox3.Text = (double.Parse(data[4]) * double.Parse(data[14])).ToString();
            double prixteriache = double.Parse(data[4]) * double.Parse(data[14]);
            double autre = double.Parse(data[8]) + double.Parse(data[12]) + double.Parse(data[13]);
            double prixtotale = prixteriache + autre;

            bunifuTextBox17.Text = $"{ prixtotale:### ### ###.##}";








        }

        private void Modifier_Ensemble_Load(object sender, EventArgs e)
        {

        }
    }
}
