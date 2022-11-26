using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_des_clients
{
    public partial class Liste_des_clients : UserControl
    {
        public Liste_des_clients()
        {
            InitializeComponent();
        }

        private void Liste_des_clients_Load(object sender, EventArgs e)
        {
            Dataclients.List_des_clients(bunifuDataGridView1, bunifuTextBox1.Text);

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Ajouter_client ajtc = new Ajouter_client();
            ajtc.ShowDialog();
            bunifuButton22.PerformClick();
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            Dataclients.List_des_clients(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = bunifuDataGridView1.Rows[e.RowIndex].Index;
                String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;
                String id = bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                String nom = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String adress = bunifuDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                String numtele = bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                String Nis = bunifuDataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                String NIf = bunifuDataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                String Registre = bunifuDataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();


                if (colname == "mod")
                {


                    Modifier_client modifier_client = new Modifier_client(id, nom, numtele, adress, NIf, Nis, Registre);
                    modifier_client.ShowDialog();

                }
                if (colname == "supp")
                {
                    DialogResult dialog = MessageBox.Show("Vous etes sur ?", "Supprimer un client", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        Dataclients.Supprimer_clients(int.Parse(id));
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
