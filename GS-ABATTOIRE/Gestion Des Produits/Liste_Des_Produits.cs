using GS_ABATTOIRE.Gestion_Des_Produits;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Projets
{
    public partial class Liste_Des_Produits : UserControl
    {
        public Liste_Des_Produits()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Ajouter_Prouduit ajtP = new Ajouter_Prouduit();
            ajtP.ShowDialog();
            Dataproduit.List_des_produits(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void Liste_Des_Produits_Load(object sender, EventArgs e)
        {
            Dataproduit.List_des_produits(bunifuDataGridView1,bunifuTextBox1.Text);
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            Dataproduit.List_des_produits(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            Dataproduit.List_des_produits(bunifuDataGridView1, bunifuTextBox1.Text);
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



                if (colname == "mod")
                {


                    Modifier_Produit MOdifier_Produit = new Modifier_Produit(int.Parse(id), nom);
                    MOdifier_Produit.ShowDialog();

                }
                if (colname == "supp")
                {
                    DialogResult dialog = MessageBox.Show("Vous etes sur ?", "Supprimer un client", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        Dataproduit.Supprimer_produits(int.Parse(id));
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
