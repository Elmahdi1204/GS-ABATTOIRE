using GS_ABATTOIRE.Gestion_des_clients;
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
    public partial class modifie_ventes : Form
    {
        List<String> data = new List<string>();
        public modifie_ventes(int idvent)
        {
            InitializeComponent();
            this.clientsTableAdapter.Fill(this.abattoireDataSet1.Clients);

            data = Datavents.Getvents(idvent);
            bunifuTextBox7.Text = (double.Parse(data[3]) + double.Parse(data[4])).ToString();
            bunifuTextBox5.Text = data[3];
            bunifuTextBox4.Text = data[4];
            bunifuTextBox8.Text = (Datavents.Totale_des_versment(idvent) + double.Parse(data[5])).ToString();
            bunifuTextBox9.Text = (double.Parse(data[4]) - Datavents.Totale_des_versment(idvent) + double.Parse(data[5])).ToString();
            bunifuDatePicker1.Value = DateTime.Parse( data[6]);
            bunifuDropdown1.SelectedValue = int.Parse(data[2]);
           bunifuDropdown1.Text = Dataclients.Get_specifice_client(int.Parse(data[2]));

            Datavents.Get_specfic_ensmble(bunifuDataGridView3, "",  int.Parse(data[1]));
            Datavents.Get_produit_vendu(bunifuDataGridView2, int.Parse(data[0]));
        }

        private void modifie_ventes_Load(object sender, EventArgs e)
        { 

        }
    }
}
