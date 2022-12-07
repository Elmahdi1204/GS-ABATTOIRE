using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Versement
{
    public partial class Versement_ventes : UserControl
    {
        public Versement_ventes()
        {
            InitializeComponent();
        }

        private void Versement_ventes_Load(object sender, EventArgs e)
        {
            DataVersement.List_des_versement_Vents(bunifuDataGridView1  , bunifuTextBox1.Text);

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            DataVersement.List_des_versement_Vents(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void bunifuTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue ==13)
            {
                bunifuButton22.PerformClick();
            }
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = bunifuDataGridView1.Rows[e.RowIndex].Index;
                String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;
                String id = bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
               


               
                if (colname == "supp")
                {
                    DialogResult dialog = MessageBox.Show("Vous etes sur ?", "Supprimer un Versement", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        DataVersement.Supprimer_Versement(int.Parse(id));
                    }


                }
                bunifuButton22.PerformClick();
                bunifuDataGridView1.Rows[index].Selected = true;

            }
            catch
            {

            }
        }
    }
}
