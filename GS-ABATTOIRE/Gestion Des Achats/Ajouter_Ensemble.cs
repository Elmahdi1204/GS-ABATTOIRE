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
    public partial class Ajouter_Ensemble : Form
    {
        String categorie="";
        double prixtotale = 0;


        public Ajouter_Ensemble()
        {
            InitializeComponent();
            bunifuTextBox15.Text = "0";
            bunifuTextBox14.Text = "0";
            bunifuTextBox3.Text = "0";
        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Ajouter_Ensemble_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'abattoireDataSet.Fournisseurs'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.fournisseursTableAdapter.Fill(this.abattoireDataSet.Fournisseurs);
            Gestion_Des_Produits.Dataproduit.List_des_produits(bunifuDataGridView1 , Recherche.Text);
            bunifuDropdown1.Text = "Selectioner un fournisseur";
            bunifuDropdown2.Text = "Selectioner une categorie";


        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void qte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue ==13)
            {
                bunifuButton21.PerformClick();
            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            try{

                if (Qtepoulet.Text=="" || qteabats.Text =="")
                {
                    MessageBox.Show("Esseyer remplir toutes les zones De quantité des abats et Quantite totale de poulet& Dende.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                else{

                    if (verifierqte(int.Parse(qte.Text)))
                    {

                   

            if (verifier(id.Text))
            {
                double qnteancien  = double.Parse(bunifuDataGridView2.Rows[getindex(int.Parse(id.Text))].Cells[2].Value.ToString());
                double qtenv = double.Parse(qte.Text) + qnteancien;
                bunifuDataGridView2.Rows.RemoveAt(getindex(int.Parse(id.Text)));
                bunifuDataGridView2.Rows.Add(id.Text, nom.Text,qtenv , categorie);

                }
            else
            {
                bunifuDataGridView2.Rows.Add(id.Text, nom.Text, qte.Text , categorie);

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

                if (qnte >int.Parse(qteabats.Text))
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
        int getindex(int  id)
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

        private void bunifuTextBox16_TextChanged(object sender, EventArgs e)
        {

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
            try{
                bunifuTextBox16.Text = (double.Parse(bunifuTextBox10.Text) - double.Parse(bunifuTextBox15.Text)).ToString();
                bunifuTextBox11.Text = bunifuTextBox16.Text;
                bunifuTextBox12.Text = (double.Parse(bunifuTextBox16.Text) - double.Parse(bunifuTextBox11.Text)).ToString();

            }
            catch
            {

            }
        }

        private void bunifuTextBox11_TextChanged(object sender, EventArgs e)
        {
            try
            {
               
                bunifuTextBox12.Text = (double.Parse(bunifuTextBox16.Text) - double.Parse(bunifuTextBox11.Text)).ToString();

            }
            catch
            {

            }
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            Gestion_des_fournisseurs.Ajouter_fournisseur ajouter = new Gestion_des_fournisseurs.Ajouter_fournisseur();
            ajouter.ShowDialog();
            this.fournisseursTableAdapter.Fill(this.abattoireDataSet.Fournisseurs);

        }

        private void bunifuTextBox13_TextChanged(object sender, EventArgs e)
        {
            try
            {
               prixtotale= (double.Parse(bunifuTextBox16.Text) + double.Parse(bunifuTextBox13.Text) + double.Parse(bunifuTextBox14.Text) + double.Parse(bunifuTextBox3.Text));

                bunifuTextBox17.Text = $"{ prixtotale :### ### ###.##}";

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

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Qtepoulet.Text = bunifuTextBox2.Text;
            }
            catch
            {

            }
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                qteabats.Text = bunifuTextBox1.Text;
            }
            catch
            {

            }
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            Gestion_Des_Produits.Ajouter_Prouduit ajouter_Prouduit = new Gestion_Des_Produits.Ajouter_Prouduit();
            ajouter_Prouduit.ShowDialog();
            Gestion_Des_Produits.Dataproduit.List_des_produits(bunifuDataGridView1, Recherche.Text);


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
                prixtotale = (double.Parse(bunifuTextBox16.Text) + double.Parse(bunifuTextBox13.Text) + double.Parse(bunifuTextBox14.Text)+ double.Parse(bunifuTextBox3.Text));

                bunifuTextBox17.Text = $"{ prixtotale:### ### ###.##}";
            }
            catch
            {

            }
        }

        private void bunifuPanel8_Click(object sender, EventArgs e)
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

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            if (bunifuDropdown1.Text=="Selectioner un fournissuer" || bunifuDropdown2.Text=="Selectioner une categorie"|| bunifuTextBox7.Text =="" || bunifuTextBox8.Text=="" || bunifuTextBox9.Text=="" || bunifuTextBox15.Text=="" || bunifuTextBox16.Text==""|| bunifuTextBox11.Text==""|| bunifuTextBox2.Text=="" || bunifuTextBox1.Text==""|| bunifuTextBox14.Text=="" || bunifuTextBox13.Text==""|| bunifuTextBox4.Text=="")
            {
                MessageBox.Show("Esseyer remplir toutes les zones.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                int idkottas = DataAchats.Get_lastid() + 1;
                DataAchats.Ajouter_kottas(idkottas, "Ensemble - " +bunifuDropdown2.Text+ " - " + idkottas + " - " + DateTime.Now.Day + " - " + DateTime.Now.Month + " - " + DateTime.Now.Year, int.Parse(bunifuDropdown1.SelectedValue.ToString()), bunifuDropdown2.Text, int.Parse(bunifuTextBox7.Text), double.Parse(bunifuTextBox8.Text), double.Parse(bunifuTextBox9.Text), double.Parse(bunifuTextBox15.Text), double.Parse(bunifuTextBox16.Text), double.Parse(bunifuTextBox11.Text), double.Parse(bunifuTextBox2.Text), double.Parse(bunifuTextBox1.Text), double.Parse(bunifuTextBox13.Text), double.Parse(bunifuTextBox14.Text), double.Parse(bunifuTextBox4.Text), DateTime.Now);
                for (int i = 0; bunifuDataGridView2.Rows.Count > i; i++)
                {
                    int idproduit = int.Parse(bunifuDataGridView2.Rows[i].Cells[0].Value.ToString());
                    double qte = double.Parse(bunifuDataGridView2.Rows[i].Cells[2].Value.ToString());


                    DataAchats.Ajouter_produitachete(idproduit, idkottas, qte);

                }
                bunifuDataGridView2.Rows.Clear();
                MessageBox.Show("Ajouter avec succes");
                bunifuTextBox1.Clear();
                bunifuTextBox2.Clear();
                bunifuTextBox4.Clear();
                bunifuTextBox7.Clear();
                bunifuTextBox8.Clear();
                bunifuTextBox9.Clear();
                bunifuTextBox10.Clear();
                bunifuTextBox11.Clear();
                bunifuTextBox12.Clear();
                bunifuTextBox13.Clear();
                bunifuTextBox16.Clear();
                bunifuTextBox17.Clear();
                bunifuTextBox15.Text = "0";
                bunifuTextBox14.Text = "0";
                bunifuTextBox3.Text = "0";
                bunifuDropdown1.Text = "Selectioner un fournisseur";
                bunifuDropdown2.Text = "Selectioner une categorie";

            }

         
        }

        private void bunifuTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
