using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Produits
{
    public partial class Ajouter_Prouduit : Form
    {
        public Ajouter_Prouduit()
        {
            InitializeComponent();
            bunifuDropdown1.Text = "Selectioner une Categorie";
        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuDropdown1.Text == "Selectioner une Categorie")
            {
                MessageBox.Show("Esseyer remplir toutes les zones.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                Dataproduit.Ajouter_Produits(bunifuTextBox1.Text, bunifuDropdown1.Text);
                MessageBox.Show("Produits ajouter avec succes", "Ajouter avec succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bunifuTextBox1.Clear();
                bunifuDropdown1.Text = "Selectioner une Categorie";

            }

        }

        private void Ajouter_Prouduit_Load(object sender, EventArgs e)
        {

        }
    }
}
