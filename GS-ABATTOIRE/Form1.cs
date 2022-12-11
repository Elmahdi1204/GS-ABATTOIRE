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

        private void bunifuButton28_Click(object sender, EventArgs e)
        {
            liste_Des_Produits1.Show();
            liste_Des_Produits1.BringToFront();
        }

        private void liste_Des_Produits1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            liste_Des_Achats1.Show();
            liste_Des_Achats1.BringToFront();
        }

        private void bunifuButton27_Click(object sender, EventArgs e)
        {
            liste_Des_Ventes1.Show();
            liste_Des_Ventes1.BringToFront();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            liste_Des_Stocks1.Show();
            liste_Des_Stocks1.BringToFront();
        }

        private void bunifuButton26_Click(object sender, EventArgs e)
        {
            liste_Des_Charges1.Show();
            liste_Des_Charges1.BringToFront();
        }

        private void bunifuButton29_Click(object sender, EventArgs e)
        {
            list_des_versment1.Show();
            list_des_versment1.BringToFront();
        }


        private void bunifuButton210_Click(object sender, EventArgs e)
        {
            liste_Utilisateur1.Show();
            liste_Utilisateur1.BringToFront();

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            dashboard1.Show();
            dashboard1.BringToFront();

        }
    }
}
