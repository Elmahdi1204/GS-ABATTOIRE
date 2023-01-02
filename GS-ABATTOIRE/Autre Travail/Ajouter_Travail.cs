using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Autre_Travail
{
    public partial class Ajouter_Travail : Form
    {
        public Ajouter_Travail()
        {
            InitializeComponent();
          



        }

        private void Ajouter_Travail_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'abattoireDataSet1.Clients'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.clientsTableAdapter.Fill(this.abattoireDataSet1.Clients);

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuDropdown1.Text == "Selectioner un client" || bunifuTextBox2.Text == "" || bunifuTextBox3.Text == "" || bunifuTextBox7.Text == "" || bunifuTextBox4.Text == "" || bunifuTextBox10.Text == "" || bunifuTextBox4.Text == "")
            {
                MessageBox.Show("Esseyer remplir toutes les zones.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                //int idtrv = DataTravail.Get_lastid_trv() + 1;
                DataTravail.Ajouter_Travail(int.Parse(bunifuDropdown1.SelectedValue.ToString()), int.Parse(bunifuTextBox2.Text), int.Parse(bunifuTextBox3.Text), int.Parse(bunifuTextBox6.Text), float.Parse(bunifuTextBox4.Text), float.Parse(bunifuTextBox7.Text), float.Parse(bunifuTextBox22.Text), float.Parse(bunifuTextBox9.Text), float.Parse(bunifuTextBox11.Text), float.Parse(bunifuTextBox12.Text), float.Parse(bunifuTextBox20.Text), float.Parse(bunifuTextBox21.Text), int.Parse(bunifuTextBox13.Text), int.Parse(bunifuTextBox19.Text), int.Parse(bunifuTextBox15.Text), double.Parse(bunifuTextBox16.Text), bunifuDatePicker1.Value);
                MessageBox.Show("Travail ajouter avec succes", "Ajouter avec succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Gestion_des_clients.Ajouter_client ajouter = new Gestion_des_clients.Ajouter_client();
            ajouter.ShowDialog();
            this.clientsTableAdapter.Fill(this.abattoireDataSet1.Clients);
        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {
            try { 
            bunifuTextBox3.Text = (double.Parse(bunifuTextBox1.Text) - double.Parse(bunifuTextBox2.Text)).ToString();
            }
            catch
            {

            }
        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {
            try {
                bunifuTextBox5.Text = (double.Parse(bunifuTextBox4.Text) * double.Parse(bunifuTextBox3.Text)).ToString();
            }
            catch { }
       
        }

        private void bunifuTextBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bunifuTextBox8.Text = (double.Parse(bunifuTextBox6.Text) * double.Parse(bunifuTextBox7.Text)).ToString();

            }
            catch
            {

            }
        }

        private void bunifuTextBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuTextBox9_TextChanged(object sender, EventArgs e)
        {
            try {
                bunifuTextBox10.Text = (double.Parse(bunifuTextBox14.Text) - double.Parse(bunifuTextBox9.Text)).ToString();

            }
            catch { }
        }

        private void bunifuTextBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bunifuTextBox11.Text = double.Parse(bunifuTextBox10.Text).ToString();

            }
            catch
            {

            }
           
        }

        private void bunifuTextBox11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bunifuTextBox12.Text = (double.Parse(bunifuTextBox10.Text) - double.Parse(bunifuTextBox11.Text)).ToString();

            }
            catch
            {

            }
        }

        private void bunifuTextBox16_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bunifuTextBox17.Text = (double.Parse(bunifuTextBox15.Text) * double.Parse(bunifuTextBox16.Text)).ToString();
            }
            catch
            {

            }
        }

        private void bunifuTextBox17_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bunifuTextBox14.Text = (double.Parse(bunifuTextBox5.Text) + double.Parse(bunifuTextBox8.Text) + double.Parse(bunifuTextBox17.Text)).ToString();
            }
            catch { }
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox20_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void bunifuTextBox21_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bunifuTextBox22.Text = (double.Parse(bunifuTextBox10.Text) + Double.Parse(bunifuTextBox20.Text) + double.Parse(bunifuTextBox21.Text)).ToString();
            }
            catch
            {

            }

        }
    }
}
