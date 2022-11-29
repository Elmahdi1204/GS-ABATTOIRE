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
    public partial class Liste_Des_Achats : UserControl
    {
        public Liste_Des_Achats()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Ajouter_Ensemble ajtE = new Ajouter_Ensemble();
            ajtE.ShowDialog();
            DataAchats.List_des_ensembles(bunifuDataGridView1 , bunifuTextBox1.Text);


        }

        private void Liste_Des_Achats_Load(object sender, EventArgs e)
        {
            DataAchats.List_des_ensembles(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            DataAchats.List_des_ensembles(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            DataAchats.List_des_ensembles(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                Modifier_Ensemble modifier_Ensemble = new Modifier_Ensemble(id);
                modifier_Ensemble.ShowDialog();


            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
