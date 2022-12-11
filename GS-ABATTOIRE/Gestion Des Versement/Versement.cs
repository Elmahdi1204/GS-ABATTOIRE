using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS_ABATTOIRE.Gestion_Des_Versement
{
    public partial class Versement : Form
    {
        String type;
        int id ;
        public Versement(String type ,  int id  , string Nom , string credit  )
        {
            InitializeComponent();
            this.id = id;
            this.type = type;
            bunifuTextBox1.Text = Nom;
            bunifuTextBox2.Text = credit;
            bunifuDatePicker1.Value = DateTime.Now;

        }

        private void Versement_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "" )
            {
                MessageBox.Show("Esseyer remplir toutes les zones.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                DateTime date = new DateTime(bunifuDatePicker1.Value.Year, bunifuDatePicker1.Value.Month, bunifuDatePicker1.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                DataVersement.Ajouter_versment(id ,type , double.Parse( bunifuTextBox2.Text) ,date);
                MessageBox.Show("Versment ajouter avec succes", "Ajouter avec succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }
    }
}
