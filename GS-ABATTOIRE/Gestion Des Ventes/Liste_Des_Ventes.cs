using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Ventes
{
    public partial class Liste_Des_Ventes : UserControl
    {
        public Liste_Des_Ventes()
        {
            InitializeComponent();
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            Ajouter_Vente ajitV = new Ajouter_Vente();
            ajitV.ShowDialog();
            Datavents.List_des_vents(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void Liste_Des_Ventes_Load(object sender, EventArgs e)
        {
            Datavents.List_des_vents(bunifuDataGridView1 , bunifuTextBox1.Text);
        }
    }
}
