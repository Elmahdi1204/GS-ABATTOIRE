using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Charges
{
    public partial class Modifier_Charge : Form
    {
        public Modifier_Charge( String id,String Titre, String Description, String Montant, DateTime date)
        {
            InitializeComponent();
            Idcharge.Text = id;
            bunifuTextBox1.Text = Titre;
            bunifuTextBox3.Text = Description;
            bunifuTextBox2.Text = Montant;
            bunifuDatePicker1.Value = date;
        }

        private void Modifier_Charge_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "" || bunifuTextBox3.Text == "")
            {
                MessageBox.Show("Esseyer remplir toutes les zones.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                DataCharges.Modifier_Charge(bunifuTextBox1.Text, bunifuTextBox3.Text, double.Parse(bunifuTextBox2.Text), bunifuDatePicker1.Value, int.Parse(Idcharge.Text));
                MessageBox.Show("Charge ajouter avec succes", "Ajouter avec succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }
    }
}
