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
    public partial class Liste_Des_Charges : UserControl
    {
        public Liste_Des_Charges()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Ajouter_Charge ajtch = new Ajouter_Charge();
            ajtch.ShowDialog();
        }
    }
}
