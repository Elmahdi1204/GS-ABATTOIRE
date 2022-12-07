using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Versement
{
    public partial class List_des_versment : UserControl
    {
        public List_des_versment()
        {
            InitializeComponent();
            versment_achats1.Show();
            versment_achats1.BringToFront();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            versment_achats1.Show();
            versment_achats1.BringToFront();

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            versement_ventes1.Show();
            versement_ventes1.BringToFront();
        }
    }
}
