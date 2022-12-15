using GS_ABATTOIRE.Gestion_des_fournisseurs;
using GS_ABATTOIRE.Gestion_Des_Versement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Achats
{
    public partial class Modifier_Ensemble : Form
    {
        String categorie = "";
        double prixtotale = 0;
        List<String> data =new List<string>();
        public Modifier_Ensemble(int id )
        {
            InitializeComponent();
            bunifuDataGridView2.Columns[4].Visible = false;
            this.fournisseursTableAdapter.Fill(this.abattoireDataSet.Fournisseurs);
            data = DataAchats.Getcotta(id);
            Gestion_Des_Produits.Dataproduit.List_des_produits(bunifuDataGridView1 , Recherche.Text);
            DataAchats.Get_produit_cotta(bunifuDataGridView2, id);
            
            bunifuTextBox5.Text = data[1];
            bunifuDatePicker1.Value = DateTime.Parse( data[15].ToString());
            bunifuDropdown1.SelectedValue =  data[2];
            bunifuDropdown1.Text = Datafournissuer.Get_specifice_fournissuer(int.Parse(data[2]));
            bunifuDropdown2.Text = data[3];
            bunifuTextBox7.Text = data[4];
            bunifuTextBox6.Text = data[16];
           
            bunifuTextBox18.Text = (double.Parse(data[4]) + double.Parse(data[16])).ToString();
            bunifuTextBox8.Text = data[5];
            bunifuTextBox9.Text = data[6];
            bunifuTextBox10.Text = (double.Parse(data[5]) * double.Parse(data[6])).ToString(); 
            bunifuTextBox15.Text = data[7];
            bunifuTextBox16.Text = data[8];
            bunifuTextBox11.Text = data[9];
                bunifuTextBox19.Text = (DataAchats.Totale_des_versment(id) + double.Parse(data[9]) ).ToString();

            bunifuTextBox12.Text= (double.Parse(bunifuTextBox16.Text)  -(DataAchats.Totale_des_versment(id) + double.Parse(data[9]))  ).ToString();
            bunifuTextBox2.Text = data[10];
            bunifuTextBox1.Text = data[11];
            bunifuTextBox13.Text = data[12];
            bunifuTextBox14.Text = data[13];
            bunifuTextBox4.Text = data[14];

           double prixteriache = double.Parse(data[4]) * double.Parse(data[14]);
            double autre = double.Parse(data[8]) + double.Parse(data[12]) + double.Parse(data[13]);
            double prixtotale = prixteriache + autre;

            bunifuTextBox17.Text = $"{ prixtotale:### ### ###.##}";

            qteabats.Text = "0";
            Qtepoulet.Text = "0";



            




        }

        private void Modifier_Ensemble_Load(object sender, EventArgs e)
        {
           

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
                        if (categorie == "Les abats")
                        {

                            qteabats.Text = (double.Parse(qteabats.Text) + double.Parse(qtne)).ToString();

                        }
                        if (categorie == "Poulet , Dende")
                        {
                            Qtepoulet.Text = (double.Parse(Qtepoulet.Text) + double.Parse(qtne)).ToString();
                        }

                        bunifuDataGridView2.Rows.RemoveAt(e.RowIndex);
                    }


                }


            }
            catch
            {

            }
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            try
            {

                if (Qtepoulet.Text == "" || qteabats.Text == "")
                {
                    MessageBox.Show("Esseyer remplir toutes les zones De quantité des abats et Quantite totale de poulet& Dende.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                else
                {

                    if (verifierqte(int.Parse(qte.Text)))
                    {



                        if (verifier(id.Text))
                        {
                            double qnteancien = double.Parse(bunifuDataGridView2.Rows[getindex(int.Parse(qte.Text))].Cells[2].Value.ToString());
                            double qtenv = double.Parse(qte.Text) + qnteancien;
                            bunifuDataGridView2.Rows.RemoveAt(getindex(int.Parse(id.Text)));
                            bunifuDataGridView2.Rows.Add(id.Text, nom.Text, qtenv, categorie);

                        }
                        else
                        {
                            bunifuDataGridView2.Rows.Add(id.Text, nom.Text, qte.Text, categorie);

                        }

                        if (categorie == "Les abats")
                        {

                            qteabats.Text = (double.Parse(qteabats.Text) - double.Parse(qte.Text)).ToString();

                        }
                        if (categorie == "Poulet , Dende")
                        {
                            Qtepoulet.Text = (double.Parse(Qtepoulet.Text) - double.Parse(qte.Text)).ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Quantité indisponible", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    }
                }

            }
            catch
            {

            }

        }
        bool verifierqte(int qnte)
        {
            bool done = true;
            if (categorie == "Les abats")
            {

                if (qnte > int.Parse(qteabats.Text))
                {

                    done = false;
                }

            }
            if (categorie == "Poulet , Dende")
            {
                if (qnte > int.Parse(Qtepoulet.Text))
                {

                    done = false;
                }
            }

            return done;
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
        private void qte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                bunifuButton21.PerformClick();
            }
        }

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                id.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                nom.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                categorie = bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                qte.Clear();
                qte.Focus();


            }
            catch
            {

            }
        }

        private void bunifuTextBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bunifuTextBox10.Text = (double.Parse(bunifuTextBox8.Text) * double.Parse(bunifuTextBox9.Text)).ToString();
                bunifuTextBox16.Text = (double.Parse(bunifuTextBox10.Text) - double.Parse(bunifuTextBox15.Text)).ToString();
                bunifuTextBox11.Text = bunifuTextBox16.Text;
                bunifuTextBox12.Text = (double.Parse(bunifuTextBox16.Text) - double.Parse(bunifuTextBox11.Text)).ToString();


            }
            catch
            {

            }
        }

        private void bunifuTextBox15_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bunifuTextBox16.Text = (double.Parse(bunifuTextBox10.Text) - double.Parse(bunifuTextBox15.Text)).ToString();

              

                prixtotale = (double.Parse(bunifuTextBox16.Text) + double.Parse(bunifuTextBox13.Text) + double.Parse(bunifuTextBox14.Text) + double.Parse(bunifuTextBox3.Text));

                bunifuTextBox17.Text = $"{ prixtotale:### ### ###.##}";

            }
            catch
            {
                
            }
        }

        private void bunifuTextBox11_TextChanged(object sender, EventArgs e)
        {
            try
            {

                bunifuTextBox12.Text = (double.Parse(bunifuTextBox16.Text) - double.Parse(bunifuTextBox11.Text) + DataAchats.Totale_des_versment(int.Parse(data[0]))).ToString();
               bunifuTextBox19.Text = (double.Parse(bunifuTextBox11.Text) + DataAchats.Totale_des_versment(int.Parse(data[0]))).ToString();
            }
            catch
            {

            }
        }

        private void bunifuTextBox13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                prixtotale = (double.Parse(bunifuTextBox16.Text) + double.Parse(bunifuTextBox13.Text) + double.Parse(bunifuTextBox14.Text) + double.Parse(bunifuTextBox3.Text));

                bunifuTextBox17.Text = $"{ prixtotale:### ### ###.##}";

            }
            catch
            {

            }
        }

        private void bunifuTextBox14_TextChanged(object sender, EventArgs e)
        {
            try
            {
                prixtotale = (double.Parse(bunifuTextBox16.Text) + double.Parse(bunifuTextBox13.Text) + double.Parse(bunifuTextBox14.Text) + double.Parse(bunifuTextBox3.Text));

                bunifuTextBox17.Text = $"{ prixtotale:### ### ###.##}";
            }
            catch
            {

            }
        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bunifuTextBox3.Text = (double.Parse(bunifuTextBox4.Text) * double.Parse(bunifuTextBox7.Text)).ToString();

            }
            catch
            {

            }
        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                prixtotale = (double.Parse(bunifuTextBox16.Text) + double.Parse(bunifuTextBox13.Text) + double.Parse(bunifuTextBox14.Text) + double.Parse(bunifuTextBox3.Text));

                bunifuTextBox17.Text = $"{ prixtotale:### ### ###.##}";
            }
            catch
            {

            }
        }

        private void bunifuToggleSwitch1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (e.Checked)
            {
                bunifuButton24.Visible = true;
                bunifuDataGridView2.Columns[4].Visible = true;
                bunifuPanel1.Visible = true;




            }else
            {
                bunifuButton24.Visible = false;
                bunifuDataGridView2.Columns[4].Visible = false;
                bunifuPanel1.Visible = false;

            }
        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            if (bunifuDropdown1.Text == "Selectioner un fournissuer" || bunifuDropdown2.Text == "Selectioner une categorie" || bunifuTextBox7.Text == "" || bunifuTextBox8.Text == "" || bunifuTextBox9.Text == "" || bunifuTextBox15.Text == "" || bunifuTextBox16.Text == "" || bunifuTextBox11.Text == "" || bunifuTextBox2.Text == "" || bunifuTextBox1.Text == "" || bunifuTextBox14.Text == "" || bunifuTextBox13.Text == "" || bunifuTextBox4.Text == "" || bunifuTextBox6.Text =="")
            {
                MessageBox.Show("Esseyer remplir toutes les zones.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {

                DataAchats.Modifier_kottas(int.Parse(data[0]), "Ensemble - " + bunifuDropdown2.Text + " - " + data[0] + " - " + bunifuDatePicker1.Value.Day + " - " + bunifuDatePicker1.Value.Month + " - " + bunifuDatePicker1.Value.Year, int.Parse(bunifuDropdown1.SelectedValue.ToString()), bunifuDropdown2.Text, int.Parse(bunifuTextBox7.Text), double.Parse(bunifuTextBox8.Text), double.Parse(bunifuTextBox9.Text), double.Parse(bunifuTextBox15.Text), double.Parse(bunifuTextBox16.Text), double.Parse(bunifuTextBox11.Text), double.Parse(bunifuTextBox2.Text), double.Parse(bunifuTextBox1.Text), double.Parse(bunifuTextBox13.Text), double.Parse(bunifuTextBox14.Text), double.Parse(bunifuTextBox4.Text), bunifuDatePicker1.Value , int.Parse(bunifuTextBox6.Text));
                DataAchats.Delete_produit_achete(int.Parse(data[0]));
                for (int i = 0; bunifuDataGridView2.Rows.Count > i; i++)
                {
                    int idproduit = int.Parse(bunifuDataGridView2.Rows[i].Cells[0].Value.ToString());
                    double qte = double.Parse(bunifuDataGridView2.Rows[i].Cells[2].Value.ToString());


                    DataAchats.Ajouter_produitachete(idproduit, int.Parse(data[0]), qte);

                }
                MessageBox.Show("Ensemble modifier avec success.", "Modifier Ensemble", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                
            }
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            Voirelesversement voirelesversement = new Voirelesversement(int.Parse(data[0]));
            voirelesversement.ShowDialog();
        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bunifuTextBox7.Text = (double.Parse(bunifuTextBox18.Text) - double.Parse(bunifuTextBox6.Text)).ToString();

            }
            catch
            {

            }
        }

        private void bunifuTextBox16_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
