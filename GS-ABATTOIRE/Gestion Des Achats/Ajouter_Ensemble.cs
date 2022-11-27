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


        public Ajouter_Ensemble()
        {
            InitializeComponent();
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
            Gestion_Des_Produits.Dataproduit.List_des_produits(bunifuDataGridView1 , Recherche.Text);


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
    }
    
}
