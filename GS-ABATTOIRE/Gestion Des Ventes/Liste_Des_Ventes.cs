﻿using System;
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
    public partial class Liste_Des_Ventes : UserControl
    {
        public Liste_Des_Ventes()
        {
            InitializeComponent();
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            Ajouter_Vente ajitV = new Ajouter_Vente();
            ajitV.ShowDialog();
            Datavents.List_des_vents(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void Liste_Des_Ventes_Load(object sender, EventArgs e)
        {
            Datavents.List_des_vents(bunifuDataGridView1 , bunifuTextBox1.Text);
        }

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
             //odifier_vents modifier_Vents = new Modifier_vents(id);
             // modifier_Vents.ShowDialog();
                Datavents.List_des_vents(bunifuDataGridView1, bunifuTextBox1.Text);
            }
            catch
            {

            }
            

        }

        private void bunifuTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue ==13)
            {
                Datavents.List_des_vents(bunifuDataGridView1, bunifuTextBox1.Text);
            }
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = bunifuDataGridView1.Rows[e.RowIndex].Index;
                bunifuButton21.PerformClick();
                String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;
                String id = bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
               



               
                    if (colname == "supp")
                    {
                        DialogResult dialog = MessageBox.Show("Vous etes sur ?", "Supprimer une Ventes", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes)
                        {
                            Datavents.Delete_vente(int.Parse(id));
                            Datavents.Delete_produit_vendu(int.Parse(id));
                        }


                    
                }
                bunifuButton21.PerformClick();
                bunifuDataGridView1.Rows[index].Selected = true;

            }
            catch
            {

            }
        }

        private void bunifuButton21_Click_1(object sender, EventArgs e)
        {
            Datavents.List_des_vents(bunifuDataGridView1, bunifuTextBox1.Text);
        }
    }
}
