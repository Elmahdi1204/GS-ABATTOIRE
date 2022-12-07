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
    public partial class Modifier_fournisseur : Form
    {
        public Modifier_fournisseur(String id, string nom, string adress, string num , string numregistre  , string nif, string nis, string numarticl, string ccp)
        {
            InitializeComponent();
            Idf.Text = id;
            bunifuTextBox1.Text = nom;
            bunifuTextBox2.Text = num;
            bunifuTextBox3.Text = adress;
            bunifuTextBox4.Text = numregistre;
            bunifuTextBox5.Text = nif;
            bunifuTextBox6.Text = nis;
            bunifuTextBox7.Text = numarticl;
            bunifuTextBox8.Text = ccp;
            


        }

        private void Modifier_fournisseur_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuButton21_Click_1(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "" || bunifuTextBox3.Text == "")
            {
                MessageBox.Show("Esseyer remplir toutes les zones.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                Datafournissuer.Modifier_fournissuer(bunifuTextBox1.Text, bunifuTextBox3.Text, bunifuTextBox2.Text, bunifuTextBox6.Text, bunifuTextBox5.Text, bunifuTextBox4.Text, bunifuTextBox7.Text, bunifuTextBox8.Text, int.Parse(Idf.Text));
                MessageBox.Show("Fournisseurs modifier avec succes", "Modifier avec succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
