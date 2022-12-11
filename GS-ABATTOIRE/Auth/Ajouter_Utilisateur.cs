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
    public partial class Ajouter_Utilisateur : Form
    {
        public Ajouter_Utilisateur()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text=="" || bunifuTextBox2.Text=="" ||bunifuDropdown2.Text=="")
            {
                MessageBox.Show("Error", "Esseye de remplire tout les champ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataLogin.Ajouter_user(bunifuTextBox1.Text, bunifuTextBox2.Text, bunifuDropdown2.Text);
                MessageBox.Show("Ajouter avec success", "Utilisateur ajouter  avec success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bunifuTextBox1.Clear();
                bunifuTextBox2.Clear();
                bunifuDropdown1.Text = "";
                this.Close();
            }
        }
    }
}
