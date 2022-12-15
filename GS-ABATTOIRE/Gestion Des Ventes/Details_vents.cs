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
    public partial class Details_vents : Form
    {
        List<String> data = new List<string>();
        public Details_vents(int idvent )
        {
            InitializeComponent();
            data = Datavents.Getvents(idvent);
            bunifuTextBox7.Text = (double.Parse(data[3]) + double.Parse(data[4])).ToString();
            bunifuTextBox5.Text = data[3];
            bunifuTextBox4.Text = data[4];
            bunifuTextBox8.Text = (Datavents.Totale_des_versment(idvent) + double.Parse(data[5])).ToString();
            bunifuTextBox9.Text = (double.Parse(data[4]) - Datavents.Totale_des_versment(idvent) - double.Parse(data[5])).ToString();
            Date.Text = data[6];
            Nom.Text = Dataclients.Get_specifice_client(int.Parse(data[2]));
            Numfact.Text = data[0];
            Ensmble.Text = data[1];
            Datavents.Get_produit_vendu(bunifuDataGridView2, int.Parse(data[0]));
            





        }

        private void Details_vents_Load(object sender, EventArgs e)
        {
            bunifuDropdown1.SelectedIndex = 0;
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text != "")
            {


                List<Facture.objet> list = new List<Facture.objet>();
                list.Clear();

                foreach (DataGridViewRow row in bunifuDataGridView2.Rows)
                {


                    list.Add(new Facture.objet
                    {
                        idproduit = "" + row.Cells[0].Value.ToString(),
                        nomproduit = row.Cells[1].Value.ToString(),
                        prix = row.Cells[2].Value.ToString(),
                        qnt = row.Cells[3].Value.ToString(),
                        prixqnt = (double.Parse(row.Cells[2].Value.ToString()) * double.Parse(row.Cells[3].Value.ToString())).ToString(),



                    });





                }

                Facture.Facture imp = new Facture.Facture(int.Parse(data[0]), list, double.Parse(bunifuTextBox1.Text) , bunifuDropdown1.Text);
                imp.Show();
                Facture.bonclient impp = new Facture.bonclient(int.Parse(data[0]), list);
                impp.Show();
            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            modifie_ventes modifie_Ventes = new modifie_ventes(int.Parse(data[0]));
            modifie_Ventes.ShowDialog();
        }
    }
}
