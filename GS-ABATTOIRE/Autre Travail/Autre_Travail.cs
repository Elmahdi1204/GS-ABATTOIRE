using GS_ABATTOIRE.Facture;
using GS_ABATTOIRE.Gestion_des_clients;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Autre_Travail
{
    public partial class Autre_Travail : UserControl
    {
        public Autre_Travail()
        {
            InitializeComponent();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Ajouter_Travail ajtt = new Ajouter_Travail();
            ajtt.ShowDialog();
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = bunifuDataGridView1.Rows[e.RowIndex].Index;
                bunifuButton22.PerformClick();
                String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;
                String id = bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                String nom = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String remis = bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                String Prix_Totale = bunifuDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                String Versement = bunifuDataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                String Credit = bunifuDataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                String Date = bunifuDataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

                if (colname == "sup")
                {
                    DialogResult dialog = MessageBox.Show("Vous etes sur ?", "Supprimer un client", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        DataTravail.supprimer_Travail(int.Parse(id));
                    }


                   
                }
              
                    int credit = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());


                    if (colname == "mod")
                    {


                        Payecredit payecredit = new Payecredit(int.Parse(id), credit);
                        payecredit.ShowDialog();



                    }
                    bunifuButton22.PerformClick();

                    bunifuDataGridView1.Rows[index].Selected = true;
                
               
            }
            catch
            {

            }
            


            }

        private void Autre_Travail_Load(object sender, EventArgs e)
        {
            DataTravail.List_des_travali(bunifuDataGridView1, bunifuTextBox1.Text);
            
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            DataTravail.List_des_travali(bunifuDataGridView1, bunifuTextBox1.Text);

        }

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = bunifuDataGridView1.Rows[e.RowIndex].Index;
                //bunifuButton22.PerformClick();
                String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;
                String id = bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                BonTravail bon = new BonTravail(int.Parse(id));
                bon.ShowDialog();
                bunifuDataGridView1.Rows[index].Selected = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
