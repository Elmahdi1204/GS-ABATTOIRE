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
    public partial class Payecredit : Form
    {
        public Payecredit(int id, double credit)
        {
            InitializeComponent();
            label2.Text = id.ToString();
            bunifuTextBox4.Text = credit.ToString();
        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            DataTravail.payecredit(int.Parse(label2.Text), double.Parse(bunifuTextBox4.Text));

            MessageBox.Show("payer avec success", "paye un credit ");
            this.Close();
        }
    }
}
