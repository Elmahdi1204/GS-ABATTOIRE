using GS_ABATTOIRE.Gestion_Des_Charges;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Auth
{
    public partial class Liste_Utilisateur : UserControl
    {
        public Liste_Utilisateur()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Ajouter_Utilisateur ajtU = new Ajouter_Utilisateur();
            ajtU.ShowDialog();
            DataLogin.Liste_Utilisateur(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = bunifuDataGridView1.Rows[e.RowIndex].Index;
            String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;
            String Nom_Utilisateur = bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            String Mot_De_Passe = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            String Type = bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (colname=="mod"){
                Change_Motdepasse change = new Change_Motdepasse(Nom_Utilisateur);
                change.ShowDialog();
                DataLogin.Liste_Utilisateur(bunifuDataGridView1, bunifuTextBox1.Text);


            }
            if (colname == "sup")
            {
                DialogResult dialog = MessageBox.Show("Vous etes sur ?", "Supprimer un Utilisateur", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    DataLogin.supp_user(Nom_Utilisateur);

                }
                bunifuButton22.PerformClick();
                
            }
        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void Liste_Utilisateur_Load(object sender, EventArgs e)
        {
            DataLogin.Liste_Utilisateur(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            DataLogin.Liste_Utilisateur(bunifuDataGridView1, bunifuTextBox1.Text);

        }
    }
}
