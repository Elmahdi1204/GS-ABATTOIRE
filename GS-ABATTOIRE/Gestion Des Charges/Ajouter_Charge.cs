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
    public partial class Ajouter_Charge : Form
    {
        public Ajouter_Charge()
        {
            InitializeComponent();
            bunifuDatePicker1.Value = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, bunifuDatePicker1.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if(bunifuTextBox1.Text=="" || bunifuTextBox2.Text=="" || bunifuTextBox3.Text=="")
            {
                MessageBox.Show("Esseyer remplir toutes les zones.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }
            else
            {
                DataCharges.Ajouter_Charge(bunifuTextBox1.Text, bunifuTextBox3.Text, double.Parse(bunifuTextBox2.Text),bunifuDatePicker1.Value);
                MessageBox.Show("charge ajouter avec succes", "Ajouter avec succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void Ajouter_Charge_Load(object sender, EventArgs e)
        {
            
        }
    }
}
