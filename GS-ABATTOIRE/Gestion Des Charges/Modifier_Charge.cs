using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Charges
{
    public partial class Modifier_Charge : Form
    {
     

        public Modifier_Charge(String Id,String titre,String Descreption, String Montant, DateTime Date)
        {
            InitializeComponent();
            Idcharge.Text = Id;
            bunifuTextBox1.Text = titre;
            bunifuTextBox3.Text = Descreption;
            bunifuTextBox2.Text = Montant;
            bunifuDatePicker1.Value = Date;


        }

        private void Modifier_Charge_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox3.Text == "" || bunifuTextBox2.Text == "") 
            {
                MessageBox.Show("Esseyer remplir toutes les zones.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                DataCharge.Modifier_Charge(bunifuTextBox1.Text, bunifuTextBox3.Text, double.Parse(bunifuTextBox2.Text), bunifuDatePicker1.Value, int.Parse(Idcharge.Text));
                MessageBox.Show("Charge Modifeir avec succes", "Modifier avec succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
