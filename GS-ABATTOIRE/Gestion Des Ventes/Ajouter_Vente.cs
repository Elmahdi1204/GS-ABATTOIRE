using GS_ABATTOIRE.Facture;
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
        double qnt = 0;
        String id;

        public Ajouter_Vente()
        {
            InitializeComponent();
            bunifuDropdown1.Text = "Selectioner un client";
        }

        private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                String colname = bunifuDataGridView2.Columns[e.ColumnIndex].Name;
              




                if (colname == "supp")
                {
                    DialogResult dialog = MessageBox.Show("Vous etes sur ?", "Supprimer un Produits", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                      

                        bunifuDataGridView2.Rows.RemoveAt(e.RowIndex);

                        bunifuTextBox7.Text = totale().ToString();
                        bunifuTextBox4.Text = (double.Parse(bunifuTextBox7.Text) - double.Parse(bunifuTextBox5.Text)).ToString();
                        bunifuTextBox8.Text = bunifuTextBox4.Text;

                        bunifuTextBox9.Text = (double.Parse(bunifuTextBox4.Text) - double.Parse(bunifuTextBox8.Text)).ToString();
                    }


                }


            }
            catch
            {

            }
        }

        private void Ajouter_Vente_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'abattoireDataSet1.Clients'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.clientsTableAdapter.Fill(this.abattoireDataSet1.Clients);

            Datavents.List_des_ensembles(bunifuDataGridView3, bunifuTextBox11.Text);
            bunifuDropdown2.SelectedIndex = 0;
            bunifuDropdown3.SelectedIndex = 0;

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
                 id = bunifuDataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();

                Datavents.Get_produit_cotta(bunifuDataGridView1, int.Parse(id));

            } catch
            {

            }
        }

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bunifuTextBox1.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                bunifuTextBox2.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                qnt = double.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                bunifuTextBox3.Clear();
                bunifuTextBox3.Focus();
                bunifuTextBox10.Clear();


            }
            catch
            {

            }

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            try
            {

                if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "" || bunifuTextBox3.Text == "" || bunifuTextBox10.Text == "")
                {
                    MessageBox.Show("Esseyer remplir toutes les zones De quantité des abats et Quantite totale de poulet& Dende.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                else
                {





                    if (verifier(bunifuTextBox1.Text))
                    {
                        

                        double qnteancien = double.Parse(bunifuDataGridView2.Rows[getindex(int.Parse(bunifuTextBox1.Text))].Cells[2].Value.ToString());
                        double qtenv = double.Parse(bunifuTextBox3.Text) + qnteancien;
                        if (qtenv > qnt)
                        {

                            MessageBox.Show("Quantité indisponibles", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        }
                        else
                        {
                            bunifuDataGridView2.Rows.RemoveAt(getindex(int.Parse(bunifuTextBox1.Text)));
                            bunifuDataGridView2.Rows.Add(bunifuTextBox1.Text, bunifuTextBox2.Text, qtenv, bunifuTextBox10.Text);
                        }
                       

                    }
                    else
                    {
                        if (float.Parse(bunifuTextBox3.Text) > qnt)
                        {

                            MessageBox.Show("Quantité indisponibles", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        }
                        else
                        {

                      

                        bunifuDataGridView2.Rows.Add(bunifuTextBox1.Text, bunifuTextBox2.Text, bunifuTextBox3.Text , bunifuTextBox10.Text);
                        }

                    }


                }

                bunifuTextBox7.Text = totale().ToString();
            
    }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        double totale()
        {
            double tot = 0;
            

            for (int i = 0; bunifuDataGridView2.Rows.Count > i; i++)
            {
                double qnt = double.Parse(bunifuDataGridView2.Rows[i].Cells[2].Value.ToString());
                double prix = double.Parse(bunifuDataGridView2.Rows[i].Cells[3].Value.ToString());

                tot = tot + (prix * qnt);

            }

            return (int)Math.Ceiling(tot); ;
        }

        private void bunifuDataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bunifuTextBox7.Text = totale().ToString();
                bunifuTextBox4.Text = (double.Parse(bunifuTextBox7.Text) - double.Parse(bunifuTextBox5.Text)).ToString();
                bunifuTextBox8.Text = bunifuTextBox4.Text;

                bunifuTextBox9.Text = (double.Parse(bunifuTextBox4.Text) - double.Parse(bunifuTextBox8.Text)).ToString();
            }
            catch
            {

            }
        }

        private void bunifuTextBox10_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue ==13)
                {
                    bunifuButton21.PerformClick();
                }
               
            }catch
            {

            }
        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bunifuTextBox4.Text = (double.Parse(bunifuTextBox7.Text) - double.Parse(bunifuTextBox5.Text)).ToString();
                bunifuTextBox8.Text= bunifuTextBox4.Text;

                bunifuTextBox9.Text = (double.Parse(bunifuTextBox4.Text) - double.Parse(bunifuTextBox8.Text)).ToString();
            }
            catch
            {

            }
        }

        private void bunifuTextBox10_TextChanged(object sender, EventArgs e)
        {

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

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox12.Text =="" || bunifuDropdown1.Text == "Selectioner un client" ||  bunifuTextBox7.Text == "" || bunifuTextBox8.Text == "" || bunifuTextBox4.Text == "" || bunifuTextBox5.Text == "" || bunifuTextBox9.Text == "" || bunifuDataGridView2.Rows.Count ==0)
            {
                MessageBox.Show("Esseyer remplir toutes les zones.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                int idvent = Datavents.Get_lastid() + 1;
                Datavents.Ajouter_vents(idvent, int.Parse(id), int.Parse(bunifuDropdown1.SelectedValue.ToString()) , float.Parse(bunifuTextBox5.Text) , double.Parse(bunifuTextBox4.Text.Replace(',' , '.'))   , double.Parse(bunifuTextBox8.Text) , bunifuDatePicker1.Value) ;
                for (int i = 0; bunifuDataGridView2.Rows.Count > i; i++)
                {
                    int idproduit = int.Parse(bunifuDataGridView2.Rows[i].Cells[0].Value.ToString());
                    string qte = bunifuDataGridView2.Rows[i].Cells[2].Value.ToString();
                    double prix = double.Parse(bunifuDataGridView2.Rows[i].Cells[3].Value.ToString());


                    Datavents.Ajouter_produit_vendu(idproduit , idvent, int.Parse(id), qte.Replace(",",".") , prix);

                }
                List<Facture.objet> list = new List<Facture.objet>();
                list.Clear();
                int k = 1;
                foreach (DataGridViewRow row in bunifuDataGridView2.Rows)
                {
                    list.Add(new Facture.objet
                    {
                        idproduit = "" + k,
                        nomproduit = row.Cells[1].Value.ToString(),
                        prix = $"{ double.Parse(row.Cells[3].Value.ToString()):### ### ##0.00} " ,
                        qnt = row.Cells[2].Value.ToString(),
                        prixqnt = $"{ (double.Parse(row.Cells[2].Value.ToString()) * double.Parse(row.Cells[3].Value.ToString())):### ### ##0.00} ",



                    });
                    k++;




                }
                if (bunifuDropdown3.SelectedIndex == 1)
                {
                    Facture.Facture imp = new Facture.Facture(idvent, list, int.Parse(bunifuTextBox12.Text), bunifuDropdown2.Text, bunifuTextBox13.Text);
                    imp.ShowDialog();
                }
                   
                Facture.bonclient impp = new Facture.bonclient(idvent, list);
                impp.ShowDialog();

                bunifuDataGridView2.Rows.Clear();
                MessageBox.Show("Ajouter avec succes");
                bunifuDataGridView1.Rows.Clear();
                bunifuDataGridView2.Rows.Clear();
                bunifuTextBox1.Clear();
                bunifuTextBox2.Clear();
                bunifuTextBox4.Clear();
                bunifuTextBox7.Clear();
                bunifuTextBox8.Clear();
                bunifuTextBox9.Clear();
                bunifuTextBox5.Clear();

                bunifuTextBox10.Clear();
                bunifuTextBox11.Clear();
                Datavents.List_des_ensembles(bunifuDataGridView3, bunifuTextBox11.Text);

                bunifuTextBox3.Text = "0";
                bunifuDropdown1.Text = "Selectioner un client";
               

            }

        }

        private void bunifuDataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuTextBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue ==13)
            {
                Gestion_Des_Achats.DataAchats.List_des_ensembles(bunifuDataGridView3, bunifuTextBox11.Text);

            }
        }
    }
}
