using GS_ABATTOIRE.Gestion_Des_Produits;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Projets
{
    public partial class Liste_Des_Produits : UserControl
    {
        public Liste_Des_Produits()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Ajouter_Prouduit ajtP = new Ajouter_Prouduit();
            ajtP.ShowDialog();
        }
    }
}
