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
    public partial class Modifier_client : Form
    {
        public Modifier_client(String id, String nom, String num, String adress, String NIf, String Nis, String Registre)
        {
            InitializeComponent();

            Idclient.Text = id;
            bunifuTextBox1.Text = nom;
            bunifuTextBox4.Text = num;
            bunifuTextBox3.Text = adress;
            bunifuTextBox2.Text = Registre;
            bunifuTextBox5.Text = NIf;
            bunifuTextBox6.Text = Nis;

        }

        private void Modifier_client_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "" || bunifuTextBox5.Text == "" || bunifuTextBox6.Text == "")
            {
                MessageBox.Show("Esseyer remplir toutes les zones.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                Dataclients.Modifier_Client(bunifuTextBox1.Text, bunifuTextBox4.Text, bunifuTextBox3.Text, bunifuTextBox6.Text, bunifuTextBox2.Text, bunifuTextBox5.Text, int.Parse(Idclient.Text));
                MessageBox.Show("Client ajouter avec succes", "Ajouter avec succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }
    }
}
