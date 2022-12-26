using GS_ABATTOIRE.Dashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Sortie_de_caisse
{
    public partial class Clotture_de_lacaisse : Form
    {
        public Clotture_de_lacaisse()
        {
            InitializeComponent();
            outils.autodate2(bunifuDatePicker1, bunifuDatePicker2);
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            Retire retirer = new Retire();
            retirer.ShowDialog();
            Data.list(bunifuDataGridView1, bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(23));
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Data.list(bunifuDataGridView1, bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(23));
        }

        private void Clotture_de_lacaisse_Load(object sender, EventArgs e)
        {
            Data.list(bunifuDataGridView1, bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(23));
        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {
            Data.list(bunifuDataGridView1, bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(23));
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;
                int idcharges = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                if (colname == "supp")
                {

                    DialogResult dialogResult = MessageBox.Show("Vous etes sur ?", "Supprimer un Charge", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        Data.dalete_c(idcharges);

                        Data.list(bunifuDataGridView1, bunifuDatePicker1.Value, bunifuDatePicker2.Value.AddHours(23));
                    }


                }
            }
#pragma warning disable CS0168 // La variable 'x' est déclarée, mais jamais utilisée
            catch (Exception x)
#pragma warning restore CS0168 // La variable 'x' est déclarée, mais jamais utilisée
            {

            }
        }

        private void bunifuDatePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
