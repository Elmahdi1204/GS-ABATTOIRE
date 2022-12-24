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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            bunifuTextBox2.PasswordChar = '*';
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {

            if (bunifuTextBox1.Text=="")
            {
                MessageBox.Show("entrez votre nom  ","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            if (bunifuTextBox2.Text == "")
            {
                MessageBox.Show("entrez Votre mot de passe ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (DataLogin.log(bunifuTextBox1.Text, bunifuTextBox2.Text))
            {

                Form1 F = new Form1();
                F.ShowDialog();
            }
            else
            {
                MessageBox.Show("Connexion a échoué", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void bunifuButton21_KeyDown(object sender, KeyEventArgs e)
        {
           
                if (e.KeyCode == Keys.Enter)
                {
                bunifuButton21.PerformClick();
                MessageBox.Show("abababab");
                }

         
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }
    }
}
