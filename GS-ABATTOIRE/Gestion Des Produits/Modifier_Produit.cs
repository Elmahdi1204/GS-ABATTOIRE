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
    public partial class Modifier_Produit : Form
    {
        int id = 0;
        public Modifier_Produit(int id , String nom  , String categorie)
        {
            InitializeComponent();
            bunifuTextBox1.Text = nom;
            this.id = id;
            bunifuDropdown1.Text = categorie;


        }

        private void Modifier_Produit_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuDropdown1.Text == "Selectioner une Categorie" )
            {
                MessageBox.Show("Esseyer remplir toutes les zones.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                Dataproduit.Modifier_Produits(id ,bunifuTextBox1.Text , bunifuDropdown1.Text);
                MessageBox.Show("Produit  modifier avec succes", "Modifier avec succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }
    }
}
