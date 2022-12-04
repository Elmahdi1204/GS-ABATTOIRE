using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Stocks
{
    public partial class Liste_Des_Stocks : UserControl
    {
        public Liste_Des_Stocks()
        {
            InitializeComponent();
            Datastocks.List_de_stocks(bunifuDataGridView1, bunifuTextBox1.Text);
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void bunifuTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue ==13)
            {
                Datastocks.List_de_stocks(bunifuDataGridView1, bunifuTextBox1.Text);
            }
        }

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = bunifuDataGridView1.Rows[e.RowIndex].Index;
                Datastocks.List_de_stocks(bunifuDataGridView1, bunifuTextBox1.Text);
                String colname = bunifuDataGridView1.Columns[e.ColumnIndex].Name;
                String id = bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();


                Détaile_Produit _Produit = new Détaile_Produit(int.Parse(id));
                _Produit.ShowDialog();

               
               
                
                bunifuDataGridView1.Rows[index].Selected = true;


            }
            catch
            {

            }
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
