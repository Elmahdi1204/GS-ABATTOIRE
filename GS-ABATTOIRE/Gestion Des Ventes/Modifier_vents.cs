using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Ventes
{
    public partial class Modifier_vents : Form
    {
        int id = 0;
        List<String> data = new List<string>();
        public Modifier_vents(int id)
        {
            InitializeComponent();
            this.id = id;

        }

        private void Modifier_vents_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'abattoireDataSet1.Clients'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.clientsTableAdapter.Fill(this.abattoireDataSet1.Clients);
            data = Datavents.Getvents(id);
            Datavents.Get_produit_vendu(bunifuDataGridView2, id);

            Datavents.Get_specfic_ensmble(bunifuDataGridView3, "", int.Parse(data[1]));
            bunifuDropdown1.SelectedValue = data[2];
            bunifuDropdown1.Text = Gestion_des_clients.Dataclients.Get_specifice_client( int.Parse(data[2]));
            bunifuTextBox5.Text = data[3];
            bunifuTextBox4.Text = data[4];
            bunifuTextBox7.Text = (double.Parse(data[3]) + double.Parse(data[4])).ToString();
            bunifuTextBox8.Text = data[5];
            bunifuTextBox9.Text = (double.Parse(data[4]) - double.Parse(data[5])).ToString();
            bunifuDatePicker1.Value = DateTime.Parse(data[6]);








        }

        private void bunifuPanel6_Click(object sender, EventArgs e)
        {

        }
    }
}
