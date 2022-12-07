using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_des_fournisseurs
{
    public partial class Liste_des_fournisseur : UserControl
    {
        public Liste_des_fournisseur()
        {
            InitializeComponent();
        }

        private void Liste_des_fournisseur_Load(object sender, EventArgs e)
        {
            bunifuButton22.PerformClick();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Ajouter_fournisseur ajtF = new Ajouter_fournisseur();
            ajtF.ShowDialog();
            bunifuButton22.PerformClick();  
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            Datafournissuer.List_des_fournissuer(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            Datafournissuer.List_des_fournissuer(bunifuDataGridView1, bunifuTextBox1.Text);
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
                String nis  = bunifuDataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                String nif = bunifuDataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
               
                String numregistre = bunifuDataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                String numarticl = bunifuDataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                String ccp = bunifuDataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();




                if (colname == "mod")
                {


                    Modifier_fournisseur modifier_Fournisseur = new Modifier_fournisseur(id, nom, adress, numtele , numregistre , nis , nif , numarticl , ccp);
                    modifier_Fournisseur.ShowDialog();

                }
                if (colname == "supp")
                {
                    DialogResult dialog = MessageBox.Show("Vous etes sur ?", "Supprimer un client", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        Datafournissuer.Supprimer_fournissuer(int.Parse(id));
                    }


                }
                bunifuButton22.PerformClick();
                bunifuDataGridView1.Rows[index].Selected = true;

            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
