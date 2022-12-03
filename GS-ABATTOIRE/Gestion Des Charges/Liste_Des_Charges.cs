using GS_ABATTOIRE.Gestion_des_clients;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.BunifuCheckBox.Transitions;

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
            DataCharges.liste_Charge(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void Liste_Des_Charges_Load(object sender, EventArgs e)
        {
            DataCharges.liste_Charge(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

          
                int index = bunifuDataGridView1.Rows[e.RowIndex].Index;
                String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;
                String ID = bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                String Titre = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String Descreption = bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                String Montant = bunifuDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                DateTime date = DateTime.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                if (colname == "mod")
                {


             //      Modifier_Charge modifier_charge =new Modifier_Charge(ID, Titre, Descreption, Montant, date);
             //       modifier_charge.ShowDialog();

                }
                if (colname == "sup")
                {
                    DialogResult dialog = MessageBox.Show("Vous etes sur ?", "Supprimer un client", MessageBoxButtons.YesNo);
                    if(dialog == DialogResult.Yes)
                    {
                        DataCharges.Supprimer_Charge(int.Parse(ID));
                    }
                }
                bunifuButton22.PerformClick();
                bunifuDataGridView1.Rows[index].Selected = true;

            }
            catch
            {

            }



        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            DataCharges.liste_Charge(bunifuDataGridView1, bunifuTextBox1.Text);
        }
    }
}
