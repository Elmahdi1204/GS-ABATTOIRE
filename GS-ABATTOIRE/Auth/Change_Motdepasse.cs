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
    public partial class Change_Motdepasse : Form
    {
        public Change_Motdepasse(string nom)
        {
            InitializeComponent();
            bunifuTextBox1.Text = nom;
            bunifuTextBox2.PasswordChar = '*';
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "")
            {
                MessageBox.Show("error", "Esseye de remplire tout les champs", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                DataLogin.change_Mpass_user(bunifuTextBox1.Text, bunifuTextBox2.Text);
                MessageBox.Show("Changer avec  success", "Mot de pass changer avec  success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

    }
}
