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
                int index = bunifuDataGridView1.Rows[e.RowIndex].Index;
                bunifuButton22.PerformClick();
                int id = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                Modifier_Ensemble modifier_Ensemble = new Modifier_Ensemble(id);
                modifier_Ensemble.ShowDialog();
                DataAchats.List_des_ensembles(bunifuDataGridView1, bunifuTextBox1.Text);

                bunifuButton22.PerformClick();
                bunifuDataGridView1.Rows[index].Selected = true;
            }
            catch(Exception x)
            {
             
            }
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = bunifuDataGridView1.Rows[e.RowIndex].Index;
                bunifuButton22.PerformClick();
                String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;
                String id = bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                String nom = bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                String credit = bunifuDataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                double mntvente = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                
                if (colname == "Credit" && credit != "0")
                {
                    Gestion_Des_Versement.Versement versement = new Gestion_Des_Versement.Versement("Achats" , int.Parse(id)  ,nom , credit  );
                    versement.ShowDialog();
                }

                if (mntvente == 0)
                {
                if (colname == "supp")
                {
                    DialogResult dialog = MessageBox.Show("Vous etes sur ?", "Supprimer un Kottas", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        DataAchats.Delete_kottas(int.Parse(id));
                        DataAchats.Delete_produit_achete(int.Parse(id));
                    }


                }
                }
                bunifuButton22.PerformClick();
                bunifuDataGridView1.Rows[index].Selected = true;

            }
            catch
            {

            }
        }

        private void bunifuTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue ==13)
            {
                bunifuButton21.PerformClick();
            }
        }

        private void bunifuDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
            {

                double credit = Convert.ToDouble(row.Cells[5].Value);



                if (credit > 0 && bunifuToggleSwitch1.Checked == true)
                {

                    row.DefaultCellStyle.BackColor = Color.Red;
                }


                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }

            }
        }
    }
}
