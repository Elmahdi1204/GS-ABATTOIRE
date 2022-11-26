using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            liste_des_clients1.Show();
            liste_des_clients1.BringToFront();
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            liste_des_fournisseur1.Show();
            liste_des_fournisseur1.BringToFront();
        }
    }
}
