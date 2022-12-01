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
    public partial class Ajouter_Vente : Form
    {
        double qtedispo = 0;
        public Ajouter_Vente()
        {
            InitializeComponent();
        }

        private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                String colname = bunifuDataGridView2.Columns[e.ColumnIndex].Name;
                String categorie = bunifuDataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                String qtne = bunifuDataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();




                if (colname == "supp")
                {
                    DialogResult dialog = MessageBox.Show("Vous etes sur ?", "Supprimer un client", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                      

                        bunifuDataGridView2.Rows.RemoveAt(e.RowIndex);
                    }


                }
                bunifuTextBox7.Text = totale().ToString();
                bunifuTextBox4.Text = (totale() - double.Parse(bunifuTextBox5.Text)).ToString();
                bunifuTextBox9.Text = (double.Parse(bunifuTextBox4.Text) - double.Parse(bunifuTextBox8.Text)).ToString();

            }
            catch
            {

            }
        }

        private void Ajouter_Vente_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'abattoireDataSet1.Clients'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.clientsTableAdapter.Fill(this.abattoireDataSet1.Clients);
            Gestion_Des_Achats.DataAchats.List_des_ensembles(bunifuDataGridView3 ,bunifuTextBox11.Text );



        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            Gestion_des_clients.Ajouter_client ajouter = new Gestion_des_clients.Ajouter_client();
            ajouter.ShowDialog();
            this.clientsTableAdapter.Fill(this.abattoireDataSet1.Clients);
        }

        private void bunifuDataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = int.Parse(bunifuDataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
                Gestion_Des_Achats.DataAchats.Get_produit_cotta(bunifuDataGridView1 ,id );

            }catch
            {

            }
        }

        private void bunifuPanel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                bunifuTextBox1.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                bunifuTextBox2.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                qtedispo = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                bunifuTextBox3.Clear();
                bunifuTextBox3.Focus();


            }
            catch
            {

            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            try
            {

                if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "")
                {
                    MessageBox.Show("Esseyer remplir toutes les zones De quantité des abats et Quantite totale de poulet& Dende.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                else
                {

                    



                        if (verifier(bunifuTextBox1.Text))
                        {
                            double qnteancien = double.Parse(bunifuDataGridView2.Rows[getindex(int.Parse(bunifuTextBox1.Text))].Cells[2].Value.ToString());
                            double qtenv = double.Parse(bunifuTextBox3.Text) + qnteancien;
                          
                        if (qtedispo < qtenv)
                        {
                            MessageBox.Show("Quantite indisponible", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        }
                        else
                        {
                            bunifuDataGridView2.Rows.RemoveAt(getindex(int.Parse(bunifuTextBox1.Text)));
                            bunifuDataGridView2.Rows.Add(bunifuTextBox1.Text, bunifuTextBox2.Text, qtenv, bunifuTextBox10.Text);
                        }

                      

                    }
                        else
                        {
                        if (qtedispo< double.Parse(bunifuTextBox3.Text))
                        {
                            MessageBox.Show("Quantite indisponible", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        }
                        else
                        {
                            bunifuDataGridView2.Rows.Add(bunifuTextBox1.Text, bunifuTextBox2.Text, bunifuTextBox3.Text, bunifuTextBox10.Text);
                        }
                           

                        }

                       
                    }

                bunifuTextBox7.Text = totale().ToString();
                }

            
            catch
            {

            }

        }
        bool verifier(String id)

        {
            bool desc = false;

            for (int i = 0; bunifuDataGridView2.Rows.Count > i; i++)
            {
                if (bunifuDataGridView2.Rows[i].Cells[0].Value.ToString() == id)
                {
                    desc = true;


                }

            }
            return desc;
        }
        int getindex(int id)
        {
            int index = 0;

            for (int i = 0; bunifuDataGridView2.Rows.Count > i; i++)
            {
                if (int.Parse(bunifuDataGridView2.Rows[i].Cells[0].Value.ToString()) == id)
                {
                    index = i;

                }

            }

            return index;
        }

        private void bunifuTextBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue==13)
            {
                bunifuButton21.PerformClick();

            }

        }

        private void bunifuTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                bunifuTextBox10.Clear();
                bunifuTextBox10.Focus();

            }

        }
        double totale()
        {
            double tot = 0;

            for (int i = 0; bunifuDataGridView2.Rows.Count > i; i++)
            {
                double qte = double.Parse(bunifuDataGridView2.Rows[i].Cells[2].Value.ToString());
                double prix = double.Parse(bunifuDataGridView2.Rows[i].Cells[3].Value.ToString());

                tot = tot + (prix * qte);
            }

            return tot;
        }

        private void bunifuDataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bunifuTextBox7.Text = totale().ToString();
                bunifuTextBox4.Text = (totale() - double.Parse(bunifuTextBox5.Text)).ToString();
                bunifuTextBox9.Text = (double.Parse(bunifuTextBox4.Text) - double.Parse(bunifuTextBox8.Text)).ToString();
            }
            catch
            {

            }
        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {

                bunifuTextBox4.Text = (totale() - double.Parse(bunifuTextBox5.Text)).ToString();
            }
            catch
            {

            }
        }

        private void bunifuTextBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {

                bunifuTextBox9.Text = (double.Parse(bunifuTextBox4.Text) - double.Parse(bunifuTextBox8.Text)).ToString();
            }
            catch
            {

            }
        }
    }
}
