using GS_ABATTOIRE.Gestion_Des_Achats;
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
    public partial class Voirelesversement : Form
    {
        public Voirelesversement(int id )
        {
            InitializeComponent();
            DataAchats.Voire_les_versement(bunifuDataGridView1, "", id);
        }

        private void Voirelesversement_Load(object sender, EventArgs e)
        {

        }
    }
}
