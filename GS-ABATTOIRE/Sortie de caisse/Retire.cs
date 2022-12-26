using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Sortie_de_caisse
{
    public partial class Retire : Form
    {
        public Retire()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox2.Text == "")
            {
                MessageBox.Show("Esseyé de remplire tout les champs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Data.Ajouter_c(double.Parse(bunifuTextBox2.Text), bunifuDatePicker1.Value);
                MessageBox.Show("Operatio ajouter avec success", "Ajouter avec success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();


            }
        }
    }
}
