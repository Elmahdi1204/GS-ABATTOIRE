using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Achats
{
    public partial class Liste_Des_Achats : UserControl
    {
        public Liste_Des_Achats()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Ajouter_Ensemble ajtE = new Ajouter_Ensemble();
            ajtE.ShowDialog();

        }
    }
}
