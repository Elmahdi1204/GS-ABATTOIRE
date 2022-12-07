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
    public partial class Ajouter_client : Form
    {
        public Ajouter_client()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "" || bunifuTextBox5.Text == "" || bunifuTextBox6.Text == ""  || bunifuTextBox7.Text == "")
            {
                MessageBox.Show("Esseyer remplir toutes les zones.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                Dataclients.Ajouter_Client(bunifuTextBox1.Text, bunifuTextBox4.Text, bunifuTextBox3.Text, bunifuTextBox6.Text, bunifuTextBox2.Text, bunifuTextBox5.Text , bunifuTextBox7.Text , bunifuTextBox8.Text);
                MessageBox.Show("Client ajouter avec succes", "Ajouter avec succes", MessageBoxButtons.OK, MessageBoxIcon.Information); 

                this.Close();
            }
        }
    }
}
